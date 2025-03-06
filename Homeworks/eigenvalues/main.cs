
//Del 1 af Homework
class main{
	static void Main(string[] args){
	
	//Testing with timesJ and JTimes with non random matrices
        matrix A = new matrix(5,5);
        var rnd = new System.Random(1);

        for(int i = 0; i < A.size1; i++){
            for(int j = i; j < A.size1; j++){
                A[i,j] = rnd.NextDouble(); // Upper triangular matrix is created
                A[j,i] = A[i,j]; // Upper triangular part is copied to lower part
            }
        }

        System.Console.Write("Random matrix A");
        A.print();

        vector w;
        matrix V;
        matrix D;
        (w,D,V) = jacobi.cyclic(A);
        
        System.Console.Write("Matrix V consisting of eigenvectors");
        V.print();
        System.Console.WriteLine();

        System.Console.WriteLine("Vector w consisting of eigenvalues");
        w.print();

        System.Console.WriteLine("Diagonal Matrix D");
        D.print();
        System.Console.WriteLine("");

        //Testing that the Jacobi routine works as intended

        System.Console.WriteLine("Does V_transpose*A*V=D?");
        System.Console.WriteLine((V.transpose()*A*V).approx(D)); //Output is true
        System.Console.WriteLine("");

        System.Console.WriteLine("Does V*D*V_transpose=A?");
        System.Console.WriteLine((V*D*V.transpose()).approx(A)); //Output is true
        System.Console.WriteLine("");

        matrix id = matrix.id(5);
        System.Console.WriteLine("Does V*V_transpose=IdMatrix?");
        System.Console.WriteLine((V*V.transpose()).approx(id)); //Output is true
        System.Console.WriteLine("");

        System.Console.WriteLine("Does V_transpose*V=IdMatrix?");
        System.Console.WriteLine((V.transpose()*V).approx(id)); //Output is true
	}
} //main


//Jacobi class

public static class jacobi{
    
    //timesJ
    public static void timesJ(matrix A, int p, int q, double theta){
        double c = System.Math.Cos(theta);
        double s = System.Math.Sin(theta);
	    for(int i = 0; i<A.size1; i++){
		    double aip = A[i,p];
            double aiq=A[i,q];
		    A[i,p] = c*aip - s*aiq;
		    A[i,q] = s*aip + c*aiq;
		    }
    }

    //Jtimes
    public static void Jtimes(matrix A, int p, int q, double theta){
        double c = System.Math.Cos(theta);
        double s = System.Math.Sin(theta);
        for(int j=0; j<A.size1; j++){
		    double apj=A[p,j];
            double aqj=A[q,j];
		    A[p,j] = c*apj + s*aqj;
		    A[q,j] = -s*apj + c*aqj;
		}
    }

    //cyclic
    public static (vector, matrix, matrix) cyclic(matrix M){  // compute the eigenvalues and eigenvectors of a symmetric matrix
            matrix A=M.copy();  //copy so we keep original matrix M
	        matrix V=matrix.id(M.size1);  //identity matrix to store eigenvectors
	        vector w=new vector(M.size1);  //vector to store eigenvalues
        int n = M.size1;  //dimension of matrix
	        bool changed;
        do{
	        changed=false;  //are the rotations still changing the matrix?
        const double epsilon = 1e-6;
	        for(int p=0;p<n-1;p++){
	            for(int q=p+1;q<n;q++){
		            double apq=A[p,q], app=A[p,p], aqq=A[q,q];
		            double theta=0.5*System.Math.Atan2(2*apq,aqq-app);
		            double c=System.Math.Cos(theta);
                    double s=System.Math.Sin(theta);
		            double new_app=c*c*app-2*s*c*apq+s*s*aqq; //A'_pp
		            double new_aqq=s*s*app+2*s*c*apq+c*c*aqq; //A'_qq
		            if (System.Math.Abs(new_app - app) > epsilon || System.Math.Abs(new_aqq - aqq) > epsilon) // do rotation
			            {
			            changed=true;
			            timesJ(A,p,q, theta); // A←A*J 
			            Jtimes(A,p,q,-theta); // A←JT*A 
			            timesJ(V,p,q, theta); // V←V*J
			            }
                }
        }
        }while(changed);
        for (int i = 0; i<n;i++) w[i] = A[i,i]; //copies eigenvalues to vector w
	        return (w,A,V); //w=vector with eigenvalues, A=matrix with only diagonal elements, V=matrix with eigenvectors
            }
}