using System;
using System.Windows.Forms;
using TowerDefense.Ebenen;

namespace TowerDefense.Models
{
    public class Gegner : PictureBox
    {
        public bool AnimationBlocked = true;
        public int WegpunktIndex { get; set; }
        public int Lebenspunkte = 50;

        public Gegner()
        {
            Width = 60;
            Height = 60;

            ImageLocation =
                Environment.CurrentDirectory + @"\Images\Enemy.png";

            AktualisiereAnzeige();
        }

        internal void GeheZuNaechstemFeld()
        {
            if (AnimationBlocked)
            {
                AnimationBlocked = false;
            }
            else
            {
                WegpunktIndex++;

                AktualisiereAnzeige();
            }
        }

        private void AktualisiereAnzeige()
        {
            var wegStueck = WegLogik.HoleFeldAufBasisDesIndex(WegpunktIndex);

            if (wegStueck != null)
            {
                Left = wegStueck.Left;
                Top = wegStueck.Top;
            }
            else
            {
                this.Visible = false;
            }
        }

        internal void BehandleTreffer()
        {
            Lebenspunkte -= 10;
   
            if (Lebenspunkte <= 0)
                Visible = false;
        }
    }
}
