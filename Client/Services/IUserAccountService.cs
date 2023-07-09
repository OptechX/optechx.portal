namespace OptechX.Portal.Client.Services
{
    public interface IUserAccountService
    {
        IUserAccReqData UserAccountRequiredFields { get; }
        Task LoadUserAccountRequiredFieldsAsync();
    }
}
