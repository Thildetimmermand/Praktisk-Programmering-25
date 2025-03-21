using static System.Math;
using System.Collections.Generic;
public class splines{
    //Part A1 - interpolation
    public static double linterp(double[] x, double[] y, double z){
        int i = binsearch(x,z);
        double dx=x[i+1]-x[i]; if(!(dx>0)) throw new System.Exception("uups...");
        double dy=y[i+1]-y[i];
        return y[i]+dy/dx*(z-x[i]);
        }
    
    //Binary search
    public static int binsearch(double[] x, double z)
	{/* locates the interval for z by bisection */ 
	if( z<x[0] || z>x[x.Length-1] ) throw new System.Exception("binsearch: bad z");
	int i=0, j=x.Length-1;
	while(j-i>1){
		int mid=(i+j)/2;
		if(z>x[mid]) i=mid; else j=mid;
		}
	return i;
	}

    //PartA2
    public static double linterpInteg(double[] x, double[] y, double z){
    int k = binsearch(x, z); // Find the interval index
    double integral = 0;
    for (int i = 0; i < k; i++)
    {
        double cont = y[i] * (x[i + 1] - x[i]) + (y[i + 1] - y[i]) / (x[i + 1] - x[i]) * Pow(x[i + 1] - x[i], 2) / 2; //lign 8 i dokument
        integral += cont;
    }
    double restIntegral = y[k] * (z - x[k]) + (y[k + 1] - y[k]) / (x[k + 1] - x[k]) * Pow((z - x[k]), 2) / 2; //ligger det sidste som mangler til
    integral += restIntegral;
    return integral;
    }


} //splines

//Part B

public class qspline {
	vector x,y,b,c;
	public qspline(vector xs,vector ys){
		/* x=xs.copy(); y=ys.copy(); calculate b and c */
        int n = xs.size;
        x = xs.copy();
        y = ys.copy();
        b = new vector(n-1);
        c = new vector(n-1);
        
        vector h = new vector(n-1);
        for (int i = 0; i < n - 1; i++)
        {
            h[i] = x[i + 1] - x[i];
        }

        vector p = new vector(n - 1);
        for (int i = 0; i < n - 1; i++)
        {
            p[i] = (y[i + 1] - y[i]) / h[i];
        }

        c[0] = 0;
        for (int i = 0; i < n - 2; i++)
        {
            c[i + 1] = (p[i + 1] - p[i] - c[i] * h[i]) / h[i + 1];
        }

        c[n - 2] /= 2;
        for (int i = n - 3; i >= 0; i--)
        {
            c[i] = (p[i + 1] - p[i] - c[i + 1] * h[i + 1]) / h[i];
        }

        for (int i = 0; i < n - 1; i++)
        {
            b[i] = p[i] - c[i] * h[i];
        }
		} //qspline function
		
	public double evaluate(double z){
        int i = splines.binsearch(x,z);
        double h = z - x[i];
        return y[i] + h * (b[i] + h * c[i]);
    }
	public double derivative(double z){
        int i = splines.binsearch(x,z);
        double h = z - x[i];
        return b[i] + 2 * c[i] * h;
    }
	public double integral(double z){
        int i = splines.binsearch(x,z);
        double integral = 0;
        for (int j = 0; j < i; j++)
        {
            double h = x[j + 1] - x[j];
            integral += y[j] * h + b[j] * h * h / 2 + c[j] * h * h * h / 3;
        }
        double h_last = z - x[i];
        integral += y[i] * h_last + b[i] * h_last * h_last / 2 + c[i] * h_last * h_last * h_last / 3;
        return integral;
    }
	} //Qspline