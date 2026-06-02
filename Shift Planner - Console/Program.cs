using Shift_Planner___Console.Classes;
using System;

Console.WriteLine("Shift Planner - V1.0 (Made by Daniel Martin)");

bool isRunning = true;
MainMenu menu = new MainMenu();

while (isRunning)
{
    menu.DisplayMenu();
    menu.GetUserInput();
}