static class main{
	public static void Main(){
		//sqrt(-1)
		complex z = new complex(-1,0);
		complex c = cmath.sqrt(z);
		double real = c.Re;
		double imag = c.Im;
		System.Console.WriteLine($"sqrt(-1)=Re:{real}+Im:{imag}");
		System.Console.WriteLine($"approx for real part: {cmath.approx(0,real)}");
		System.Console.WriteLine($"approx for imaginary part: {cmath.approx(1,imag)}");
		//sqrt(i)
		z = new complex(0,1);
		complex c1 = cmath.sqrt(z);
		double real1 = c1.Re;
		double imag1 = c1.Im;
		System.Console.WriteLine($"sqrt(i)=Re:{real1}+Im:{imag1}");
		System.Console.WriteLine($"approx for real part: {cmath.approx(cmath.sqrt(2)/2,real1)}");
		System.Console.WriteLine($"approx for imaginary part: {cmath.approx(cmath.sqrt(2)/2,imag1)}");
		//exp(i)
		z = new complex(0,1);
		complex c2 = cmath.exp(z);
		double real2 = c2.Re;
		double imag2 = c2.Im;
		System.Console.WriteLine($"exp(i)=Re:{real2}+Im:{imag2}");
		System.Console.WriteLine($"approx for real part: {cmath.approx(cmath.cos(1),real2)}");
		System.Console.WriteLine($"approx for imaginary part: {cmath.approx(cmath.sin(1),imag2)}");
		//exp(i*pi)
                z = new complex(0,1);
                complex c3 = cmath.exp(z*System.Math.PI);
                double real3 = c3.Re;
                double imag3 = c3.Im;
                System.Console.WriteLine($"exp(i)=Re:{real3}+Im:{imag3}");
                System.Console.WriteLine($"approx for real part: {cmath.approx(-1,real3)}");
                System.Console.WriteLine($"approx for imaginary part: {cmath.approx(0,imag3)}");
		//i^i
                z = new complex(0,1);
                complex c4 = cmath.pow(z,z);
                double real4 = c4.Re;
                double imag4 = c4.Im;
                System.Console.WriteLine($"i^i=Re:{real4}+Im:{imag4}");
                System.Console.WriteLine($"approx for real part: {cmath.approx(cmath.exp(System.Math.PI/2),real4)}");
                System.Console.WriteLine($"approx for imaginary part: {cmath.approx(0,imag4)}");
		//ln(i)
                z = new complex(0,1);
                complex c5 = cmath.log(z);
                double real5 = c5.Re;
                double imag5 = c5.Im;
                System.Console.WriteLine($"ln(i)=Re:{real5}+Im:{imag5}");
                System.Console.WriteLine($"approx for real part: {cmath.approx(0,real5)}");
                System.Console.WriteLine($"approx for imaginary part: {cmath.approx(System.Math.PI/2,imag5)}");
		//sin(i*pi)
                z = new complex(0,1);
                complex c6 = cmath.sin(System.Math.PI*z);
                double real6 = c6.Re;
                double imag6 = c6.Im;
                System.Console.WriteLine($"sin(i*pi)=Re:{real6}+Im:{imag6}");
                System.Console.WriteLine($"approx for real part: {cmath.approx(0,real6)}");
                System.Console.WriteLine($"approx for imaginary part: {cmath.approx(11.5487393572,imag6)}");

	}//Main
}//main