using BasicInterface;
using Net_lab;

namespace BasicCommandsModule;

public class AddCommand:IAssemblyCommand
{
    public string Name { get; } = "add";
    public int Arity { get; } = 2;
    public void Execute(string[] args)
    {
        var arg1 = args[0];
        var arg2 = args[1];
        if (!_registerStorage.IsRegisterName(arg1)) return;
        var r1 = _registerStorage.GetRegisterByName(arg1);
        if (_registerStorage.IsRegisterName(arg2))
        {
            var r2 = _registerStorage.GetRegisterByName(arg2);
            r1.SetValue(r1.Value+r2.Value);
        }
        else
        {
            r1.SetValue(r1.Value+int.Parse(arg2));
        }
    }

    public RegisterStorage _registerStorage { get; set; }
}
