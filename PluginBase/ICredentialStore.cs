namespace Credentials.Interop
{
	public interface ICredentialStore
	{
		bool SetCredentials(string target, string username, string password);
		bool RemoveCredentials(string target);
	}
}