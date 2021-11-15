namespace Credentials.Interop
{
    public class PasswordCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public PasswordCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
