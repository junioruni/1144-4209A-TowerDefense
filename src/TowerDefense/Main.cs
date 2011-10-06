using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TowerDefense.Models;

namespace TowerDefense
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            Spielfeld spielfeld = new Spielfeld();

            Weg weg = new Weg();
            spielfeld.WegAbschnitte.Add(weg);            
        }
    }
}
