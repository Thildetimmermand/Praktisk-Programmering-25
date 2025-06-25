using System;
using System.Collections.Generic;

public static class Hydrogen {
    // Parameters for the radial integration range and tolerances
    public static double rmin = 1e-5;
    public static double rmax = 8;
    public static double acc = 1e-6;
    public static double eps = 1e-6;

    // Returns the right-hand side of the Schrödinger equation as a first-order system
    public static Func<double, vector, vector> schrodinger(double E) => (r, f) => {
        double dfdr = f[1];                           // First derivative: f'
        double d2fdr2 = -2 * (E + 1 / r) * f[0];      // Second derivative: f'' from the Schrödinger equation
        return new vector(dfdr, d2fdr2);              // Return the system as a vector [f', f'']
    };

    // Integrates the Schrödinger equation from rmin to rmax for a given energy E
    public static vector integrate(double E) {
    vector f0 = new vector(rmin - rmin * rmin, 1 - 2 * rmin);
    var result = ODE.driver(schrodinger(E), (rmin, rmax), f0, acc: acc, eps: eps);
    List<double> xlist = result.Item1;
    List<vector> ylist = result.Item2;
    return ylist[ylist.Count - 1];
}

public static (List<double>, List<double>) radial_solution(double E) {
    vector f0 = new vector(rmin - rmin * rmin, 1 - 2 * rmin);
    var result = ODE.driver(schrodinger(E), (rmin, rmax), f0, acc: acc, eps: eps);
    List<double> xlist = result.Item1;
    List<vector> ylist = result.Item2;

    List<double> rvals = new List<double>(), fvals = new List<double>();
    for (int i = 0; i < xlist.Count; i++) {
        rvals.Add(xlist[i]);
        fvals.Add(ylist[i][0]);
    }
    return (rvals, fvals);
}


    // Function M(E): returns f(rmax) for a given E, used in root finding
    public static double M(double E) => integrate(E)[0];

    // Exact analytic solution for the hydrogen ground state wavefunction (up to normalization)
    public static double exact(double r) => r * Math.Exp(-r);
}