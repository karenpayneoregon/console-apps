using McMaster.Extensions.CommandLineUtils;

namespace Greetings;

class Program
{
    public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

    [Option("-f|--first")]
    [Range(0, 10)]
    [Required]
    public int Arg1 { get;  }

    [Option("-s|--second")]
    [Range(10,20)]
    [Required]
    public int Arg2 { get; }

    [Option(ShortName = "t", LongName = "third")]
    [Required]
    public int Arg3 { get; }

    public void OnExecute()
    {

        Console.WriteLine($"Arg1: {Arg1} Arg2: {Arg2} Arg3: {Arg3}");
        Console.WriteLine(Arg1 + Arg2 + Arg3);

        Console.ReadLine();
    }


}