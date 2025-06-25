using System;
using System.IO;
using static System.Math;
using System.Globalization;

class main {
    static void Main() {
        // Define the unit circle integrand
        Func<vector, double> unitCircle = v => {
            double x = v[0], y = v[1];
            return (x * x + y * y <= 1) ? 1.0 : 0.0;
        };

        vector a = new vector(-1.0, -1.0);
        vector b = new vector( 1.0,  1.0);
        double exact = PI;

        using (var writer = new StreamWriter("errordata.txt")) {
            writer.WriteLine("# N   estimate   estimated_error   actual_error");

            for (int n = 100; n <= 1000000; n *= 10) {
                var (estimate, error) = MC.plainmc(unitCircle, a, b, n);
                double actualError = Abs(estimate - exact);

                // Write error data to file
                writer.WriteLine($"{n.ToString(CultureInfo.InvariantCulture)} {estimate.ToString(CultureInfo.InvariantCulture)} {error.ToString(CultureInfo.InvariantCulture)} {actualError.ToString(CultureInfo.InvariantCulture)}");

                // Also print results to console (which goes to Out.txt)
                Console.WriteLine($"N={n}: Estimate={estimate}, Estimated error={error}, Actual error={actualError}");
            }
        }
    }
}