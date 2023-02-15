namespace Net_lab;

public class Register
{
    public string Name { get; }
    public int Value { get; private set; }
    public void SetValue(int value)
    {
        this.Value = value;
    }
    public void AddValue(int add)
    {
        Value += add;
    }
    public Register(string name)
    {
        Name = name;
        Value = 0;
    }
}
