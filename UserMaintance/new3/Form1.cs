using new3.Abstractions;
using new3.Entities;
using new3.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace new3
{
    public partial class Form1 : Form
    {
        private List<Toy> _toys = new List<Toy>();
        private IToyFactory _factory;

        public  IToyFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        } 

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var ball = Factory.CreateNew();
            _toys.Add(ball);
            ball.Left = -ball.Width;
            mainpanel.Controls.Add(ball);

        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var ball in _toys)
            {
                ball.MoveToy();
                if (ball.Left > maxPosition)
                    maxPosition = ball.Left;
            }

            if (maxPosition > 1000)
            {
                var oldestBall = _toys[0];
                mainpanel.Controls.Remove(oldestBall);
                _toys.Remove(oldestBall);
            }
        }
    }
}
