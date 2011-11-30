using System.Windows.Forms;
using TowerDefense.Models;

namespace TowerDefense
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            Width = 1000;
            Height = 800;

            // Spielfeld erstellen und die Größe des Formulars übergeben.
            // [MB]
            Spielfeld spielfeld = new Spielfeld(Width, Height);

            // Spielfeld auf dem Formular anzeigen.
            // [PP]
            Controls.Add(spielfeld);
        }
    }
}
