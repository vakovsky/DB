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
