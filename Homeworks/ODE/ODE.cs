using System.Collections.Generic;
using System;
using static System.Math;

public static class ODE{

//implementering af de to rutiner
//rkstep12
    public static (vector,vector) rkstep12(Func<double,vector,vector> f, double x, vector y, double h)
        {
	    vector k0 = f(x,y);              /* embedded lower order formula (Euler) */
	    vector k1 = f(x+h/2,y+k0*(h/2)); /* higher order formula (midpoint) */
	    vector yh = y+k1*h;              /* y(x+h) estimate */
	    vector dy = (k1-k0)*h;           /* error estimate */
	        return (yh,dy);
        }

//driver
    public static (List<double>,List<vector>) driver(Func<double,vector,vector> F, (double,double) interval, vector yinit, double h=0.125, double acc=0.01, double eps=0.01)
    {
        var (a,b) = interval; double x = a; vector y = yinit.copy();
        var xlist = new List<double>(); xlist.Add(x);
        var ylist = new List<vector>(); ylist.Add(y);
        do
        {
	        if(x>=b) return (xlist,ylist); /* job done */
	        if(x+h>b) h=b-x;               /* last step should end at b */
	        var (yh,dy) = rkstep12(F,x,y,h);
	        double tol = (acc+eps*yh.norm()) * Sqrt(h/(b-a));
	        double err = dy.norm();
	    if(err<=tol){ // accept step
		x+=h; y=yh;
		xlist.Add(x);
		ylist.Add(y);
		}
	    if(err>0) h *= Min( Pow(tol/err,0.25)*0.95 , 2); // readjust stepsize
	    else h*=2;
	} while(true);
}//driver

} //ODE