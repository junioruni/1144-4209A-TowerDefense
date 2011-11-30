using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TowerDefense.Models;
using TowerDefense.Definitions;

namespace TowerDefense.Ebenen
{
    public class GegnerLogik
    {
        public static List<Gegner> ListeAllerGegner = new List<Gegner>();

        public static void StarteGegnerGenerierung()
        {
            Timer erstellungsTimer = new Timer() { Interval = 5000 };
            erstellungsTimer.Tick += ErstelleGegner;
            erstellungsTimer.Start();

            Timer bewegungsTimer = new Timer() { Interval = 1000 };
            bewegungsTimer.Tick += BewegeAlleGegner;
            bewegungsTimer.Start();
        }

        public static void ErstelleGegner(object sender, EventArgs e)
        {
            Gegner gegner = new Gegner();
            gegner.Location = WegLogik.HoleFeldAufBasisDesIndex(gegner.WegpunktIndex).Location;

            ListeAllerGegner.Add(gegner);
            SpielfeldLogik.ErstelleEinheit<Gegner>(gegner);
        }

        public static void BewegeAlleGegner(object sender, EventArgs e)
        {
            List<Gegner> zuEntfernendeGegner = new List<Gegner>();
            foreach (Gegner gegner in ListeAllerGegner)
            {
                if (gegner.Lebenspunkte <= 0)
                    zuEntfernendeGegner.Add(gegner);

                gegner.GeheZuNaechstemFeld();
            }

            foreach (var gegner in zuEntfernendeGegner)
            {
                ListeAllerGegner.Remove(gegner);
            }
        }
    }
}
