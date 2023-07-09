using OptechX.Portal.Shared.Models.User;

namespace OptechX.Portal.Client.Services
{
	public interface IUserAccountService
	{
        UserAccountRequiredFields UserAccountRequiredFields { get; }
        Task LoadUserAccountRequiredFieldsAsync();
    }
}

