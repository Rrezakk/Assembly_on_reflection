using BasicInterface;

namespace Net_lab;

public class ExecutionContext
{
    private readonly List<IAssemblyCommand> _assemblyCommands;
    private Script? _script;
    private readonly RegisterStorage _registerStorage;
    public ExecutionContext(List<IAssemblyCommand> assemblyCommands)
    {
        _assemblyCommands = assemblyCommands;
        _registerStorage = new RegisterStorage();
        foreach (var c in assemblyCommands)
        {
            c._registerStorage = _registerStorage;
        }
    }
    private bool LoadScript(string path)
    {
        try
        {
            var sr = new ScriptReader(path,_assemblyCommands);
            _script = new Script(sr);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unable to load script {path} : {e.Message}");
            return false;
        }
    }
    public bool ExecuteScript(string path)
    {
        try
        {
            var loaded = LoadScript(path);
            if (!loaded)
            {
                return false;
            }
            foreach (var command in _script.Commands)
            {
                command.AssemblyCommand.Execute(command.Arguments.ToArray());
            }
            _registerStorage.Flush();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error during script execution : {e.Message}");
            _registerStorage.Flush();
            return false;
        }
    }
}
