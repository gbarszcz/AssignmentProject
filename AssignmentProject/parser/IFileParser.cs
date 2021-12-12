namespace AssignmentProject.parser
{
    public interface IFileParser<out T>
    {
        T Parse(string filePath);
    }
}