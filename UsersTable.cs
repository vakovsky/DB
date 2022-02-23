using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace ConsoleApplication6
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //CONNECTION
            OleDbConnection oleDbConnection;
            oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                @"Data Source=Database2.accdb;";
            oleDbConnection.Open();

            //INSERT
            /*string userName;
            Console.Write("User Name: ");
            userName = Console.ReadLine();
            string eEmil;
            Console.Write("User eEmil: ");
            eEmil = Console.ReadLine();
            int age;
            Console.Write("User Age: ");
            age = int.Parse(Console.ReadLine());
            //
            OleDbCommand oleDbCommand;
            oleDbCommand = new OleDbCommand();
            oleDbCommand.Connection = oleDbConnection;
            string command = String.Format(
                "insert into users (Name, Email, Age) values (\"{0}\", \"{1}\", {2})", userName, eEmil, age);
            //Console.WriteLine(command);
            oleDbCommand.CommandText = command;
            oleDbCommand.ExecuteNonQuery();*/

            //DELETE
            /*int id;
            Console.Write("User ID: ");
            id = int.Parse(Console.ReadLine());
            //
            OleDbCommand oleDbCommand;
            oleDbCommand = new OleDbCommand();
            oleDbCommand.Connection = oleDbConnection;
            oleDbCommand.CommandText = "delete from users where id =" + id + "";
            oleDbCommand.ExecuteNonQuery();*/

            //UPDATE
            /*int id;
            Console.Write("User ID: ");
            id = int.Parse(Console.ReadLine());
            string UserName;
            Console.Write("New User Name: ");
            UserName = Console.ReadLine();
            //
            OleDbCommand oleDbCommand;
            oleDbCommand = new OleDbCommand();
            oleDbCommand.Connection = oleDbConnection;
            oleDbCommand.CommandText = "update users set name = \"" + UserName + "\" where id =" + id + "";
            oleDbCommand.ExecuteNonQuery();*/

            //SELECT
            /*int id;
            Console.Write("User ID: ");
            id = int.Parse(Console.ReadLine());

            OleDbCommand oleDbCommand;
            oleDbCommand = new OleDbCommand();
            oleDbCommand.Connection = oleDbConnection;
            oleDbCommand.CommandText = "select * from users where id = " + id + "";
            OleDbDataReader oleDbDataReader;
            oleDbDataReader = oleDbCommand.ExecuteReader();
            oleDbDataReader.Read();
            Console.Write(oleDbDataReader[0]);
            Console.WriteLine(oleDbDataReader["name"]);
            oleDbDataReader.Close();*/

            /*OleDbCommand oleDbCommand;
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
                user.Email = oleDbDataReader.GetString(2);
                user.Age = oleDbDataReader.GetInt32(1);
                users.Add(user);
            }
            oleDbDataReader.Close();

            foreach(User user in users)
            {
                Console.WriteLine("{0} {1} {2} {3}", user.Id, user.Name, user.Email, user.Age);
            }*/

            //DISCONNECTION
            oleDbConnection.Close();

          
        }
    }
}
