using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintance.Entities;

namespace UserMaintance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Resource1.FullName; 
            button1.Text = Resource1.Add;
            button2.Text = Resource1.Fileedit; 
            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fel = new User()
            {
                FullName = textBox1.Text,
               

            };
            users.Add(fel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*SaveFileDialog sf = new SaveFileDialog();
            if (sf.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (sf.ShowDialog() == DialogResult.OK)
            {
            */
                TextWriter sw = new StreamWriter(@"C:\Users\milan\Documents\Dni");
                sw.Write(textBox1.Text);

       

        }       
    }
}
