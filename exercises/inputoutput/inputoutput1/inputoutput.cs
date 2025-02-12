//input output 1
using static System.Console;
using static System.Math;

public class main{
    public static void Main(string[] args){
    foreach(var arg in args){
	    var words = arg.Split(':');
	    if(words[0]=="-numbers"){
		    var numbers=words[1].Split(',');
		    foreach(var number in numbers){
			    double x = double.Parse(number);
			    WriteLine($"{x} {Sin(x)} {Cos(x)}");
			    }
		    }
	    }
    }

}