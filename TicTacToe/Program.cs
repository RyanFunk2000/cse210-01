using System;
using System.Collections.Generic;
using System.Linq;
namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define array for locations in grid.
            string[] gridPosition = new string[] {"0", "1", "2", "3", "4", "5", "6", "7", "8"};
            // Initialize tic-tac-toe 3x3 grid.
            displayGrid ();

            // Define variables for each player.
            string p1 = "X";
            string p2 = "O";
            string currentP = p1;
            string winner = "Nobody";
            // Define boolean variable to track when game is still being played.
            bool stillPlaying = true;
            // Define number variable to track number of turns.
            int turns = 0;

            // Loop through game while still playing.
            while (stillPlaying) {
                // Prompt a player to input where to mark.
                Console.WriteLine($"{currentP}'s turn to choose a square (0-8): ");
                int playerPosition = int.Parse(Console.ReadLine());

                // Update grid with player input.
                gridPosition[playerPosition] = currentP;
                // Output grid.
                displayGrid ();

                // Update number of turns.
                turns += 1;

                // Check grid if a player wins. End loop if players draw.
                checkGrid ();

                // Switch between players.
                if (currentP == p1) {
                    currentP = p2;
                }
                else {
                    currentP = p1;
                }
            }

            // After game finishes, state who won.
            Console.WriteLine($"{winner} won the game. Thanks for playing!");

            void displayGrid () {
                // Create strings for each row in grid.
                string row1 = $" {gridPosition[0]} | {gridPosition[1]} | {gridPosition[2]} ";
                string row2 = $" {gridPosition[3]} | {gridPosition[4]} | {gridPosition[5]} ";
                string row3 = $" {gridPosition[6]} | {gridPosition[7]} | {gridPosition[8]} ";

                // Create string for grid seperator.
                string seperatorLine = "---+---+---";
                // Output grid.
                Console.WriteLine(row1);
                Console.WriteLine(seperatorLine);
                Console.WriteLine(row2);
                Console.WriteLine(seperatorLine);
                Console.WriteLine(row3);
            }

            void checkGrid () {
                // If current player gets three in a row, declare them the winner and stop the game.
                if (gridPosition[0] == currentP && gridPosition[1] == currentP && gridPosition[2] == currentP ||
                    gridPosition[3] == currentP && gridPosition[4] == currentP && gridPosition[5] == currentP ||
                    gridPosition[6] == currentP && gridPosition[7] == currentP && gridPosition[8] == currentP ||
                    gridPosition[0] == currentP && gridPosition[3] == currentP && gridPosition[6] == currentP ||
                    gridPosition[1] == currentP && gridPosition[4] == currentP && gridPosition[7] == currentP ||
                    gridPosition[2] == currentP && gridPosition[5] == currentP && gridPosition[8] == currentP ||
                    gridPosition[0] == currentP && gridPosition[4] == currentP && gridPosition[8] == currentP ||
                    gridPosition[2] == currentP && gridPosition[4] == currentP && gridPosition[6] == currentP) {
                    winner = currentP;
                    stillPlaying = false;
                }
                // Otherwise, if all positions are filled, end the game in a draw.
                else if (turns == 9) {
                    stillPlaying = false;
                }
            }
            
        }
    }
}