using System;
using System.Collections.Generic;
using System.IO;

class main {
    static void Main() {
        using (var output = new StreamWriter("Output.txt")) {

            // --- Newton's method: Rosenbrock function ---
            output.WriteLine("Rosenbrock gradient root:");
            Func<vector, vector> rosenbrock_grad = v => {
                double x = v[0], y = v[1];
                // Gradient of Rosenbrock function
                return new vector(-2 * (1 - x) - 400 * x * (y - x * x),
                                  200 * (y - x * x));
            };
            vector start1 = new vector(0.5, 0.5);
            vector result1 = Newton.newton(rosenbrock_grad, start1);
            output.WriteLine($"Start: {start1}");
            output.WriteLine($"Result: {result1}");
            output.WriteLine($"‖f(x)‖ = {rosenbrock_grad(result1).norm()}");
            output.WriteLine();

            // --- Newton's method: Himmelblau function ---
            output.WriteLine("Himmelblau gradient root:");
            Func<vector, vector> himmelblau_grad = v => {
                double x = v[0], y = v[1];
                // Gradient of Himmelblau function
                return new vector(4 * x * (x * x + y - 11) + 2 * (x + y * y - 7),
                                  2 * (x * x + y - 11) + 4 * y * (x + y * y - 7));
            };
            vector start2 = new vector(5.0, 5.0);
            vector result2 = Newton.newton(himmelblau_grad, start2);
            output.WriteLine($"Start: {start2}");
            output.WriteLine($"Result: {result2}");
            output.WriteLine($"‖f(x)‖ = {himmelblau_grad(result2).norm()}");
            output.WriteLine();
        }
    }
}