using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldsHardestGame;

namespace _10.het
{
    public partial class Form1 : Form
    {
        GameController gc = new GameController();
        GameArea ga;

        int populationSize = 100;
        int nbrOfSteps = 10;
        int nbrOfStepsIncrement = 10;
        int generation = 1;
        Brain winnerBrain = null;

        
        
        public Form1()
        {
            InitializeComponent();
               
            ga = gc.ActivateDisplay();
            this.Controls.Add(ga);

            gc.GameOver += Gc_GameOver;

            for (int i = 0; i < populationSize; i++)
            {
                gc.AddPlayer(nbrOfSteps);
            }
            gc.Start(true);
        }

        private void Gc_GameOver(object sender)
        {
            generation++;
            label1.Text = string.Format(
                "{0}. generáció",
                generation);
            var playerList = from p in gc.GetCurrentPlayers()
                             orderby p.GetFitness() descending
                             select p;
            var topPerformers = playerList.Take(populationSize / 2).ToList();
            var gyoztes = from p in topPerformers
                          where !p.IsWinner
                          select p;
            if (gyoztes.Count() > 0)
            {
                winnerBrain = gyoztes.FirstOrDefault().Brain.Clone();
                gc.GameOver -= Gc_GameOver;

                return;

            }
            gc.ResetCurrentLevel();
            foreach (var p in topPerformers)
            {
                var alma = p.Brain.Clone();
                if (generation % 3 == 0)
                    gc.AddPlayer(alma.ExpandBrain(nbrOfStepsIncrement));
                else
                    gc.AddPlayer(alma);

                if (generation % 3 == 0)
                    gc.AddPlayer(alma.Mutate().ExpandBrain(nbrOfStepsIncrement));
                else
                    gc.AddPlayer(alma.Mutate());
            }
            gc.Start();
            
            
            
            
        }

       

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
