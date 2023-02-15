namespace Net_lab;

public class RegisterStorage
{
    private readonly List<Register> _registers;
    public RegisterStorage()
    {
        _registers = new List<Register>()
        {
            new("ax"),
            new("bx"),
            new("cx"),
            new("dx"),
        };
    }

    public void Flush()
    {
        foreach (var r in _registers)
        {
            r.SetValue(0);
        }
    }
    public Register? GetRegisterByName(string name)
    {
        return _registers.FirstOrDefault(x => x.Name == name);
    }

    public bool IsRegisterName(string value)
    {
        return _registers.Exists(x => x.Name == value);
    }
}
