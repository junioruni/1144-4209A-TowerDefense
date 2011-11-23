using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TowerDefense.Models
{
    public class Weg
    {
        Control.ControlCollection SpielFeldControls { get; set; }
        int FeldBreite { get; set; }
        int FeldHoehe { get; set; }

        int LetzteXKoordinate { get; set; }
        int LetzteYKoordinate { get; set; }

        List<FieldInfo> ListeAllerFelder { get; set; }

        public Weg(
            Control.ControlCollection spielfeldControls, 
            int feldBreite, 
            int feldHoehe, 
            int startfeldX, 
            int startfeldY)
        {
            SpielFeldControls = spielfeldControls;
            FeldBreite = feldBreite;
            FeldHoehe = feldHoehe;

            ListeAllerFelder = new List<FieldInfo>();

            ErstelleWegStueck(startfeldX, startfeldY);
        }

        public void FeldZumWegHinzufuegen(int distanzX, int distanzY)
        {
            int xKoordDesNeuenFeldes = LetzteXKoordinate + distanzX;
            int yKoordDesNeuenFeldes = LetzteYKoordinate + distanzY;

            ErstelleWegStueck(xKoordDesNeuenFeldes, yKoordDesNeuenFeldes);
        }

        void ErstelleWegStueck(int neuesFeldX, int neuesFeldY)
        {
            ListeAllerFelder.Add(new FieldInfo()
            {
                XCoord = neuesFeldX,
                YCoord = neuesFeldY
            });

            SpielFeldControls.Add(
                new WegStueck
                    {
                        Top = FeldHoehe*neuesFeldY,
                        Left = FeldBreite*neuesFeldX
                    });

            LetzteXKoordinate = neuesFeldX;
            LetzteYKoordinate = neuesFeldY;
        }

        public Point GetNextFieldToMove()
        {
            return GetNextFieldToMove(0);
        }

        public Point GetNextFieldToMove(int listenIndex)
        {
            if  (listenIndex < 0 ||
                (ListeAllerFelder.Count - 1) < listenIndex)
            {
                listenIndex = 0;
            }

            var cur = ListeAllerFelder[listenIndex];

            return new Point
            {
                X = cur.XCoord * FeldBreite,
                Y = cur.YCoord * FeldHoehe
            };
        }
    }

    public class FieldInfo
    {
        public int XCoord { get; set; }
        public int YCoord { get; set; }
    }
}
