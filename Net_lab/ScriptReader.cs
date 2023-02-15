using BasicInterface;

namespace Net_lab;

public class ScriptReader
{
    private readonly string _path;
    private readonly List<IAssemblyCommand> _assemblyCommands;
    public ScriptReader(string path,List<IAssemblyCommand> assemblyCommands)
    {
        _path = path;
        _assemblyCommands = assemblyCommands;
    }
    public List<IAssemblyCommand> Read()
    {
        throw new NotImplementedException();
    }
}
