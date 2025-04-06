using static System.Math;
using System;

public static class main{
    public static void Main(){
        double acc = 0.001; //accuracy
        double eps = 0.001; //epsilon

        Console.WriteLine("Part A - testing integration");

        //Part A - se om integraler passer.
        //integration limits for all:
        double a = 0;
        double b = 1;

        //sqrt(x)
        Func<double, double> func = x => Sqrt(x);
        int i = 0;
        double res = integrator.integrate(func, a, b, ref i, acc, eps);
        Console.WriteLine($"The integral of sqrt(x) from {a} to {b} is: {res}, within accuracy? {Abs(res-2.0/3.0)<=acc && Abs((res - (2.0/3.0)) / (2.0/3.0)) <= eps}");

        //1/sqrt(x)
        i = 0;
        func = x => 1/Sqrt(x);
        res = integrator.integrate(func, a, b, ref i, acc, eps);
        Console.WriteLine($"The integral of 1/sqrt(x) from {a} to {b} is: {res}, within accuracy? {Abs(res-2.0)<=acc && Abs((res - (2.0)) / (2.0)) <= eps}, number of evaluations: {i}");

        //sqrt(1-x^2)
        i = 0;
        func = x => Sqrt(1-Pow(x,2));
        res = integrator.integrate(func, a, b, ref i, acc, eps);
        Console.WriteLine($"The integral of sqrt(1-x^2) from {a} to {b} is: {res}, within accuracy? {Abs(res-(PI/4.0))<=acc && Abs((res - (PI/4.0)) / (PI/4.0)) <= eps}");

        //ln(x)/sqrt(x)
        i = 0;
        func = x => Log(x)/Sqrt(x);
        res = integrator.integrate(func, a, b, ref i, acc, eps);
        Console.WriteLine($"The integral of ln(x)/sqrt(x) from {a} to {b} is: {res}, within accuracy? {Abs(res-(-4.0))<=acc && Abs((res - (-4.0)) / (-4.0)) <= eps}, number of evaluations: {i}");

        //Plot errorfunction
        var errorfile = new System.IO.StreamWriter("Errorfunc.txt", append: true);
        for(double x = -5; x<=5; x+=0.001) errorfile.WriteLine($"{x.ToString(System.Globalization.CultureInfo.InvariantCulture)} {Errorfunc(x).ToString(System.Globalization.CultureInfo.InvariantCulture)}");
        errorfile.Close();

        //3-points task
        //1/sqrt(x)
        i = 0;
        func = x => 1/Sqrt(x);
        res = integrator.clenshawintegrate(func, a, b, ref i, acc, eps);
        Console.WriteLine($"The integral of 1/sqrt(x) using clenshaw from {a} to {b} is: {res}, within accuracy: {Abs(res-(2))<=acc && Abs((res - (2)) / (2)) <= eps}, number of integrand evaluations: {i}");

        //ln(x)/sqrt(x)
        i = 0;
        func = x => Log(x)/Sqrt(x);
        res = integrator.clenshawintegrate(func, a, b, ref i, acc, eps);
        Console.WriteLine($"The integral of ln(x)/sqrt(x) using clenshaw from {a} to {b} is: {res}, within accuracy: {Abs(res-(-4))<=acc && Abs((res - (-4)) / (-4)) <= eps}, number of integrand evaluations: {i}");
        Console.WriteLine("Normal integration routine is slower than python but the clenshaw implementation is faster than python");
        Console.WriteLine("Scipy uses 231 and 315 function evaluations for the same integrals.");

    } //Main

    //Implementation  of errorfunction
    public static double Errorfunc(double z, double acc = 0.001, double eps = 0.001)
        {
        if (z < 0) return -Errorfunc(-z); //limit 1
        int i = 0;
        Func<double, double> f1 = t => Exp(-Pow(t, 2));
        if (z <= 1 && z <= 1) return 2 / Sqrt(PI) * integrator.integrate(f1, 0, z, ref i, acc, eps); //limit 2
        i = 0;
        Func<double, double> f2 = t => Exp(-Pow(z + (1 - t)/t, 2))/t/t;
        if (z > 1) return 1 - 2 / Sqrt(PI) * integrator.integrate(f2, 0, 1, ref i, acc, eps);
        else throw new Exception($"The argument for the error function is false. Argument: {z}");
        }

} //main