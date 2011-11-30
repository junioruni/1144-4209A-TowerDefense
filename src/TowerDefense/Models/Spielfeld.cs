using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TowerDefense.Ebenen;
using TowerDefense.Definitions;

namespace TowerDefense.Models
{
    public class Spielfeld : PictureBox
    {
        public Spielfeld(int breite, int hoehe)
        {
            Width = breite;
            Height = hoehe;

            StaticContainer.EinzelFeldBreite = 60;
            StaticContainer.EinzelFeldHoehe = 60;
            StaticContainer.SpielFeldBreite = Width;
            StaticContainer.SpielFeldHoehe = Height;

            ImageLocation =
                Environment.CurrentDirectory + @"\Images\GrassTexture.jpg";

            StaticContainer.Spielfeld = this;
            GegnerLogik.StarteGegnerGenerierung();

            WegLogik.ErstelleWegStueck(0, 4);
            WegLogik.ErstelleWegStueck(1, 4);
            WegLogik.ErstelleWegStueck(2, 4);
            WegLogik.ErstelleWegStueck(3, 4);
            WegLogik.ErstelleWegStueck(3, 3);
            WegLogik.ErstelleWegStueck(4, 3);
            WegLogik.ErstelleWegStueck(5, 3);
            WegLogik.ErstelleWegStueck(6, 3);
            WegLogik.ErstelleWegStueck(6, 4);
            WegLogik.ErstelleWegStueck(6, 5);
            WegLogik.ErstelleWegStueck(7, 5);
            WegLogik.ErstelleWegStueck(8, 5);
            WegLogik.ErstelleWegStueck(9, 5);
            WegLogik.ErstelleWegStueck(9, 6);
            WegLogik.ErstelleWegStueck(9, 7);
            WegLogik.ErstelleWegStueck(9, 8);
            WegLogik.ErstelleWegStueck(10, 8);
            WegLogik.ErstelleWegStueck(11, 8);
            WegLogik.ErstelleWegStueck(12, 8);
            WegLogik.ErstelleWegStueck(13, 8);
            WegLogik.ErstelleWegStueck(13, 7);
            WegLogik.ErstelleWegStueck(14, 7);
            WegLogik.ErstelleWegStueck(15, 7);


            MouseClick += Spielfeld_MouseClick;
        }

        void Spielfeld_MouseClick(object sender, MouseEventArgs e)
        {
            SpielfeldLogik.ReagiereAufMausklick(e.X, e.Y);
        }
    }
}
