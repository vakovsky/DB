class MVCModelClass2
    {
        OleDbConnection oleDbConnection;

        public void Open()
        {
            //CONNECTION
            //OleDbConnection oleDbConnection;
            oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source=Database2.accdb;";
            oleDbConnection.Open();
        }

        //CRUD

        public void Insert(string userName, string eEmil, int age)
        {
            //INSERT
            this.Open();
            OleDbCommand oleDbCommand;
            oleDbCommand = new OleDbCommand();
            oleDbCommand.Connection = oleDbConnection;
            string command = String.Format(
                "insert into users (Name, Email, Age) values (\"{0}\", \"{1}\", {2})", userName, eEmil, age);
            //Console.WriteLine(command);
            oleDbCommand.CommandText = command;
            oleDbCommand.ExecuteNonQuery();
            this.Close();
        }

        public void Delete(int id)
        {
            //DELETE
            this.Open();
            OleDbCommand oleDbCommand;
            oleDbCommand = new OleDbCommand();
            oleDbCommand.Connection = oleDbConnection;
            oleDbCommand.CommandText = "delete from users where id =" + id + "";
            oleDbCommand.ExecuteNonQuery();
            this.Close();
        }

        public void Update(int id, string UserName)
        {
            //UPDATE
            this.Open();
            OleDbCommand oleDbCommand;
            oleDbCommand = new OleDbCommand();
            oleDbCommand.Connection = oleDbConnection;
            oleDbCommand.CommandText = "update users set name = \"" + UserName + "\" where id =" + id + "";
            oleDbCommand.ExecuteNonQuery();
            this.Close();
        }

        public User Select(int id)
        {
            //SELECT
            this.Open();
            OleDbCommand oleDbCommand;
            oleDbCommand = new OleDbCommand();
            oleDbCommand.Connection = oleDbConnection;
            oleDbCommand.CommandText = "select * from users where id = " + id + "";
            OleDbDataReader oleDbDataReader;
            oleDbDataReader = oleDbCommand.ExecuteReader();
            oleDbDataReader.Read();
            User user = new User();
            user.Id = oleDbDataReader.GetInt32(0);
            user.Name = oleDbDataReader.GetString(1);
            user.Email = oleDbDataReader.GetString(2);
            user.Age = oleDbDataReader.GetInt32(3);
            oleDbDataReader.Close();
            this.Close();
            return user;
        }

        //List

        public List<User> SelectAll()
        {

            this.Open();
            OleDbCommand oleDbCommand;
            oleDbCommand = new OleDbCommand();
            oleDbCommand.Connection = oleDbConnection;
            oleDbCommand.CommandText = "select * from users";
            OleDbDataReader oleDbDataReader;
            oleDbDataReader = oleDbCommand.ExecuteReader();
            List<User> users = new List<User>();
            while (oleDbDataReader.Read())
            {
                User user = new User();
                user.Id = oleDbDataReader.GetInt32(0);
                user.Name = oleDbDataReader.GetString(1);
                if (oleDbDataReader[2] != DBNull.Value)
                {
                    user.Email = oleDbDataReader.GetString(2);
                }
                else
                {
                    user.Email = "null";
                }
                if (oleDbDataReader[3] != DBNull.Value)
                {
                    user.Age = oleDbDataReader.GetInt32(3);
                }
                else
                {
                    user.Age = 0;
                }
                users.Add(user);

            }
            oleDbDataReader.Close();
            this.Close();
            return users;

        }

        public void Close()
        {
            //DISCONNECTION
            oleDbConnection.Close();
        }
    }
