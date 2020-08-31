using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            LoadButtons();
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

        int flag = 0;

        int counter = 0;


        private void Button_Click(object sender, EventArgs e)
        {
            var button = (Button)sender; // find which button was clicked
            currentPlayer = Player.X; // set the player to X
            button.Content = currentPlayer.ToString(); // change the button text to player X
            button.IsEnabled = false; // disable the button
            button.Background = Brushes.White; // change the player colour to Cyan
            button.Foreground = Brushes.DarkBlue;
            buttons.Remove(button); //remove the button from the list buttons so the AI can't click it either
            Check(); // check if the player won
            AImove(); // start the AI timer
        }
        private void AImove()
        {
            // While the array is greater than 0 the cpu will operate in the game
            // if the array is less than 0 it will stop playing
            if (buttons.Count > 0)
            {
                int index = rand.Next(buttons.Count); // generate a random number within the number of buttons available
                buttons[index].IsEnabled = false; // assign the number to the button
                                                  // when the random number is generated then we will look into the list
                                                  // for what that number is we select that button
                                                  // for example if the number is 8
                                                  // then we select the 8th button in the list
                currentPlayer = Player.O; // set the AI with O
                buttons[index].Content = currentPlayer.ToString(); // show O on the button
                buttons[index].Background = Brushes.White; // change the background of the button dark salmon colour
                buttons[index].Foreground = Brushes.Red;
                buttons.RemoveAt(index); // remove that button from the list
                Check(); // check if the AI won anything
                //AImoves.Stop(); // stop the AI timer
            }
        }
        private void LoadButtons()
        {
            // this the custom function which will load all the buttons 
            // from the form to the buttons list
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6,
            button7, button8, button9 };
        }

        private void Check()
        {
            counter++;
            //in this function we will check if the player or the AI has won
            // we have two very large if statements with the winning possibilities
            if (button1.Content.Equals("X") && button2.Content.Equals("X") && button3.Content.Equals("X")
            || button4.Content.Equals("X") && button5.Content.Equals("X") && button6.Content.Equals("X")
            || button7.Content.Equals("X") && button9.Content.Equals("X") && button8.Content.Equals("X")
            || button1.Content.Equals("X") && button4.Content.Equals("X") && button7.Content.Equals("X")
            || button2.Content.Equals("X") && button5.Content.Equals("X") && button8.Content.Equals("X")
            || button3.Content.Equals("X") && button6.Content.Equals("X") && button9.Content.Equals("X")
            || button1.Content.Equals("X") && button5.Content.Equals("X") && button9.Content.Equals("X")
            || button3.Content.Equals("X") && button5.Content.Equals("X") && button7.Content.Equals("X"))
            {
                // if any of the above conditions are met
                //AImoves.Stop(); //stop the timer
                flag = 1;
                MessageBox.Show("Player Wins"); // show a message to the player
                playerWins++; // increase the player wins
                tb2.Text = "Player Wins: " + playerWins.ToString();
                //label1.Text = "Player Wins- " + playerWins; // update player label
                resetGame(); // run the reset game function
            }
            // below if statement is for when the AI wins the game
            else if (button1.Content.Equals("O") && button2.Content.Equals("O") && button3.Content.Equals("O")
            || button4.Content.Equals("O") && button5.Content.Equals("O") && button6.Content.Equals("O")
            || button7.Content.Equals("O") && button9.Content.Equals("O") && button8.Content.Equals("O")
            || button1.Content.Equals("O") && button4.Content.Equals("O") && button7.Content.Equals("O")
            || button2.Content.Equals("O") && button5.Content.Equals("O") && button8.Content.Equals("O")
            || button3.Content.Equals("O") && button6.Content.Equals("O") && button9.Content.Equals("O")
            || button1.Content.Equals("O") && button5.Content.Equals("O") && button9.Content.Equals("O")
            || button3.Content.Equals("O") && button5.Content.Equals("O") && button7.Content.Equals("O"))
            {
                // if any of the conditions are met above then we will do the following
                // this code will run when the AI wins the game
                //AImoves.Stop(); // stop the timer
                flag = 1;
                MessageBox.Show("Computer Wins"); // show a message box to say computer won
                computerWins++; // increase the computer wins score number
                tb1.Text = "Computer Wins: " + computerWins.ToString();
                resetGame(); // run the reset game
            }
            if (flag == 1 || counter == 9)
            {
                flag = 0;
                counter = 0;
                resetGame();
            }
        }
        private void resetGame()
        {
            //check each of the button with a tag of play
            foreach (Button X in buttons)
            {
                if (X is Button)
                {
                    X.IsEnabled = true; // change them all back to enabled or clickable
                    X.Content = "?"; // set the text to question mark
                    X.Background = Brushes.LightCyan; // change the background colour to default button colors
                    X.Foreground = Brushes.DarkCyan;
                }
            }
            LoadButtons(); // run the load buttons function so all the buttons are inserted back in the array
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            resetGame();
            resetGame();
        }
    }
}
