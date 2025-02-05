using System;
using static System.Console;
using static System.Math;
class main{
	static int Main(){
		//Max int
		int i=1;
		while(i+1>i){i++;}
		WriteLine($"my max int = {i}\n");
		WriteLine($"int.MaxValue = {int.MaxValue}\n");

		//Min int
		while(i-1<i){i--;}
		WriteLine($"my min int = {i}\n");
		WriteLine($"int.MinValue = {int.MinValue}\n");

		//machine epsilon (double)
		double x = 1;
		while(1+x!=1){x/=2;}
		x*=2;
		WriteLine($"Double machine epsilon = {x}\n");
		WriteLine($"Comparison Value (double) = {Pow(2, -52)}\n");

		//machine epsilon (float)
		float y = 1F;
		while((float)(1F+y) != 1F){y/=2F;}
		y*=2F;
		WriteLine($"Float machine epsilon = {y}\n");
		WriteLine($"Comparison value (float) = {Pow(2,-23)}\n");

		//tiny
		double epsilon = Pow(2, -52);
		double tiny = epsilon/2;
		double a = 1 + tiny + tiny;
		double b = tiny + tiny + 1;
		WriteLine($"a==b ? {a==b} this result is due to ...\n");
		WriteLine($"a>1 ? {a>1} this result is due to ...\n");
		WriteLine($"b>1 ? {b>1} this result is due to ...\n");

		//comparing doubles (intro)
		double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
		double d2 = 8*0.1; 
		WriteLine($"d1={d1:e15}");
		WriteLine($"d2={d2:e15}");
		WriteLine($"d1==d2 ? => {d1==d2}");	

		//comparing doubles
		WriteLine($"d1==d2 ? => {approx(d1, d2)}");

		return 0;
	}
	public static bool approx (double a, double b, double acc=1e-9, double eps=1e-9){
		if(Abs(b-a) <= acc) return true;
		if(Abs(b-a) <= Max(Abs(a),Abs(b))*eps) return true;
		return false;
}
}
