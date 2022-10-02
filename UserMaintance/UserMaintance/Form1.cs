﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            label1.Text = Resource1.FullName; 
            label2.Text = Resource1.FirstName; 
            button1.Text = Resource1.Add; 
            button2.Text = Resource1.Delete;
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
                
                LastName = textBox1.Text,
                FirstName = textBox2.Text

            };
            users.Add(fel);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Guid delete = ((User)listBox1.SelectedItem).ID;
            var torol = (from x in users
                     where x.ID == delete
                     select x).FirstOrDefault();
            users.Remove(torol);

        }
    }
}
