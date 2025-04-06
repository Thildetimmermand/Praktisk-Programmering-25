using static System.Math;
using System;

public static class integrator{
    
    //Integration:
    public static double integrate(Func<double, double> f, double a, double b, ref int iterations, double delta = 0.001, double eps = 0.001, double f2 = double.NaN, double f3 = double.NaN){
        iterations++;

        double h = b - a;
        if(double.IsNaN(f2)){
            f2 = f(a+2*h/6);
            f3 = f(a+4*h/6); 
            } // first call, no points to reuse

        double f1 = f(a+h/6);
        double f4 = f(a+5*h/6);

        double Q = (2*f1+f2+f3+2*f4)/6*(b-a); // higher order rule
        double q = (f1+f2+f3+  f4)/4*(b-a); // lower order rule
        
        double err = Abs(Q - q);
        if (err <= delta + eps * Abs(Q)){ return Q;}
        else {
            double result = integrate(f,a,(a+b)/2, ref iterations, delta/Sqrt(2),eps,f1,f2) + integrate(f,(a+b)/2,b, ref iterations, delta/Sqrt(2),eps,f3,f4);
            return result;}
    
    } //integrate

    //Clenshawintegrate
    public static double clenshawintegrate(Func<double, double> f, double a, double b, ref int iterations, double delta = 0.001, double eps = 0.001, double f2 = double.NaN, double f3 = double.NaN)
    {
        iterations = 0; // Initialize the iteration count
        Func<double, double> clenshawf = theta => f((a + b) / 2 + (b - a) / 2 * Cos(theta)) * Sin(theta) * (b - a) / 2;

        double result = integrate(clenshawf, 0, PI, ref iterations, delta, eps, f2, f3);
        return result;
    } //clenshaw

} //integrator