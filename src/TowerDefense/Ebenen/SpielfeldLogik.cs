using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MS.Internal.Xml.XPath;
using TowerDefense.Definitions;
using System.Drawing;
using TowerDefense.Models;

namespace TowerDefense.Ebenen
{
    public class FeldInfo
    {
        public int XFeldIdx { get; set; }
        public int YFeldIdx { get; set; }
        public Type Type { get; set; }
    }

    public class SpielfeldLogik
    {
        public static List<FeldInfo> BlockierendeFeldRegistrierung = new List<FeldInfo>();

        public static void ErstelleEinheit<T>(T erstelltesObjekt) where T : PictureBox
        {
            if ((erstelltesObjekt is Turm) || (erstelltesObjekt is WegStueck))
            {
                var fieldIdx = KoordinateInFeldIndexKonvertieren(erstelltesObjekt.Left, erstelltesObjekt.Top);

                BlockierendeFeldRegistrierung.Add(new FeldInfo()
                {
                    Type = erstelltesObjekt.GetType(),
                    XFeldIdx = fieldIdx.X,
                    YFeldIdx = fieldIdx.Y
                });
            }

            StaticContainer.Spielfeld.Controls.Add(erstelltesObjekt);
            erstelltesObjekt.BringToFront();
        }

        public static bool IstFeldIdxBlockiert(int xFeldIdx, int yFeldIdx)
        {
            if (BlockierendeFeldRegistrierung != null)
            {
                return BlockierendeFeldRegistrierung.Any(bfr => ((bfr.XFeldIdx == xFeldIdx) && (bfr.YFeldIdx == yFeldIdx)));
            }

            return false;
        }

        public static Point FeldIndexInKoordinateKonvertieren(int xFeldIdx, int yFeldIdx)
        {
            return new Point()
            {
                X = xFeldIdx * StaticContainer.EinzelFeldBreite,
                Y = yFeldIdx * StaticContainer.EinzelFeldBreite
            };
        }

        public static Point KoordinateInFeldIndexKonvertieren(int koordX, int koordY)
        {
            return new Point()
            {
                X = (int)Math.Floor((double)koordX / StaticContainer.EinzelFeldBreite),
                Y = (int)Math.Floor((double)koordY / StaticContainer.EinzelFeldBreite)
            };
        }

        public static void ReagiereAufMausklick(int koordX, int koordY)
        {
            var feldIdxDesKlicks = KoordinateInFeldIndexKonvertieren(koordX, koordY);

            TurmLogik.ErstelleTurm(feldIdxDesKlicks.X, feldIdxDesKlicks.Y);
        }
    } 
}
