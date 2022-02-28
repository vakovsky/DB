    class UsersStub
    {
        string username;
        string password;
        public void Insert(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public string Select(string username)
        {
            return password;
        }
    }
