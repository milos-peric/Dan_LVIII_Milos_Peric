using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dan_LVIII_Milos_Peric
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        // below is the player enum which has two value
        // X and O
        public enum Player
        {
            X, O
        }

        // calling the player class
        Player currentPlayer;

        // creating a LIST of array of buttons
        List<Button> buttons;

        // importing the random number generator class
        Random rand = new Random();

        // set the player win integer to 0
        int playerWins = 0;

        // set the computer win integer to 0
        int computerWins = 0;



    }
}
