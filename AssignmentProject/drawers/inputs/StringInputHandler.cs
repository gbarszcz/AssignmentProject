using System;
using System.Collections.Generic;
using AssignmentProject.model;

namespace AssignmentProject.drawers.inputs
{
    public class StringInputHandler : IInputHandler<string>
    {
        public int Position { get; }
        public ConsoleKey EscapeKey => ConsoleKey.Escape;
        private readonly ErrorMessage _errorMessage = new ErrorMessage("Niepoprawny klawisz");
        public StringInputHandler()
        {
            Position = 0;
        }
        public void HandleInput(ConsoleKeyInfo keyInfo, List<MenuElement<string>> input, string data)
        {
            if (keyInfo.Key != EscapeKey)
            {
                _errorMessage.Draw();
            }
        }
    }
}