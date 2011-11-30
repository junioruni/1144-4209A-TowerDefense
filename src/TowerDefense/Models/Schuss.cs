using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TowerDefense.Ebenen;
using TowerDefense.Logic;

namespace TowerDefense.Models
{
    public class Schuss : PictureBox
    {
        public Turm SchiessenderTurm { get; set; }
        public Gegner Ziel { get; set; }

        public Schuss(Turm schiessenderTurm)
        {
            BackColor = Color.Transparent;
            Width = 30;
            Height = 30;

            SchiessenderTurm = schiessenderTurm;
            Ziel = FindeNaechstenGegnerZuTurm(SchiessenderTurm);

            if (Ziel == null)
            {
                Timer zielFinder = new Timer() { Interval = 100};
                zielFinder.Tick += new EventHandler(zielFinder_Tick);
                zielFinder.Start();
            }

            Left = SchiessenderTurm.Left;
            Top = SchiessenderTurm.Top;

            ImageLocation =
                Environment.CurrentDirectory + @"\Images\Shot.png";

            Timer t = new Timer();
            t.Interval = 10;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        void zielFinder_Tick(object sender, EventArgs e)
        {
            if (Ziel == null)
                Ziel = FindeNaechstenGegnerZuTurm(SchiessenderTurm);
        }

        private static Gegner FindeNaechstenGegnerZuTurm(Turm turm)
        {
            var alleGegner = GegnerLogik.ListeAllerGegner;

            Gegner gegnerZumZurueckgeben = null;
            double smallestValue = double.MaxValue;
            foreach (Gegner gegner in alleGegner)
            {
                double entfernungVonTurmZuGegner = EntfernungsHelfer.ErmittleEntfernung(turm.Location, gegner.Location);

                if (entfernungVonTurmZuGegner < smallestValue)
                {
                    smallestValue = entfernungVonTurmZuGegner;
                    gegnerZumZurueckgeben = gegner;
                }
            }

            return gegnerZumZurueckgeben;
        }

        void t_Tick(object sender, EventArgs e)
        {
            if (Ziel != null)
            {
                bool bewegt = true;

                float Speed = 10;

                Single hSpeed, vSpeed;

                hSpeed = Ziel.Location.X - this.Location.X;
                vSpeed = Ziel.Location.Y - this.Location.Y;

                Single max =
                    Math.Max(
                        Math.Abs(hSpeed),
                        Math.Abs(vSpeed));

                hSpeed /= max;
                vSpeed /= max;

                hSpeed *= Speed;
                vSpeed *= Speed;

                this.Left += (int)hSpeed;
                this.Top += (int)vSpeed;

                Rectangle meinRechteck =
                    Rectangle.FromLTRB(
                        this.Left,
                        this.Top,
                        this.Right,
                        this.Bottom);

                Rectangle zielRechteck =
                    Rectangle.FromLTRB(
                        Ziel.Left,
                        Ziel.Top,
                        Ziel.Right,
                        Ziel.Bottom);

                if (meinRechteck.IntersectsWith(zielRechteck))
                {
                    bewegt = false;

                    this.Left = SchiessenderTurm.Left;
                    this.Top = SchiessenderTurm.Top;

                }

                if (!bewegt)
                {
                    Left = SchiessenderTurm.Left;
                    Top = SchiessenderTurm.Top;

                    Ziel.BehandleTreffer();
                    Ziel = FindeNaechstenGegnerZuTurm(SchiessenderTurm);
                }
            }
        }
    }
}
