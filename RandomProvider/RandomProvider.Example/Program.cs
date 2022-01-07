using KMVUnion.RandomProvider.Example;
using System.Reflection;

string reportName = GetReportName();
#if (!DEBUG)
FileStream ostrm;
StreamWriter writer;
TextWriter oldOut = Console.Out;
string fileName = $".\\{reportName}.txt";

try
{
    ostrm = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
    writer = new StreamWriter(ostrm);
}
catch (Exception e)
{
    Console.WriteLine("Cannot open Redirect.txt for writing");
    Console.WriteLine(e.Message);
    return;
}
Console.SetOut(writer);
#endif

Console.WriteLine($"Examples: {reportName}");

PrintHelpers.PrintHeader(" String Randomizer Examples ");

StringRandomizerExamples.Example1();
StringRandomizerExamples.Example2();
StringRandomizerExamples.Example3();
StringRandomizerExamples.Example4();
StringRandomizerExamples.Example5();
StringRandomizerExamples.Example6();

Console.WriteLine();
PrintHelpers.PrintHeader(" Text Randomizer Examples ");
TextRandomizerExamples.Example1();
TextRandomizerExamples.Example2();
TextRandomizerExamples.Example3();
TextRandomizerExamples.Example4();
TextRandomizerExamples.Example5();
TextRandomizerExamples.Example6();
TextRandomizerExamples.Example7();
TextRandomizerExamples.Example8();
TextRandomizerExamples.Example9();
TextRandomizerExamples.Example10();
TextRandomizerExamples.Example11();
TextRandomizerExamples.Example12();

#if (!DEBUG)
Console.SetOut(oldOut);
writer.Close();
ostrm.Close();
var files = File.ReadAllLines(fileName);
files.ToList().ForEach(s => Console.WriteLine(s));
#endif

#if DEBUG
Console.ReadLine();
#endif


string GetReportName()
{
    return $"KMVUnion.RandomProvider_{DateTime.UtcNow:MM/dd/yyyy HH.mm.ss}";
}