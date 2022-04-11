using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace ConsoleApp8
{
    class TableUsers //Таблицата Users
    {
        OleDbConnection oleDbConnection;
        public void Open()
        {
            //CONNECTION
            oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=../../Database2.accdb;";
            oleDbConnection.Open();
        }
        public void Close()
        {
            //DISCONNECTION
            oleDbConnection.Close();
        }
        //CRUD
        public void Insert(User user)
        {
            //INSERT
            this.Open();
            OleDbCommand oleDbCommand;
            oleDbCommand = new OleDbCommand();
            oleDbCommand.Connection = oleDbConnection;
            string command = String.Format(
                "insert into users (Name, Email, Age) values (\"{0}\", \"{1}\", {2})", user.Name, user.Email, user.Age);
            //Console.WriteLine(command);
            oleDbCommand.CommandText = command;
            oleDbCommand.ExecuteNonQuery();
            this.Close();
        }
        //DELETE
        public void Delete(int id)
        {
            this.Open();
            OleDbCommand oleDbCommand;
            oleDbCommand = new OleDbCommand();
            oleDbCommand.Connection = oleDbConnection;
            oleDbCommand.CommandText = "delete from users where id =" + id + "";
            oleDbCommand.ExecuteNonQuery();
            this.Close();
        }
        //UPDATE
        public void Update(User user)
        {
            this.Open();
            OleDbCommand oleDbCommand;
            oleDbCommand = new OleDbCommand();
            oleDbCommand.Connection = oleDbConnection;
            oleDbCommand.CommandText = "update users set Name = \"" + user.Name + "\" where id =" + user.Id + "";
            oleDbCommand.ExecuteNonQuery();
            this.Close();
        }
        //SELECT
        public User Select(int id)
        {
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

    }
}
