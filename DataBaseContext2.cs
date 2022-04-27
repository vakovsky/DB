using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ClassLibraryDB
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public virtual List<Log> Logs { get; set; }
    }
    public class Student : User
    {
        public string FN { get; set; }
    }
    public class Teacher : User
    {
        public int Salary { get; set; }
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
        public DataBaseContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dudin\Documents\Database2.mdf;Integrated Security=True;Connect Timeout=30") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        
    }
}
