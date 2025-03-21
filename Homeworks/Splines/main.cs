//Main

using System.IO;
using static System.Math;
class main{
    static void Main(){
        //For part A
        double[] xs = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
        double[] ys = {Cos(0), Cos(1), Cos(2), Cos(3), Cos(4), Cos(5), Cos(6), Cos(7), Cos(8), Cos(9)};

        using (StreamWriter writer = new StreamWriter("dataPoints.txt")) //Laver dokument til datapunkter
        {
            writer.WriteLine("# x  y");
            for (int i = 0; i < xs.Length; i++)
            {
                writer.WriteLine($"{xs[i].ToString(System.Globalization.CultureInfo.InvariantCulture)}\t{ys[i].ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            }
        }
    
        var interpolated_data = new StreamWriter("interpolated.txt"); //Laver dokument til Interpolated data
        for (double z = xs[0]; z < xs[xs.Length-1]; z+=0.001) {    //Evaluates spline over fine grid
            interpolated_data.WriteLine($"{z.ToString(System.Globalization.CultureInfo.InvariantCulture)}\t{splines.linterp(xs,ys,z).ToString(System.Globalization.CultureInfo.InvariantCulture)}\t{splines.linterpInteg(xs,ys,z).ToString(System.Globalization.CultureInfo.InvariantCulture)}");
        }

        //Plots are made within the Makefile

        //For part B

        double[] x = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
        double[] y = {Sin(0), Sin(1), Sin(2), Sin(3), Sin(4), Sin(5), Sin(6), Sin(7), Sin(8), Sin(9)};

        using (StreamWriter writer = new StreamWriter("qdatapoints.txt"))
        {
            writer.WriteLine("# x  y");
            for(int i = 0; i < x.Length; i++)
            {
                writer.WriteLine($"{x[i].ToString(System.Globalization.CultureInfo.InvariantCulture)}\t{y[i].ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            }
        }

        qspline qspline = new qspline(x,y);
        var qinterpolated_data = new StreamWriter("qinterpolated.txt");
        for (double z = x[0]; z < x[x.Length-1]; z+=0.01) {    
            qinterpolated_data.WriteLine($"{z.ToString(System.Globalization.CultureInfo.InvariantCulture)}\t{qspline.evaluate(z).ToString(System.Globalization.CultureInfo.InvariantCulture)}\t{qspline.integral(z).ToString(System.Globalization.CultureInfo.InvariantCulture)}");
        }

    } //Main
} //main