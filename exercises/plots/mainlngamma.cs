using static System.Math;
using System.Numerics;
class main{
        public static int Main(){
		double dx=1.0/64;
                for(double x=dx; x<=10; x+=dx){
                        System.Console.WriteLine($"{x.ToString(System.Globalization.CultureInfo.InvariantCulture)} {sfuns.lngamma(x).ToString(System.Globalization.CultureInfo.InvariantCulture)}");
                }//func
		return 0;
        }//main method
}//main class   
