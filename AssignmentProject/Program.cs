using System;
using System.Collections.Generic;
using AssignmentProject.drawers;

namespace AssignmentProject
{
    internal static class Program
    {
        private static readonly List<string> MenuElements = new List<string>
        {
            "123",
            "456",
            "2434324vcxvcx3",
            "123321",
            "1233213"
        };
        
        public static void Main(string[] args)
        {
            var menu = new Menu(MenuElements);

            while (true)
            {
                menu.Draw();
                var keyInfo = Console.ReadKey();
                menu.HandleInput(keyInfo);
            }
        }
    }
}