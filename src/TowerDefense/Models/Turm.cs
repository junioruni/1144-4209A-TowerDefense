using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TowerDefense.Models
{
    public class Turm : PictureBox
    {
        public Turm()
        {
            Width = 60;
            Height = 60;

            ImageLocation =
                Environment.CurrentDirectory + @"\Images\Tower60_Blue.png";
        }
    }
}
