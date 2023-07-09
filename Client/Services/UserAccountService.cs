using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;

namespace OptechX.Portal.Client.Services
{
    public interface IUserAccReqData
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }
        public string? Company { get; set; }
        public string? TaxId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? UserIcon { get; set; }
    }

    public class UserAccountRequiredFields : IUserAccReqData
    {
        public Guid Id { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;
        public string? Company { get; set; }
        public string? TaxId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? UserIcon { get; set; }
    }

    public class UserAccountService : IUserAccountService
    {
        private readonly HttpClient _httpClient;

        public UserAccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IUserAccReqData UserAccountRequiredFields { get; set; } = new UserAccountRequiredFields();

        public async Task LoadUserAccountRequiredFieldsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<UserAccountRequiredFields>("api/user");
            if (response != null)
            {
                UserAccountRequiredFields = response;
            }
        }
    }
}
