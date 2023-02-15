using BasicInterface;

namespace Net_lab;

public class Script
{
    public List<IAssemblyCommand> Commands;
    public Script(ScriptReader reader)
    {
        Commands = reader.Read();
    }
}
