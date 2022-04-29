using System;

namespace ConsoleAppCF
{  
    class Program
    {
        static void Main(string[] args)
        {
            //INSERT
            using (var context = new DataBaseContext())
            {
                var user = new User();                  
                user.Name = Console.ReadLine();
                user.Email = Console.ReadLine();
                user.Age = int.Parse(Console.ReadLine());              
                context.Users.Add(user);
                context.SaveChanges();
            }

            //SELECT
            using (var context = new DataBaseContext())
            {
                int id = int.Parse(Console.ReadLine());
                var user = (from u in context.Users
                            where u.UserId == id
                            select u).Single();
                Console.WriteLine(user.Name);
            }

            //UPDATE
            using (var context = new DataBaseContext())
            {
                int id = int.Parse(Console.ReadLine());
                var user = (from u in context.Users
                               where u.UserId == id
                               select u).Single();
                user.Name = "User2";
                context.SaveChanges();
            }

            //DELETE
            using (var context = new DataBaseContext())
            {
                int id = int.Parse(Console.ReadLine());
                var user = (from u in context.Users 
                           where u.UserId == id
                           select u).Single();
                context.Users.Remove(user);
                context.SaveChanges();
            }

            //SELECT ALL
            using (var context = new DataBaseContext())
            {
                var users = from u in context.Users
                            orderby u.UserId
                            select u;
                Console.WriteLine("All users in the database:");
                foreach (var user in users)
                {
                    Console.WriteLine("{0} {1}", user.UserId, user.Name);
                }
            }
        }
    }
}
