using System;

namespace AssignmentProject.drawers.inputs
{
    public interface IInputHandler
    {
        void HandleInput(ConsoleKeyInfo keyInfo);
        int Position { get; }
    }
}