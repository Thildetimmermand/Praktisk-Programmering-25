//mainerf.cs

class main{

public static int Main(){
	for(double x=-5;x<=5;x+=1.0/128){
		System.Console.WriteLine($"{x.ToString(System.Globalization.CultureInfo.InvariantCulture)} {sfuns.erf(x).ToString(System.Globalization.CultureInfo.InvariantCulture)}");
		}
	System.Console.WriteLine();
	System.Console.WriteLine();
	double dx=1.0/64;
return 0;
}

}