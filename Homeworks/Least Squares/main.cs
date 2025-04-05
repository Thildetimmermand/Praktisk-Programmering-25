using System;
using static System.Math;
using System.IO;

public class main{
    static void Main(){
            // For part A - skriv data ind

            double[] t = {1,  2,  3,  4,  6,   9, 10, 13, 15 };
            double[] y = {117,100,88,72,53,29.5,25.2,15.2,11.1};
            double[] dy = {6,5,4,4,4,3,3,2,2};

            int n = t.Length;

            // Beregn usikkerheder d(ln(y)) = dy/y
            double[] lny = new double[n];
            double[] dlny = new double[n];
            for (int i = 0; i<n; i++){
                lny[i] = Log(y[i]);
                dlny[i] = dy[i]/y[i];
            }

            // Lav dem til vektorer
            vector vt = new vector(t);
            vector vlny = new vector(lny);
            vector vdlny = new vector(dlny);

            //Definer funktioner
            Func<double,double>[] fs = {
            (double x) => 1.0,      // c0 part
            (double x) => x        // c1 * t part (we will interpret c1 as negative lambda)
            };

            //lsfit
            leastsquares ls = new leastsquares();
            var (c,Cov) = ls.lsfit(fs, vt, vlny, vdlny);

            double c0 = c[0];  //ln(a)
            double c1 = c[1];  //-lambda
            double a = Exp(c0);
            double lambda = -c1;

            //Usikkerhed i fit
            double dlambda = Sqrt(Cov[1,1]);
            double dHalfLife = Log(2)*dlambda/lambda/lambda;

            //Midler til at plotte samt resultater for test
            //Resultater til out.txt
            Console.WriteLine("Fitted Parameters:");
            Console.WriteLine($"ln(a) = {c0}");
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"lambda = {lambda}");
            Console.WriteLine($"half-life = {Log(2)/lambda} days");
            Console.WriteLine();
            Console.WriteLine("The Covariance matrix:");
            Cov.print();
            Console.WriteLine();
            Console.WriteLine($"The Calculated uncertainty in half-life: {dHalfLife} days");
            Console.WriteLine($"The modern uncertainty in half-life: 0.0014 days");

            //Datafiler til Plot
            using (StreamWriter writer = new StreamWriter("datapoints.txt")){
            writer.WriteLine("# t  y  dy");
            for (int i = 0; i < n; i++)
            {
                writer.WriteLine($"{t[i].ToString(System.Globalization.CultureInfo.InvariantCulture)}\t{y[i].ToString(System.Globalization.CultureInfo.InvariantCulture)}\t{dy[i].ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            }
            }//datapoints

            using (StreamWriter writer = new StreamWriter("fit.txt")){
                double tmin = t[0];
                double tmax = t[n-1];
                int steps   = 100;   // Number of points in the smooth curve
                double dt    = (tmax - tmin)/(steps-1);
                for(int i = 0; i < steps; i++)
                    {
                        double T = tmin + i*dt;
                        double lnFit = c0 + c1*T;
                        double yFit  = Exp(lnFit);
                        writer.WriteLine($"{T.ToString(System.Globalization.CultureInfo.InvariantCulture)} {yFit.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
                    }
            }//fit

            using (StreamWriter writer = new StreamWriter("envelope.txt")){
                double tMin = t[0];
                double tMax = t[n - 1];
                int steps   = 100;
                double dt   = (tMax - tMin) / (steps - 1);

                for (int i = 0; i < steps; i++)
                    {
                        double T     = tMin + i * dt;
                        double lnFit = c0 + c1 * T;
                        double bestY = Math.Exp(lnFit);

                    // Variance in y = bestY^2 * [ Cov[0,0] + 2*T*Cov[0,1] + (T^2)*Cov[1,1] ]
                        double varY   = bestY * bestY * (
                                    Cov[0,0] + 2.0 * T * Cov[0,1] + (T*T) * Cov[1,1]
                                );
                        double sigmaY = Math.Sqrt(varY);

                        double yPlus  = bestY + sigmaY;
                        double yMinus = bestY - sigmaY;

                // Columns: t, best-fit y, upper band, lower band
                        writer.WriteLine($"{T.ToString(System.Globalization.CultureInfo.InvariantCulture)} {bestY.ToString(System.Globalization.CultureInfo.InvariantCulture)} {yPlus.ToString(System.Globalization.CultureInfo.InvariantCulture)} {yMinus.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            }

            }//envelope

    } //Main
} //main