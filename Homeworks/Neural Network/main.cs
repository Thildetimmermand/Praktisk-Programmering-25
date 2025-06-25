using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

class Program {
    static void Main() {
        var xs = new List<double>(); // List of x-values for training
        var ys = new List<double>(); // Corresponding target y-values (function outputs)

        // Define the target function: f(x) = cos(5x - 1) * exp(-x^2)
        Func<double, double> g = x => Math.Cos(5 * x - 1) * Math.Exp(-x * x);

        int N = 200; // Number of sample points
        for (int i = 0; i < N; i++) {
            double x = -1 + 2.0 * i / (N - 1); // Evenly spaced x in [-1, 1]
            xs.Add(x);
            ys.Add(g(x)); // Sample the target function at x
        }

        // Initialize neural network with 8 hidden neurons
        var network = new ann(8);

        // Train the network on sampled data
        network.train(xs, ys);

        // Write detailed results to "Out.txt"
        using (var writer = new StreamWriter("Out.txt")) {
            writer.WriteLine("   x     f(x)  f'(x)  f''(x)  ∫f(x)dx");

            // Evaluate and print network output, derivatives, and integral over range
            for (double x = -1; x <= 1.05; x += 0.05) {
                double fx = network.response(x);             // Neural net output
                double dfx = network.derivative(x);          // First derivative
                double d2fx = network.second_derivative(x);  // Second derivative
                double intfx = network.antiderivative(x);    // Approximate integral
                
                writer.WriteLine(
                    $"{x.ToString("F3", CultureInfo.InvariantCulture)}  " +
                    $"{fx.ToString("F3", CultureInfo.InvariantCulture)}  " +
                    $"{dfx.ToString("F3", CultureInfo.InvariantCulture)}  " +
                    $"{d2fx.ToString("F3", CultureInfo.InvariantCulture)}  " +
                    $"{intfx.ToString("F3", CultureInfo.InvariantCulture)}"
                );
            }

            // Documentation and qualitative analysis
            writer.WriteLine("###################################################");
            writer.WriteLine("Target Function:");
            writer.WriteLine("f(x) = cos(5x - 1) * exp(-x^2)");
            writer.WriteLine("###################################################");
        }

        // Write data for plotting: x, actual f(x), neural network approximation
        using (var plotWriter = new StreamWriter("anndata.txt")) {
            for (double x = -1; x <= 1; x += 0.05) {
                double actual = g(x);
                double predicted = network.response(x);

                plotWriter.WriteLine(
                    $"{x.ToString("F5", CultureInfo.InvariantCulture)}\t" +
                    $"{actual.ToString("F5", CultureInfo.InvariantCulture)}\t" +
                    $"{predicted.ToString("F5", CultureInfo.InvariantCulture)}"
                );
            }
        }
    }
}
