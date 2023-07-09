using OptechX.Portal.Shared.Models.User;

namespace OptechX.Portal.Client.Services
{
    public interface IUserAccountService
    {
        IUserAccountRequiredFields UserAccountRequiredFields { get; }
        Task LoadUserAccountRequiredFieldsAsync();
    }
}
