using System;

namespace AssignmentProject.drawers.inputs
{
    public class MenuInputHandler : IInputHandler
    {
        private const int MinPosition = 0;
        public int Position { get; private set; }
        private int MaxPosition { get; }
        private readonly ErrorMessage _errorMessage = new ErrorMessage("Niepoprawny klawisz");

        public MenuInputHandler(int elementsCount)
        {
            MaxPosition = elementsCount - 1;
            Position = 0;
        }

        public void HandleInput(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    Position -= 1;
                    if (Position < MinPosition) Position = MinPosition;
                    break;
                case ConsoleKey.DownArrow:
                    Position += 1;
                    if (Position > MaxPosition) Position = MaxPosition;
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    _errorMessage.Draw();
                    break;
            }
        }
        
    }
}