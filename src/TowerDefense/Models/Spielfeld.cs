using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TowerDefense.Models
{
    public class Spielfeld : PictureBox
    {
        public Spielfeld(int breite, int hoehe)
        {
            Width = breite;
            Height = hoehe;

            ImageLocation = 
                Environment.CurrentDirectory + @"\Images\GrassTexture.jpg";
        }
    }
}