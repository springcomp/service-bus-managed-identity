using CredentialManagement;
using Credentials.Interop;

namespace CredentialsWin64
{
    public sealed class CredentialStore : ICredentialStore
    {
        public static PasswordCredentials GetCredential(string target)
        {
            var cm = new Credential { Target = target };
            if (!cm.Load())
                return null;

            return new PasswordCredentials(cm.Username, cm.Password);
        }

        public bool SetCredentials(
             string target,
             string username,
             string password,
             PersistanceType persistenceType
        )
        {
            return new Credential
            {
                Target = target,
                Username = username,
                Password = password,
                PersistanceType = persistenceType
            }.Save();
        }

        public bool RemoveCredentials(string target)
        {
            return new Credential { Target = target }.Delete();
        }
    }
}
