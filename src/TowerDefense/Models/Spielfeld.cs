using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense.Models
{
    public class Spielfeld
    {        
        public List<Weg> WegAbschnitte { get; set; }

        public Spielfeld()
        {
            WegAbschnitte = new List<Weg>();
        }
    }
}
