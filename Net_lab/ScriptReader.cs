using System.Diagnostics;
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
    public List<PrepairedAssemblyCommand> Read()
    {
        var finalCommands = new List<PrepairedAssemblyCommand>();
        var filledAssemblyCommands = GetLines(_path);
        foreach (var command in filledAssemblyCommands)
        {
            var cc = _assemblyCommands.FirstOrDefault(x => x.Name == command.Name);
            if (cc == null || command.Arity != cc.Arity)
            {
                Console.WriteLine($"Error during parsing command: {command.Name} {string.Join(' ',command.Arguments)}");
                continue;
            }
            var c = new PrepairedAssemblyCommand()
            {
                Arguments = command.Arguments,
                AssemblyCommand = cc,
            };
            finalCommands.Add(c);
        }

        return finalCommands;
    }
    private List<FilledAssemblyCommand> GetLines(string path)
    {
        var result = new List<FilledAssemblyCommand>();
        var lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            var elems = line.Split(' ').ToList();
            elems = elems.Where(x=>!string.IsNullOrEmpty(x)).Select(x => x.Trim(',', ' ')).ToList();
            var fc = new FilledAssemblyCommand()
            {
                Name = elems.FirstOrDefault(""),
                Arity = elems.Count-1,
                Arguments = elems.Skip(1).ToList()
            };
            result.Add(fc);
        }
        return result;
    }
}
