using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using TowerDefense.Models;
using TowerDefense.Definitions;

namespace TowerDefense.Ebenen
{
    public class WegLogik
    {
        static List<WegStueck> ListeAllerWegStuecke = new List<WegStueck>();
        
        public static void ErstelleWegStueck(int feldIdxX, int feldIdxY)
        {
            var wegStueck = new WegStueck() { Location = SpielfeldLogik.FeldIndexInKoordinateKonvertieren(feldIdxX, feldIdxY) };

            ListeAllerWegStuecke.Add(wegStueck);
            SpielfeldLogik.ErstelleEinheit<WegStueck>(wegStueck);
        }

        public static WegStueck HoleFeldAufBasisDesIndex(int listenIndex)
        {
            if ((listenIndex >= 0) && ((ListeAllerWegStuecke.Count - 1) >= listenIndex))
                return ListeAllerWegStuecke[listenIndex];

            return null;
        }
    }
}
