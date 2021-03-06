﻿using System;
using System.Linq;

namespace Pyatna
{
    public class ConsoleGameUI
    {
        public IPlayable game;
        public ConsoleGameUI(IPlayable game)
        {
            this.game = game;
        }
        
        public void Show()
        {
            for (int i = 0; i < game.GetLength(); i++)
                for (int j = 0; j < game.GetLength(); j++)
                    if (j != game.GetLength()-1)
                        Console.Write(game[j, i] + "	");
                    else
                    {
                        Console.WriteLine(game[j, i] + "	\n	\n");
                    }
        }
 
        public void GameShow()
        {
            Console.Clear();
            Console.WriteLine("ПЯТНАШКИ\n");
            Console.WriteLine("Введите число, которое вы хотите передвинуть");
            Console.WriteLine("Введите \"r\" или \"R\" для перемешивания\n");
            Show();
        }
        public void Shift()
        {
            while (true)
            {
                try
                {
                    Console.Write("\nПередвинуть: ");
                    string ourString = Console.ReadLine();
                    if (ourString == "r" | ourString == "R")
                        game.Randomize();
                    else
                    {
                        int number = Int32.Parse(ourString);
                        game.Shift(number);
                    }
                }
                catch (ArgumentException)
                {
                    GameShow();
                    Console.WriteLine("Введённое число невозможно передвинуть!");
                    continue;
                }
                catch (FormatException)
                {
                    GameShow();
                    Console.WriteLine("Введён не номер!");
                    continue;
                }
                catch (OverflowException)
                {
                    GameShow();
                    Console.WriteLine("Введённое число некорректно!");
                    continue;
                }
                break;
            }
        }
        public void StartGame()
        {
            game.Randomize();

            while (true)
            {
                GameShow();
                if (game.IsFinished())
                {
                    GameShow();
                    Console.WriteLine("╔══╗ ╔══╗ ╔═══╗ ╔═══╗  ╔══╗  ╔══╗ ╔╗╔╗╔╗");
                    Console.WriteLine("║╔╗║ ║╔╗║ ║╔══╝ ║╔══╝  ║╔╗║  ║╔╗║ ║║║║║║");
                    Console.WriteLine("║║║║ ║║║║ ║╚══╗ ║╚══╗  ║║║║  ║╚╝║ ║║║║║║");
                    Console.WriteLine("║║║║ ║║║║ ║╔═╗║ ║╔══╝  ║║║║  ║╔╗║ ╚╝╚╝╚╝");
                    Console.WriteLine("║║║║ ║╚╝║ ║╚═╝║ ║╚══╗ ╔╝╚╝╚╗ ║║║║ ╔╗╔╗╔╗");
                    Console.WriteLine("╚╝╚╝ ╚══╝ ╚═══╝ ╚═══╝ ╚════╝ ╚╝╚╝ ╚╝╚╝╚╝\n");
                    Console.WriteLine("Нажмите любую клавишу для выхода");
                    Console.ReadKey(true);
                    return;
                }
                Shift();
            }
        }
    }
}