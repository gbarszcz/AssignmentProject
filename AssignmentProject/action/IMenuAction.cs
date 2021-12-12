using System.Collections.Generic;

namespace AssignmentProject.action
{
    public interface IMenuAction<in T>
    {
        IEnumerable<string> Result(T elements);
    }
}