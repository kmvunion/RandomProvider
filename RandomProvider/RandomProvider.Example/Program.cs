using KMVUnion.RandomProvider.Example;

#if (!DEBUG)
FileStream ostrm;
StreamWriter writer;
TextWriter oldOut = Console.Out;
string fileName = @".\console_234.txt";

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

PrintHelpers.PrintHeader(" String Randomizer Examples ");

StringRandomizerExamples.Example1();
StringRandomizerExamples.Example2();
StringRandomizerExamples.Example3();
StringRandomizerExamples.Example4();

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