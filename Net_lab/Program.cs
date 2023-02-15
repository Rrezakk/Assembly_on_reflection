using BasicInterface;
using System.Reflection;
var folder = Directory.GetCurrentDirectory() + "\\Modules\\";
if (!Directory.Exists(folder))
    Directory.CreateDirectory(folder);

var assemblyCommands = LoadAssemblyCommands(folder);
Console.WriteLine("Loaded commands: ");
foreach (var command in assemblyCommands)
{
    Console.WriteLine($"Command: {command.Name} Arity: {command.Arity}");
}
Console.WriteLine("-----------------------------------------------------------------------------");
var ex = new Net_lab.ExecutionContext(assemblyCommands);
while (true)
{
    Console.Write($"Enter script path: ");
    var path = Console.ReadLine();
    path = path.Trim('"');
    if (string.IsNullOrEmpty(path))
    {
        Console.WriteLine($"Path must be non-empty");
        continue;
    }
    var result = ex.ExecuteScript(path);
    Console.WriteLine(result?"Executed successfully":"There was some errors during execution");
}
List<IAssemblyCommand> LoadAssemblyCommands(string dllsFolder)
{
    var result = new List<IAssemblyCommand>();
    var files = Directory.GetFiles(dllsFolder, "*.dll");
    foreach (var file in files)
    {
        try
        {
            var assembly = Assembly.LoadFile(file);
            foreach (var type in assembly.GetTypes())
            {
                var commandInterface = type.GetInterface("BasicInterface.IAssemblyCommand");
                if (null == commandInterface) continue;
                var obj = (IAssemblyCommand?)Activator.CreateInstance(type);
                if (obj != null) result.Add(obj);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading module: {e.Message}");
        }
    }
    return result;
}