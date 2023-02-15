namespace BasicInterface;

public interface IAssemblyCommand
{
    string Name { get; }
    int Arity { get; }
    void Execute(string[] args);
}
