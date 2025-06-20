public class main {
	public static int Main() {
        System.Console.WriteLine("ToString method for constructed vectors");
		vec v = new vec(1,2,3);	
		vec u = new vec(3,2,1);
		vec neg_v = new vec(-1,-2,-3);
		vec neg_u = new vec(-3,-2,-1);

		//Testing if ToString method works
		System.Console.WriteLine($"v = {v.ToString()}");
		System.Console.WriteLine($"u = {v.ToString()}");
		//Same but for negative vectors
		System.Console.WriteLine($"-v = {neg_v.ToString()}");
		System.Console.WriteLine($"-u = {neg_u.ToString()}");
		
		//Testing of scalar operator
		System.Console.WriteLine("");
		System.Console.WriteLine("Testing if scalar operator works as intended");
		vec result = v*2;
		System.Console.WriteLine($"v*2 = {result.ToString()}");
		result = v*2.5;
		System.Console.WriteLine($"v*2.5 = {result.ToString()}");
		result = v*-3;
		System.Console.WriteLine($"v*-3.0 = {result.ToString()}");
		result = neg_v*2;
		System.Console.WriteLine($"v*2.0 = {result.ToString()}");
		result = neg_v*2.5;
		System.Console.WriteLine($"v*2.5 = {result.ToString()}");
		result = v*2.5;
		System.Console.WriteLine($"v*-2.0 = {(v*2.5).ToString()}");



		System.Console.WriteLine($"Does v*(-1) = -v: {(v*(-1)).approx(neg_v)}");
		System.Console.WriteLine($"Does -v = v*(-1): {neg_v.approx(v*(-1))}");

		//Testing of plus operator
		System.Console.WriteLine("");
		System.Console.WriteLine("Testing if + operator works as intended");
		System.Console.WriteLine($"v+v = {(v + v).ToString()}");
		System.Console.WriteLine($"v+u = {(v + u).ToString()}");
		System.Console.WriteLine($"v+(-v) = {(v + neg_v).ToString()}");

		//Testing of minus operator
		System.Console.WriteLine("");
		System.Console.WriteLine("Testing if - operator works as intended");
		System.Console.WriteLine($"v-v = {(v - v).ToString()}");
		System.Console.WriteLine($"v-u = {(v - u).ToString()}");
		System.Console.WriteLine($"v-(-v) = {(v - neg_v).ToString()}");

		//Testing of dot operator
		System.Console.WriteLine("");
		System.Console.WriteLine("Testing if dot operator works as intended");
		System.Console.WriteLine($"v(dot)v = {(vec.dot(v,v)).ToString()}");
		System.Console.WriteLine($"v(dot)u = {(vec.dot(v,u)).ToString()}");
		System.Console.WriteLine($"v(dot)(-v) = {(vec.dot(v,neg_v)).ToString()}");
		
		//Testing of approx
		System.Console.WriteLine($"v*(-1).approx(-v) = {(vec.approx(v*-1,neg_v)).ToString()}");
		return 0;
	}
}