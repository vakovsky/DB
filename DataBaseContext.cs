using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApp1
{
    public class User //Колони в таблицата
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dudin\Documents\Database2.mdf;Integrated Security=True;Connect Timeout=30") { }
        public DbSet<User> Users { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //INSERT
            using (var context = new DataBaseContext())
            {
                var user = new User
                {
                    Name = "User1",
                    Email = "user1@site.com",
                    Age = 18,
                };
                context.Users.Add(user);
                context.SaveChanges();
            }

            //SELECT
            using (var context = new DataBaseContext())
            {
                var user = (from d in context.Users
                            where d.Name == "User1"
                            select d).Single();
                Console.WriteLine(user.Name);
            }

            //UPDATE
            using (var context = new DataBaseContext())
            {
                var user = (from d in context.Users
                               where d.Name == "User1"
                               select d).Single();
                user.Name = "User2";
                context.SaveChanges();
            }

            //DELETE
            using (var context = new DataBaseContext())
            {
                var bay = (from d in context.Users where d.Name == "User2" select d).Single();
                context.Users.Remove(bay);
                context.SaveChanges();
            }

            //SELECT ALL
            using (var context = new DataBaseContext())
            {
                var users = from b in context.Users
                            orderby b.Name
                            select b;
                Console.WriteLine("All users in the database:");
                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }
            }
        }
    }
}
