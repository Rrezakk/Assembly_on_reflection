using Net_lab;

namespace BasicInterface;

public interface IAssemblyCommand
{
    string Name { get; }
    int Arity { get; }
    void Execute(string[] args);
    RegisterStorage _registerStorage { get; set; }
}
