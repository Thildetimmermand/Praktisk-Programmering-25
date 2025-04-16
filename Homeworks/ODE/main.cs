using System;
using System.Collections.Generic;
using static System.Math;
public static class main{
    public static void Main(){
        //Part A

        //Debugging with y'' = -y
        System.Func<double, vector, vector> func = (double x, vector y) => {
        vector v = new vector(y.size);
        v[0] = y[1];
        v[1] = -y[0];
        return v;
        };

        (double start, double end) interval = (0, 10);
        vector y_ode = new vector(2);
        y_ode[0] = 5;
        y_ode[1] = 0;

        var res = ODE.driver(func, interval, y_ode);
        for(int i = 0; i < res.Item1.Count; i++) {
            System.Console.WriteLine($"{res.Item1[i]} {res.Item2[i][0]}");
        }

        //Oscillator with friction
        System.Func<double, vector, vector> func_osc = (double x, vector y) => {
        vector v = new vector(y.size);
        double b = 0.25;
        double c = 5;
        v[0] = y[1];
        v[1] = -b*y[1] - c*Sin(y[0]);
        return v;
        };

        vector y_osc = new vector(2);
        y_osc[0] = PI - 0.1;
        interval = (0, 10);
        var res2 = ODE.driver(func_osc, interval, y_osc, h: 0.01);

        using(var outfile = new System.IO.StreamWriter("osc.txt", append: true)) {
        for(int i = 0; i < res2.Item1.Count; i++) {
            outfile.WriteLine($"{res2.Item1[i]} {res2.Item2[i][0]}");
            }
        }

        using(var outfile1 = new System.IO.StreamWriter("oscwfriction.txt", append: true)) {
        for(int i = 0; i < res2.Item1.Count; i++) {
            outfile1.WriteLine($"{res2.Item1[i]} {res2.Item2[i][1]}");
                    }
        }

        // Part B

        //Newtonian
        double epsilon = 0;
        var planetaryODE = makePlanetaryODE(epsilon);
        vector y_circular = new vector(2); y_circular[0] = 1.0; y_circular[1] = 0.0;
        var resNew = ODE.driver(planetaryODE, (0, 20*PI), y_circular, h: 0.1);

        using(var outfile = new System.IO.StreamWriter("Newtonian.txt", append: false)) {
            for(int i = 0; i < resNew.Item1.Count; i++) {
                outfile.WriteLine($"{resNew.Item1[i].ToString(System.Globalization.CultureInfo.InvariantCulture)} {resNew.Item2[i][0].ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            }
        }

        //Elliptical
        epsilon = 0;
        planetaryODE = makePlanetaryODE(epsilon);
        vector y_elliptical = new vector(2); y_elliptical[0] = 1.0; y_elliptical[1] = -0.5;
        var resElip = ODE.driver(planetaryODE, (0, 20*PI), y_elliptical, h: 0.1);

        using(var outfile1 = new System.IO.StreamWriter("Elliptical.txt", append: false)) {
            for(int i = 0; i < resElip.Item1.Count; i++) {
                outfile1.WriteLine($"{resElip.Item1[i].ToString(System.Globalization.CultureInfo.InvariantCulture)} {resElip.Item2[i][0].ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            }
        }

        //Precession
        epsilon = 0.01;
        planetaryODE = makePlanetaryODE(epsilon);
        vector y_rec = new vector(2); y_rec[0] = 1.0; y_rec[1] = -0.5;
        var resRec = ODE.driver(planetaryODE, (0, 20*PI), y_rec, h: 0.1);

        using(var outfile2 = new System.IO.StreamWriter("Rec.txt", append: false)) {
            for(int i = 0; i < resRec.Item1.Count; i++) {
                outfile2.WriteLine($"{resRec.Item1[i].ToString(System.Globalization.CultureInfo.InvariantCulture)} {resRec.Item2[i][0].ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            }
        }

    }//Main

    //Helper
    static System.Func<double, vector, vector> makePlanetaryODE(double epsilon) {
        return (double phi, vector y) => {
            vector dydphi = new vector(2);
            dydphi[0] = y[1];
            dydphi[1] = 1 - y[0] + epsilon * y[0] * y[0];
            return dydphi;
        };
    }
}//main