namespace BitwiseExtensions.DemoConsole
{
    using static System.Console;
    using ConsoleTables;

    public class Program
    {
        public static void Main(string[] args)
        {
            new ConsoleTable("Bitwise operations Demo").Write(Format.Alternative);
            new ConsoleTable("Operation", "Arguments", "Result")
                .AddRow("Set bit 2", 0b0000000.ToBitString(), 0b0000000.SetBit(2).ToBitString())
                .AddRow("Unset bit 2", int.MaxValue.ToBitString(), int.MaxValue.UnsetBit(2).ToBitString())
                .AddRow("Toggle bit 2", int.MaxValue.ToBitString(), int.MaxValue.ToggleBit(2).ToBitString())
                .Write();

            WriteLine();
        }
    }
}
