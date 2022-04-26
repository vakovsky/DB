using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new UniDbContext())
            {
                var user = new User
                {
                    Name = this.textBox1.Text,
                    Email = this.textBox2.Text,
                    Age = int.Parse(this.textBox3.Text),
                };
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
    public class User //Колони в таблицата
    {
        public int UserId { get; set; }
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
    public class UniDbContext : DbContext
    {
        //public UniDbContext() : base("Uni") { }
        public UniDbContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Teacher412\Documents\dataef.mdf;Integrated Security=True;Connect Timeout=30") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
