class main{
        public static int Main(){
		double dx=1.0/64;
		for(double x=dx;x<=10;x+=dx){
		System.Console.WriteLine($"{x} {sfuns.lngamma(x)}");
		}
	    System.Console.WriteLine();
	    System.Console.WriteLine();
	    double f=1;
	    for(int i=1;i<=10;i++){
		f*=i;
		System.Console.WriteLine($"{i+1} {f}");
        }
        return 0;
        }//main method

}//main class   
