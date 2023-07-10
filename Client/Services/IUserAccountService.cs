using OptechX.Portal.Shared.Models.User;

namespace OptechX.Portal.Client.Services
{
    public interface IUserAccountService
    {
        UserData UserDatas { get; set; }
        Task LoadUserDatasAsync();
    }
}
