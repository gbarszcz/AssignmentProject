using AssignmentProject.action;

namespace AssignmentProject.model
{
    public class MenuElement<T>
    {
        public readonly string Label;
        public IMenuAction<T> MenuAction { get; }
        
        public MenuElement(string label, IMenuAction<T> menuAction = null)
        {
            Label = label;
            MenuAction = menuAction;
        }

    }
}