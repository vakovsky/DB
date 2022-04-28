using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryDB;

namespace WindowsFormsAppDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SELECT ALL
            using (var context = new DataBaseContext())
            {
                comboBox1.Items.Clear();
                dataGridView1.Rows.Clear();
                var users = from u in context.Users
                            orderby u.Name
                            select u;
                foreach (var user in users)
                {
                    comboBox1.Items.Add(user.UserId);
                    dataGridView1.Rows.Add(user.UserId, user.Name, user.Email, user.Age);
                }
                comboBox1.SelectedIndex = 0;
            }         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //INSERT
            User user = new User();

            user.Name = this.textBox1.Text;
            user.Email = this.textBox2.Text;
            user.Age = int.Parse(this.textBox3.Text);

            using (var context = new DataBaseContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            comboBox1.Items.Clear();
            Form1_Load(this, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            using (var context = new DataBaseContext())
            {
                int id = int.Parse(this.comboBox1.Text);
                var user = (from u in context.Users
                            where u.UserId == id
                            select u).Single();
                textBox1.Text = user.Name;
                textBox2.Text = user.Email;
                textBox3.Text = user.Age.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //UPDATE
            using (var context = new DataBaseContext())
            {
                int id = int.Parse(this.comboBox1.Text);
                var user = (from s in context.Users
                            where s.UserId == id
                            select s).Single();
                user.Name = this.textBox1.Text;
                user.Email = this.textBox2.Text;
                user.Age = int.Parse(this.textBox3.Text);
                context.SaveChanges();
                Form1_Load(this, e);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //DELETE
            using (var context = new DataBaseContext())
            {
                int id = int.Parse(this.comboBox1.Text);
                var user = (from s in context.Users 
                           where s.UserId == id
                           select s).Single();
                context.Users.Remove(user);
                context.SaveChanges();
            }
            comboBox1.Items.Clear();
            Form1_Load(this, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }
    }
}
