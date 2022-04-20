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
        public DataBaseContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Database2.mdf;Integrated Security=True;Connect Timeout=30") { }
        public DbSet<User> Users { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int id;

            //SELECT ALL
            using (var context = new DataBaseContext())
            {
                var users = from b in context.Users
                            orderby b.Name
                            select b;
                Console.WriteLine("All users in the database:");
                foreach (var user in users)
                {
                    Console.WriteLine("{0}, {1} {2}", user.Id, user.Name, user.Email);
                }
            }

            //INSERT
            string name;
            Console.Write("name = ");
            name = Console.ReadLine();

            string eMail;
            Console.Write("eMail = ");
            eMail = Console.ReadLine();

            int age;
            Console.Write("age = ");
            age = int.Parse(Console.ReadLine());

            using (var context = new DataBaseContext())
            {
                var user = new User
                {
                    Name = name,
                    Email = eMail,
                    Age = age,
                };
                context.Users.Add(user);
                context.SaveChanges();
            }

            //SELECT
            Console.Write("id = ");
            id = int.Parse(Console.ReadLine());
            using (var context = new DataBaseContext())
            {
                var user = (from d in context.Users
                            where d.Id == id
                            select d).Single();
                Console.WriteLine(user.Name);
            }

            //UPDATE
            Console.Write("id = ");
            id = int.Parse(Console.ReadLine());

            Console.Write("name = ");
            name = Console.ReadLine();

            using (var context = new DataBaseContext())
            {
                var user = (from d in context.Users
                               where d.Id == id
                               select d).Single();
                user.Name = name;
                context.SaveChanges();
            }

            //DELETE
            Console.Write("id = ");
            id = int.Parse(Console.ReadLine());
            using (var context = new DataBaseContext())
            {
                var bay = (from d in context.Users where d.Id == id select d).Single();
                context.Users.Remove(bay);
                context.SaveChanges();
            }
        }
    }
}
