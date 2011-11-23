using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TowerDefense.Models;

namespace TowerDefense
{
    public partial class Main : Form
    {
        public Enemy SingleEnemy { get; set; }
        public Weg AktuellerWeg { get; set; }
        Spielfeld spielfeld;

        public Main()
        {
            InitializeComponent();

            Width = 1000;
            Height = 800;

            // Spielfeld erstellen und die Größe des Formulars übergeben.
            // [MB]
            spielfeld = new Spielfeld(Width, Height);

            // Spielfeld auf dem Formular anzeigen.
            // [PP]
            Controls.Add(spielfeld);

            AktuellerWeg = new Weg(spielfeld.Controls, 60, 60, 0, 5);
            AktuellerWeg.FeldZumWegHinzufuegen(1, 0);
            AktuellerWeg.FeldZumWegHinzufuegen(1, 0);
            AktuellerWeg.FeldZumWegHinzufuegen(0, -1);
            AktuellerWeg.FeldZumWegHinzufuegen(0, -1);
            AktuellerWeg.FeldZumWegHinzufuegen(1, 0);
            AktuellerWeg.FeldZumWegHinzufuegen(1, 0);
            AktuellerWeg.FeldZumWegHinzufuegen(1, 0);
            AktuellerWeg.FeldZumWegHinzufuegen(1, 0);
            AktuellerWeg.FeldZumWegHinzufuegen(1, 0);
            AktuellerWeg.FeldZumWegHinzufuegen(1, 0);
            AktuellerWeg.FeldZumWegHinzufuegen(1, 0);
            AktuellerWeg.FeldZumWegHinzufuegen(1, 0);
            AktuellerWeg.FeldZumWegHinzufuegen(1, 0);


            var nextWaypoint = AktuellerWeg.GetNextFieldToMove();

            SingleEnemy =
                new Enemy
                    {
                        Left = nextWaypoint.X,
                        Top = nextWaypoint.Y + 10,
                        BackColor = Color.Transparent
                    };

            spielfeld.Controls.Add(SingleEnemy);
            SingleEnemy.BringToFront();
            
            spielfeld.MouseClick += spielfeld_MouseClick;
        }

        void spielfeld_MouseClick(object sender, MouseEventArgs e)
        {
            var neuerTurm =
                new Turm
                    {
                        Left = (int) Math.Floor((double) e.X/60)*60,
                        Top = (int) Math.Floor((double) e.Y/60)*60,
                        BackColor = Color.Transparent
                    };

            spielfeld.Controls.Add(neuerTurm);
            neuerTurm.BringToFront();
        }

        private void BtWeiter_Click(object sender, EventArgs e)
        {
            SingleEnemy.WegpunktIndex++;

            var nextWaypoint = 
                AktuellerWeg.GetNextFieldToMove(SingleEnemy.WegpunktIndex);
            
            SingleEnemy.Left = nextWaypoint.X;
            SingleEnemy.Top = nextWaypoint.Y + 10;
        }
    }
}
