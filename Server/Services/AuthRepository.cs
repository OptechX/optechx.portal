using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OptechX.Portal.Server.Data;
using OptechX.Portal.Server.Helpers;
using OptechX.Portal.Shared.Models.Generic;
using OptechX.Portal.Shared.Models.User;
using OptechX.Portal.Shared.Models.User.Constants;

namespace OptechX.Portal.Server.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApiDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly UserLoginResponse emptyResult = new UserLoginResponse()
        {
            JWT = string.Empty,
            Id = Guid.Empty.ToString(),
            Company = string.Empty,
            FirstName = string.Empty,
            LastName = string.Empty,
            PhoneNumber = string.Empty,
            City = string.Empty,
            State = string.Empty,
            PostalCode = string.Empty,
            UserIcon = string.Empty,
            BillingType = string.Empty,
            AccountTier = string.Empty,
            ImagesRemaining = 0,
            AppLockerStorageAvailable = 0,
            AppLockerStorageUsed = 0,
        };

        public AuthRepository(ApiDbContext dbContext, IConfiguration configuration, IEmailService emailService)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _emailService = emailService;
        }

        public async Task<ServiceResponse<UserLoginResponse>> Login(UserLogin userLogin)
        {
            var response = new ServiceResponse<UserLoginResponse>();

            var user = await _dbContext.UserAccounts!.FirstOrDefaultAsync(u => u.EmailAddress == userLogin.Email.ToLower());
            if (user == null)
            {
                response.Data = emptyResult;
                response.Success = false;
                response.Message = "Invalid username or password";
                response.ResponseCode = 403;

                return response;
            }
            else if (!user.IsVerified)
            {
                response.Data = emptyResult;
                response.Success = false;
                response.Message = "User account verification failed";
                response.ResponseCode = 412;

                return response;
            }

            if (!PasswordHelper.VerifyPassword(
                password: userLogin.Password,
                storedHashedPassword: user.Password ?? string.Empty,
                storedSalt: user.Password2 ?? string.Empty))
            {
                response.Data = emptyResult;
                response.Success = false;
                response.Message = "Invalid username or password";
                response.ResponseCode = 401;

                return response;
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim("AccountId", user.Id.ToString()),
                new Claim("BillingType", user.BillingType.ToString()),
                new Claim("AccountTier", user.AccountTier.ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audence"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: credentials);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new ServiceResponse<UserLoginResponse>
            {
                Data = new UserLoginResponse()
                {
                    JWT = jwt,
                    Id = user.Id.ToString(),
                    Company = user.Company,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    City = user.City,
                    State = user.State,
                    PostalCode = user.PostalCode,
                    UserIcon = user.UserIcon,
                    BillingType = user.BillingType.ToString(),
                    AccountTier = user.AccountTier.ToString(),
                    ImagesRemaining = user.ImagesRemaining,
                    AppLockerStorageAvailable = user.AppLockerStorageAvailable,
                    AppLockerStorageUsed = user.AppLockerStorageUsed,
                },
                Success = true,
                Message = "OK",
                ResponseCode = 200,
            };
        }

        public async Task<ServiceResponse<string>> Register(UserRegister userRegister)
        {
            var userExists = await _dbContext.UserAccounts!.FirstOrDefaultAsync(u => u.EmailAddress == userRegister.Email.ToLower());
            if (userExists != null)
            {
                return new ServiceResponse<string>
                {
                    Data = "Conflict",
                    Message = "User account already exists",
                    ResponseCode = 409,
                    Success = false,
                };
            }
            UserAccount userAccount = new();
            var userCount = await _dbContext.UserAccounts!.CountAsync();
            switch(userCount)
            {
                case 0:
                    userAccount.Role = Role.ADMIN;
                    break;
                default:
                    userAccount.Role = Role.USER;
                    break;
            }
            string verificationToken = OptechXValueGenerator.GenerateRandomString(8);
            DateTime timeNow = DateTime.UtcNow;
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = PasswordHelper.GenerateSaltAndHashPassword(salt: salt, password: userRegister.Password);
            userAccount.EmailAddress = userRegister.Email.ToLower();
            userAccount.Password = hashedPassword;
            userAccount.Password2 = salt;
            userAccount.VerificationToken = verificationToken;
            userAccount.Country = userRegister.Country;
            userAccount.Created = DateTime.Now;

            _dbContext.UserAccounts!.Add(userAccount);
            await _dbContext.SaveChangesAsync();

            // email the user their verification email
            string emailTemplate = EmailTemplates.VerifyEmailAddress(
                recipientSmtp: userAccount.EmailAddress,
                verifyUrl: $"https://portal.optechx.com/account/verify-account?token={userAccount.VerificationToken}");
            await _emailService.SendAsync(
                to: userAccount.EmailAddress,
                subject: "Welcome to OptechX!",
                html: emailTemplate);

            return new ServiceResponse<string>
            {
                Data = "Created",
                Message = "User account created successfully",
                ResponseCode = 201,
                Success = true,
            };
        }

        public async Task<ServiceResponse<int>> VerifyAccount(string verificationToken)
        {
            var userFound = await _dbContext.UserAccounts!.FirstOrDefaultAsync(u => u.VerificationToken == verificationToken);
            if (userFound is null)
            {
                return new ServiceResponse<int>()
                {
                    Data = 1,
                    Message = "Verification Token either expired or incorrect",
                    ResponseCode = 403,
                    Success = false,
                };
            }
            DateTime verifiedAt = DateTime.UtcNow;
            userFound.Verified = verifiedAt;
            userFound.Updated = verifiedAt;
            await _dbContext.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Data = 0,
                Message = "Account verified successfully",
                ResponseCode = 200,
                Success = true,
            };
        }
    }
}

