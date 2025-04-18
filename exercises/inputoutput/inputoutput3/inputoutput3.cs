//input output 3
using System;
using static System.Console;
using static System.Math;
using System.IO;

public class MainClass
{
    public static void Main(string[] args)
    {
        string infile = null, outfile = null;
        foreach (var arg in args){
            var words = arg.Split(':');
            if (words[0] == "-input") infile = words[1];
            if (words[0] == "-output") outfile = words[1];
        }
        if (infile == null || outfile == null){
            Error.WriteLine("Wrong filename argument");
            return;
        }
        var instream = new StreamReader(infile);
        var outstream = new StreamWriter(outfile, append: false);
        for (string line = instream.ReadLine(); line != null; line = instream.ReadLine()){
            if (double.TryParse(line, out double x)){
                outstream.WriteLine($"{x} {Sin(x)} {Cos(x)}");
            }
            else{
                Error.WriteLine($"Invalid input: {line}");
            }
        }
        instream.Close();
        outstream.Close();
    }
}