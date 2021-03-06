﻿using EasyConsole;
using System;

namespace DependencyInjectionProject.UI
{
    internal sealed class MainMenu : MenuPage
    {
        public MainMenu(Program program) : base("Main menu", program )
        {
            Menu.Add(new Option("Show all trees", () => program.NavigateTo<AllTrees>()));
            Menu.Add(new Option("Add tree", () => program.NavigateTo<AddTree>()));
            Menu.Add(new Option("Select tree", () => program.NavigateTo<SelectTree>()));
            Menu.Add(new Option("Exit", () => program.NavigateTo<Exit>()));
        }

        public override void Display()
        {
            Toolkit.SelectedTree = null;
            Console.WriteLine(
@" _____                         _       _        _                    
|_   _| __ ___  ___  ___    __| | __ _| |_ __ _| |__   __ _ ___  ___ 
  | || '__/ _ \/ _ \/ __|  / _` |/ _` | __/ _` | '_ \ / _` / __|/ _ \
  | || | |  __/  __/\__ \ | (_| | (_| | || (_| | |_) | (_| \__ \  __/
  |_||_|  \___|\___||___/  \__,_|\__,_|\__\__,_|_.__/ \__,_|___/\___|
                                                                     ");

            base.Display();

        }
    }
}
