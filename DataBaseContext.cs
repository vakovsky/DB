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
        public DataBaseContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Database2.mdf;Integrated Security=True;Connect Timeout=30") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
