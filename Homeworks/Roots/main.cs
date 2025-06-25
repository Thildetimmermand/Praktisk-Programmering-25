using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

class main {
    static void Main() {
        // --- Newton's method: Rosenbrock function ---
        Console.WriteLine("Rosenbrock gradient root:");
        Func<vector, vector> rosenbrock_grad = v => {
            double x = v[0], y = v[1];
            return new vector(-2 * (1 - x) - 400 * x * (y - x * x),
                              200 * (y - x * x));
        };
        vector start1 = new vector(0.5, 0.5);
        vector result1 = Newton.newton(rosenbrock_grad, start1);
        Console.WriteLine($"Start: {start1}");
        Console.WriteLine($"Result: {result1}");
        Console.WriteLine($"‖f(x)‖ = {rosenbrock_grad(result1).norm()}");
        Console.WriteLine();

        // --- Newton's method: Himmelblau function ---
        Console.WriteLine("Himmelblau gradient root:");
        Func<vector, vector> himmelblau_grad = v => {
            double x = v[0], y = v[1];
            return new vector(4 * x * (x * x + y - 11) + 2 * (x + y * y - 7),
                              2 * (x * x + y - 11) + 4 * y * (x + y * y - 7));
        };
        vector start2 = new vector(5.0, 5.0);
        vector result2 = Newton.newton(himmelblau_grad, start2);
        Console.WriteLine($"Start: {start2}");
        Console.WriteLine($"Result: {result2}");
        Console.WriteLine($"‖f(x)‖ = {himmelblau_grad(result2).norm()}");
        Console.WriteLine();

        // --- Hydrogen atom ground state energy ---
        Console.WriteLine("Hydrogen atom ground state:");
        Func<double, double> M = Hydrogen.M;
        double E0 = Bisection(M, -1.0, -0.1, 1e-6);
        Console.WriteLine($"Computed E₀ = {E0.ToString(CultureInfo.InvariantCulture)}");
        Console.WriteLine($"Exact E₀ = -0.5");
        Console.WriteLine($"Error = {Math.Abs(E0 + 0.5).ToString(CultureInfo.InvariantCulture)}");
        Console.WriteLine();

        // --- Save wavefunctions to file ---
        using (var wf = new StreamWriter("wavefunction.txt")) {
            var (rvals, fvals) = Hydrogen.radial_solution(E0);
            for (int i = 0; i < rvals.Count; i++) {
                double r = rvals[i];
                double f = fvals[i];
                double exact = Hydrogen.exact(r);
                wf.WriteLine($"{r.ToString(CultureInfo.InvariantCulture)} {f.ToString(CultureInfo.InvariantCulture)} {exact.ToString(CultureInfo.InvariantCulture)}");
            }
        }
    }

    public static double Bisection(Func<double, double> f, double a, double b, double tol) {
        double fa = f(a), fb = f(b);
        if (fa * fb > 0) throw new Exception("Root not bracketed");
        while (b - a > tol) {
            double c = (a + b) / 2;
            double fc = f(c);
            if (fa * fc < 0) { b = c; fb = fc; }
            else             { a = c; fa = fc; }
        }
        return (a + b) / 2;
    }
}
