using System;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            TableUsers modelUsers;
            modelUsers = new TableUsers();

            //INSERT
            User userI = new User();
            Console.Write("Name = "); userI.Name = Console.ReadLine();
            Console.Write("Email = "); userI.Email = Console.ReadLine();
            Console.Write("Age = "); userI.Age = int.Parse(Console.ReadLine());
            modelUsers.Insert(userI);

            //SELECT
            User userS = modelUsers.Select(12);
            Console.WriteLine(userS.Name);
            Console.WriteLine(userS.Email);
            Console.WriteLine(userS.Age);

            //UPDATE
            User userU = modelUsers.Select(12);
            Console.Write(userS.Name + " = "); userU.Name = Console.ReadLine();
            Console.Write(userS.Email + " = "); userU.Email = Console.ReadLine();
            Console.Write(userS.Age + " = "); userU.Age = int.Parse(Console.ReadLine());
            modelUsers.Update(userU);

            //SELECT
            User userS2 = modelUsers.Select(12);
            Console.WriteLine(userS2.Name);
            Console.WriteLine(userS2.Email);
            Console.WriteLine(userS2.Age);

            //DELETE
            //modelUsers.Delete(15);

        }
    }
}
