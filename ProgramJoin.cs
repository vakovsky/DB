using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleAppDB4
{
    public class User //Колони в таблицата
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public virtual List<Log> Logs { get; set; }
    }

    public class Log
    {
        public int LogId { get; set; }
        public string Info { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }

    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Student\source\repos\SolutionUASD\ConsoleAppDB4\Database4.mdf;Integrated Security=True") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //SELECT ALL
            using (var context = new DataBaseContext())
            {
                var users = from b in context.Users
                            orderby b.Name
                            select b;
                Console.WriteLine("All users in the database:");
                foreach (var user in users)
                {
                    Console.WriteLine("{0} {1} {2} {3}", user.Id, user.Name, user.Email, user.Age);
                }
            }
            
            //INSERT
            Console.Write("user name = ");
            string userNane = Console.ReadLine();
            Console.Write("user email = ");
            string eMail = Console.ReadLine();
            Console.Write("user age = ");
            int age = int.Parse(Console.ReadLine());
            using (var context = new DataBaseContext())
            {
                var user = new User
                {
                    Name = userNane,
                    Email = eMail,
                    Age = age,
                };
                context.Users.Add(user);
                context.SaveChanges();
            }

            using (var context = new DataBaseContext())
            {
                var users = from b in context.Users
                            orderby b.Name
                            select b;
                Console.WriteLine("All users in the database:");
                foreach (var user in users)
                {
                    Console.WriteLine("{0} {1} {2} {3}", user.Id, user.Name, user.Email, user.Age);
                }
            }

            /*
            //DELETE
            Console.Write("user id = ");
            int id = int.Parse(Console.ReadLine());
            using (var context = new DataBaseContext())
            {
                var bay = (from d in context.Users where d.Id == id select d).Single();
                context.Users.Remove(bay);
                context.SaveChanges();
            }
            */

            //INSERT
            Console.Write("user id = ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("info = ");
            string info = Console.ReadLine();
            using (var context = new DataBaseContext())
            {
                var user = (from d in context.Users
                            where d.Id == id
                            select d).Single();

                var log = new Log
                {
                     Info = info,
                     User = user,
                };
                context.Logs.Add(log);
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
                    Console.WriteLine("{0} {1} {2} {3}", user.Id, user.Name, user.Email, user.Age);
                }
            }

            //SELECT ALL
            using (var context = new DataBaseContext())
            {
                var logs = from b in context.Logs
                            orderby b.LogId
                            select b;
                Console.WriteLine("All logs in the database:");
                foreach (var log in logs)
                {
                    Console.WriteLine("{0} {1}", log.LogId, log.Info);
                }
            }

            using (var context = new DataBaseContext())
            {
                var query = from s in context.Users
                            join e in context.Logs on s.Id equals e.UserId
                            where s.Id == id    
                            orderby s.Name
                            select new { s, e};
                foreach (var item in query)
                {
                    Console.WriteLine(item.s.Name + item.e.Info);
                }
            }
 
            Console.ReadLine();
        }
    }
}
