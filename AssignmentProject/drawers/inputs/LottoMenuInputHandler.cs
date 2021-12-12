using System;
using System.Collections.Generic;
using System.Linq;
using AssignmentProject.model;

namespace AssignmentProject.drawers.inputs
{
    public class LottoMenuInputHandler : IInputHandler<LottoResult>
    {
        private const int MinPosition = 0;
        public int Position { get; private set; }
        private int MaxPosition { get; }
        private readonly ErrorMessage _errorMessage = new ErrorMessage("Niepoprawny klawisz");
        public ConsoleKey EscapeKey => ConsoleKey.Escape;
        private readonly Action _escapeAction;

        public LottoMenuInputHandler(int elementsCount, Action escapeAction = null)
        {
            MaxPosition = elementsCount - 1;
            Position = 0;
            _escapeAction = escapeAction;
        }

        public void HandleInput(ConsoleKeyInfo keyInfo, List<MenuElement<LottoResult>> menuElements, LottoResult data)
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
                    _escapeAction.Invoke();
                    break;
                case ConsoleKey.Enter:
                    var menuElement = menuElements[Position];
                    var menuElementFunc = menuElement.MenuAction.Result(data).Select(e => new MenuElement<string>(e)).ToList();
                    var stringInputHandler = new StringInputHandler();
                    var menu = new Menu<string>(menuElementFunc, null, stringInputHandler);
                    ConsoleKeyInfo internalKeyInfo = default;
                    while (internalKeyInfo.Key != stringInputHandler.EscapeKey)
                    {
                        menu.Draw();
                        internalKeyInfo = Console.ReadKey();
                        menu.HandleInput(internalKeyInfo);
                    }
                    break;
                default:
                    _errorMessage.Draw();
                    break;
            }
        }
        
    }
}