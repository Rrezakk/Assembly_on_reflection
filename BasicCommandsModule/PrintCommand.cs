using BasicInterface;
using Net_lab;

namespace BasicCommandsModule;

public class PrintCommand:IAssemblyCommand
{
    public string Name { get; } = "print";
    public int Arity { get; } = 1;
    public void Execute(string[] args)
    {
        var argument = args[0];
        if (_registerStorage.IsRegisterName(argument))
        {
            var value = _registerStorage?.GetRegisterByName(argument)?.Value??0;
            Console.WriteLine($"Print: {value}");
        }
        else
        {
            Console.WriteLine($"Print: {argument}");
        }
    }
    public RegisterStorage _registerStorage { get; set; }
}
