using BasicInterface;

namespace Net_lab;

public class PrepairedAssemblyCommand
{
    public IAssemblyCommand AssemblyCommand { get; set; }
    public List<string> Arguments { get; set; }
}