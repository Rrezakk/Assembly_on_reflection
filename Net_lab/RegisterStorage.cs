namespace Net_lab;

public class RegisterStorage
{
    private readonly List<Register> _registers;
    //private readonly Register _voidRegister = new Register("void");
    public RegisterStorage()
    {
        _registers = new List<Register>()
        {
            new Register("ax"),
            new Register("bx"),
            new Register("cx"),
            new Register("dx"),
        };
    }
    public Register? GetRegisterByName(string name)
    {
        return _registers.FirstOrDefault(x => x.Name == name/*,_voidRegister*/);
    }
}
