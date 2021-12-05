using System;
using System.Collections.Generic;
using System.Linq;
using AssignmentProject.console;
using AssignmentProject.drawers.inputs;

namespace AssignmentProject.drawers
{
    public class Menu : IConsoleDrawer
    {
        private IInputHandler MenuInputHandler { get; }
        private List<string> Elements { get; }
        private int MaxWidth { get; }
        private static ConsoleColor DefaultBackground => ConsoleColor.Black;
        private static ConsoleColor DefaultForeground => ConsoleColor.White;

        public Menu(List<string> elements)
        {
            Elements = elements;
            MenuInputHandler = new MenuInputHandler(Elements.Count);
            MaxWidth = elements.Max(s => s.Length);
        }

        public void Draw()
        {
            Console.Clear();
            Console.BackgroundColor = DefaultBackground;
            Console.ForegroundColor = DefaultForeground;
            Console.CursorVisible = false;
            var leftBorder = ConsolePosition.CenterX - MaxWidth / 2 - 1;
            var firstElementY = ConsolePosition.CenterY - Elements.Count / 2;

            //menu start
            SetCursorToPosition(leftBorder, firstElementY - 1);
            DrawMenuStart(MaxWidth);
            DrawElements(leftBorder, MaxWidth, firstElementY);
            //menu end
            SetCursorToPosition(leftBorder, firstElementY + Elements.Count);
            DrawMenuEnd(MaxWidth);
            //first element
            SetCursorToPosition(0, firstElementY + MenuInputHandler.Position);
        }

        private static void SetCursorToPosition(int leftBorder, int elementY)
        {
            Console.CursorLeft = leftBorder;
            Console.CursorTop = elementY;
        }
        
        private void DrawMenuStart(int width)
        {
            Console.Write('╔');
            for (var i = 0; i < width; i++) Console.Write('═');
            Console.Write('╗');
        }
        
        private void DrawMenuEnd(int width)
        {
            Console.Write('╚'); 
            for (var i = 0; i < width; i++) Console.Write('═');
            Console.Write('╝');
        }
        
        private void DrawElements(int leftBorder, int maxWidth, int firstElementY)
        {
            var rightBorder = leftBorder + maxWidth + 1;
            for (var i = 0; i < Elements.Count; i++)
            {
                DrawVerticalBorder(leftBorder, firstElementY + i);
                Console.CursorLeft = ConsolePosition.CenterX - Elements[i].Length/2;
                if (i == MenuInputHandler.Position)
                {
                    Console.BackgroundColor = DefaultForeground;
                    Console.ForegroundColor = DefaultBackground;
                }
                Console.Write(Elements[i]);
                Console.ResetColor();
                DrawVerticalBorder(rightBorder, Console.CursorTop);
            }
        }

        private void DrawVerticalBorder(int leftBorder, int topBorder)
        {
            Console.CursorLeft = leftBorder;
            Console.CursorTop = topBorder;
            Console.Write('║');
        }

        public void HandleInput(ConsoleKeyInfo keyInfo)
        {
            MenuInputHandler.HandleInput(keyInfo);
        }
    }
}