using System;
using static System.Console;

public class vec{
	public double x,y,z; //vi starter med at definere de tre komponenter af en vektor

    //constructors
    public vec(){ x=y=z=0; }
    public vec(double x,double y,double z){ this.x=x; this.y=y; this.z=z; }

    //operators
    public static vec operator*(vec v, double c){
        return new vec(c*v.x,c*v.y,c*v.z);}
    
    public static vec operator*(double c, vec v){
        return v*c;}
    
    public static vec operator+(vec u, vec v){
        return new vec(v.x+u.x, v.y+u.y, v.z+u.z);}
    
    public static vec operator-(vec u){
        return new vec(-u.x,-u.y,-u.z);}
    
    public static vec operator-(vec u, vec v){
        return new vec(u.x-v.x, u.y-v.y, u.z-v.z);}
    
    //methods
    public void print(string s){WriteLine($"{x} {y} {z}");}
    public void print(){this.print("");}

    //dot product
    

}
