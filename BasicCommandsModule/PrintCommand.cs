using BasicInterface;

namespace BasicCommandsModule;

public class PrintCommand:IAssemblyCommand
{

    public string Name { get; } = "print";
    public int Arity { get; } = 1;
    public void Execute(string[] args)
    {
        //get from variables)))
        //Console.WriteLine($"print: {args.FirstOrDefault("empty")}");
        throw new NotImplementedException();
    }
}
