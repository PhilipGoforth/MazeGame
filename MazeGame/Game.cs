﻿using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace MazeGame
{
    class Game
    {
        private World MyWorld;
        private Player CurrentPlayer;
        public void Start()
        {
            Title = "Maze Game";
            CursorVisible = false;

            string[,] grid =
            {
                { "█", "▀", "█", "▀", "█", "▀", "█", "▀", "█", "▀", "█", "▀", "█", "▀", "▀", "▀", "█", "▀", "█", "▀", "▀", "▀", "█", "▀", "█", "▀", "▀", "▀", "▀", "▀", "▀", "▀", "█", "▀", "█", "▀", "▀", "▀", "█"},
                { " ", " ", "█", " ", " ", " ", "█", " ", "█", " ", " ", " ", "█", " ", "█", " ", "█", " ", "█", " ", " ", " ", "█", " ", " ", " ", "█", " ", " ", " ", " ", " ", " ", " ", "█", " ", " ", " ", "█"},
                { "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", "█", "█", "█", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", "█", " ", " ", " ", "█", "█", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", " ", " ", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", " ", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", "█", "█", "█", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", "█", "█", "█", " ", "█", " ", "█", " ", " ", " ", "█", " ", "█", " ", " ", "█", " ", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", " ", " ", "█", " ", "█"},
                { "█", " ", " ", " ", " ", " ", "█", " ", "█", " ", "█", "█", "█", " ", " ", " ", " ", " ", " ", "█", " ", "█", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", "█", "█", " ", "█", " ", "█", " ", " ", " ", "█", "█", "█", "█", "█", "█", " ", "█", " ", "█", " ", " ", "█", " ", "█", " ", "█", " ", "█", "X", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", " ", " ", " ", " ", " ", " ", " ", "█", " ", "█", " ", "█", "█", " ", "█", " ", " ", " ", "█", "█", "█", "█", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", " ", " ", "█", " ", "█", " ", "█", "█", "█", "█", "█", "█", "█", "█", " ", "█", " ", "█", " ", "█", "█", " ", "█", " ", "█", " ", "█", " ", " ", " ", "█", "█", "█", " ", "█"},
                { "█", " ", "█", " ", "█", "█", "█", " ", "█", " ", "█", " ", "█", " ", " ", " ", " ", "█", " ", "█", " ", "█", " ", " ", "█", " ", "█", "█", "█", "█", "█", " ", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", "█", "█", "█", " ", "█", " ", " ", " ", " ", "█", " ", " ", " ", " ", " ", " ", " ", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", " ", " ", "█", " ", "█", " ", " ", " ", "█", " ", "█", " ", " ", " ", " ", "█", " ", " ", " ", "█", "█", "█", "█", "█", " ", "█", "█", "█", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", "█", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", "█", " ", "█", "█", "█", " ", "█", " ", "█", " ", "█", " ", "█", "█", " ", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", " ", " ", "█", " ", " ", " ", "█", " ", "█", " ", " ", " ", "█", "█", " ", " ", "█", "█", " ", "█", " ", "█", " ", "█", " ", "█", "█", " ", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", "█", " ", "█", "█", "█", " ", "█", " ", "█", " ", "█", " ", "█", "█", "█", " ", "█", " ", "█", "█", " ", "█", " ", "█", " ", "█", "█", " ", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", " ", " ", "█", " ", "█", " ", "█", "█", " ", "█", " ", " ", " ", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", "█", "█", " ", "█", " ", "█", " ", "█", "█", " ", "█", " ", "█", " ", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", " ", " ", " ", "█", " ", "█", " ", "█", " ", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", " ", " ", "█", " ", "█", " ", "█", "█", " ", "█", " ", "█", " ", "█", "█", " ", "█", " ", "█", " ", " ", " ", "█", " ", "█"},
                { "█", " ", " ", " ", "█", " ", " ", " ", "█", " ", "█", " ", "█", " ", " ", " ", "█", " ", "█", " ", "█", "█", " ", "█", " ", "█", " ", "█", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", " ", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", "█", " ", " ", " ", "█", " ", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", "█", "█", " ", "█", " ", "█", "█", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", "█", " ", "█", " ", "█", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", " ", "█", " ", "█", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", "█", "█", " ", "█", " ", "█", " ", "█", " ", " ", "█", " ", "█", " ", " ", "█", " ", "█", " ", "█", "█", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", "█", " ", "█", " ", "█", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", " ", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█", "█", " ", " ", " ", "█", " ", " ", "█", " ", "█", " ", "█", " ", "█", " ", "█"},
                { "█", " ", "█", " ", "█", " ", "█", " ", " ", " ", "█", " ", " ", " ", "█", " ", " ", " ", " ", " ", "█", " ", " ", "█", " ", "█", " ", "█", " ", " ", "█", " ", " ", " ", "█", " ", " ", " ", "█"},
                { "█", "▄", "█", "▄", "█", "▄", "█", "▄", "█", "▄", "█", "▄", "█", "▄", "█", "▄", "▄", "▄", "▄", "▄", "█", "▄", "▄", "█", "▄", "█", "▄", "█", "▄", "▄", "█", "▄", "▄", "▄", "█", "▄", "▄", "▄", "█"},
            };
            MyWorld = new World(grid);
            


            CurrentPlayer = new Player(0, 1);
            

            RunGameLoop();
        }
        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
                switch (key)
            {
                case ConsoleKey.UpArrow:
                    if(MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y-1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                    
                    break;
                default:
                    break;
            }
        }
        private void DrawFrame()
        {
            Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();

        }
        private void DisplayIntro()
        {

        }
        private void DisplayOutro()
        {

        }
        private void RunGameLoop()
        {
            DisplayIntro();
            while (true)
            {
                //Draw everything
                DrawFrame();
                //Check for player input and move
                HandlePlayerInput();
                //Check if player has reached exit
                string elementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if(elementAtPlayerPos == "X")
                {
                    break;
                }

                //render
                System.Threading.Thread.Sleep(20);
            }
            DisplayOutro();
        }
    }

}
