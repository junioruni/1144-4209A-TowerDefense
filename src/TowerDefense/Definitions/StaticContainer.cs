using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TowerDefense.Ebenen;
using TowerDefense.Models;

namespace TowerDefense.Definitions
{
    public class StaticContainer
    {
        public static int SpielFeldBreite { get; set; }
        public static int SpielFeldHoehe { get; set; }

        public static int EinzelFeldBreite { get; set; }
        public static int EinzelFeldHoehe { get; set; }

        public static Spielfeld Spielfeld { get; set; }
    }
}
