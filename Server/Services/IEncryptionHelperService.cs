namespace OptechX.Portal.Server.Services
{
	public interface IEncryptionHelperService
	{
        string EncryptData(string value, Guid key);
        string DecryptData(string encryptedValue, Guid key);
    }
}

