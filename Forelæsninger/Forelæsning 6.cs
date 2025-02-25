//Generics
using static System.Console;
using complex=System.Numerics.Complex;
class main{
    static void echo<T>(T arg){WriteLine($"echo: {arg}");}; //T is type parameter, echo can take argument of any type, and simply prints it

    static void addition<T>(T x, T y){
        dynamic a = x, b = y; //this constrains T to types that support "+"
        WriteLine($"echo: {x} + {y} = {a + b}");};

    static void fun_of_one(System.Func<double,double> f){Writeline($"f(1)={f(1)}");}
   
    static int Main(){
        //Delegate:
        System.Func<double,double> f = delegate(double x){return x*x;}; //specificerer at f er en function som skal tage en "double" og returnere en "double"
        f = System.Math.Sin; //now f is defined as the sin function

        //lambda function
        f = x => x*x //exactly like lambda function in Python
        
        //testing function of function
        fun_of_one(f);
        fun_of_one(x => x*x); //the function within is an anonymous function as it is made and consumed immediately

        //Trying echo function
        echo("string"); //this means when you run the code it prints echo: arg , as we have put previously
        echo(1);
        echo(1.23);
        complex I = complex.Sqrt(-1);
        echo(complex.Sqrt(-1));
        echo(complex.Pow(I,I));
        echo(complex.Sin(I));

        return 0;

    }
}