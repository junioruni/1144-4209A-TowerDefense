using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TowerDefense.Models
{
    public class Enemy : PictureBox
    {
        public int WegpunktIndex { get; set; }

        public Enemy()
        {
            Width = 60;
            Height = 60;

            ImageLocation =
                Environment.CurrentDirectory + @"\Images\Enemy.png";
        }
    }
}
