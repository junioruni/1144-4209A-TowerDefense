using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TowerDefense.Models
{
    public class Schuss : PictureBox
    {
        public Turm SchiessenderTurm { get; set; }
        public Enemy Ziel { get; set; }

        public Schuss(Turm schiessenderTurm, Enemy ziel)
        {
            BackColor = Color.Transparent;
            Width = 30;
            Height = 30;

            SchiessenderTurm = schiessenderTurm;
            Ziel = ziel;

            Left = SchiessenderTurm.Left;
            Top = SchiessenderTurm.Top;

            ImageLocation =
                Environment.CurrentDirectory + @"\Images\Shot.png";
        }
    }
}
