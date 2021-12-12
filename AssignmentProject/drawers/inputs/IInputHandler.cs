using System;
using System.Collections.Generic;
using AssignmentProject.model;

namespace AssignmentProject.drawers.inputs
{
    public interface IInputHandler<T>
    {
        void HandleInput(ConsoleKeyInfo keyInfo, List<MenuElement<T>> input, T data);
        int Position { get; }
        
        ConsoleKey EscapeKey { get; }
    }
}