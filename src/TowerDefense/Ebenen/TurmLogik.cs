using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TowerDefense.Models;
using TowerDefense.Logic;

namespace TowerDefense.Ebenen
{
    public class TurmLogik
    {
        static List<Turm> ListeAllerTuerme = new List<Turm>();

        internal static void ErstelleTurm(int xFeldIdx, int yFeldIdx)
        {
            if (!SpielfeldLogik.IstFeldIdxBlockiert(xFeldIdx, yFeldIdx))
            {
                Turm turm = new Turm() { BackColor = Color.Transparent };
                turm.Location = SpielfeldLogik.FeldIndexInKoordinateKonvertieren(xFeldIdx, yFeldIdx);

                ListeAllerTuerme.Add(turm);
                SpielfeldLogik.ErstelleEinheit(turm);

                // Jeder Turm erstellt sofort auch einen Schuss.
                // [MB]
                Schuss schuss = new Schuss(turm) { BackColor = Color.Transparent };
                schuss.Location = turm.Location;

                SpielfeldLogik.ErstelleEinheit(schuss);
            }
        }
    }
}
