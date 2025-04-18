namespace WinFormsApp1
{
    public static class UserManager
    {
        private static Dictionary<string, string> users = new Dictionary<string, string>();

        public static bool RegisterUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || users.ContainsKey(username))
                return false;

            users[username] = password;
            return true;
        }

        public static bool ValidateUser(string username, string password)
        {
            return users.ContainsKey(username) && users[username] == password;
        }
    }
}
