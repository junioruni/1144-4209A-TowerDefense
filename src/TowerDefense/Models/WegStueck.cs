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
    public class WegStueck : PictureBox
    {
        public WegStueck()
        {
            Width = 60;
            Height = 60;

            ImageLocation = 
                Environment.CurrentDirectory + @"\Images\PathSegment.png";
        }
    }
}
