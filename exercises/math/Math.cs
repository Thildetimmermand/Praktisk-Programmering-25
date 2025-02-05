using System;
using static System.Console;
using static System.Math;
class main{
	static int Main(){
		double sqrt2 = Sqrt(2);
		double pwer215 = Pow(2, 1.0/5);
		double epi = Exp(PI);
		double pie = Pow(PI, E);

		WriteLine($"sqrt2 = {sqrt2}\n");
		WriteLine($"sqrt2^2 = {sqrt2*sqrt2} (should equal 2)\n");
		WriteLine($"pwer215 = {pwer215}\n");
		WriteLine($"epi = {epi}\n");
		WriteLine($"pie = {pie}\n");

		WriteLine($"\nDouble Gamma Calculations:");
		double prod = 1;
        	for (double x = 1; x <= 10; x++) {
            	WriteLine($"Lambda({x}) = {sfuns.fgamma(x)}, ln(Lambda({x}))={sfuns.lngamma(x)}, (x-1)! = {prod}, ln(x-1)! = {Log(prod)}");
            	prod *= x;  // Compute factorial step-by-step
        }

		return 0;
	}
}
