//maingamma.cs

class main{
        public static int Main(){
		double dx=1.0/128;
                for(double x=-5+dx/2; x<=5-dx; x+=dx){
                        System.Console.WriteLine($"{x} {sfuns.gamma(x)}");
                }//func
                return 0;
        }//main method
}//main class   