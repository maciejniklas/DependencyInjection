﻿using EasyConsole;
using System;

namespace DependencyInjectionProject.UI
{
    internal sealed class Exit : Page
    {
        public Exit(Program program) : base("Exit", program) { }

        public override void Display()
        {
            Console.WriteLine(
@"  ____                 _   _                
 / ___| ___   ___   __| | | |__  _   _  ___ 
| |  _ / _ \ / _ \ / _` | | '_ \| | | |/ _ \
| |_| | (_) | (_) | (_| | | |_) | |_| |  __/
 \____|\___/ \___/ \__,_| |_.__/ \__, |\___|
                                 |___/      ");

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
