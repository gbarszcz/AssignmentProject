using System;
using System.Threading;
using AssignmentProject.console;

namespace AssignmentProject.drawers
{
    public class ErrorMessage : IConsoleDrawer
    {
        private readonly string _errorMessage;
        private const int ErrorBlinks = 3;

        public ErrorMessage(string errorMessage)
        {
            _errorMessage = errorMessage;
        }
        
        public void Draw()
        {
            Console.Beep(1600, 200);
            for (var i = 0; i < ErrorBlinks; i++)
            {
                ShowMessageWithColors(ConsoleColor.Red, ConsoleColor.White);
                ShowMessageWithColors(ConsoleColor.White, ConsoleColor.Red);
                ShowMessageWithColors(ConsoleColor.Black, ConsoleColor.White);
            }
        }
        
        private void ShowMessageWithColors(ConsoleColor backgroundColor, ConsoleColor foregroundColor)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.Clear();
            Console.CursorTop = ConsolePosition.CenterY;
            Console.CursorLeft = ConsolePosition.CenterX - _errorMessage.Length / 2 - 1;
            Console.Write(_errorMessage);
            Thread.Sleep(200);
        }
    }
}