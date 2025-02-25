class main{
	static void Main(){
		matrix identity4 = new matrix(5);
		for (int i = 0; i<5;i++) identity4[i,i] = 1;
		//Generates random matrix A
		//int n = 5;
		//int m = 4;
		matrix A = new matrix(8,5);
		var rnd = new System.Random(1);
		for (int n = 0; n < A.size1;n++){
			for (int m = 0; m < A.size2; m++){
				A[n,m] = rnd.NextDouble();
			}
		}
		A.print("Matrix A");

		//QRGS Demoposition
		(matrix Q, matrix R) = QRGS.decomp(A);
		Q.print("Matrix Q");
		R.print("Matrix R");

		//R triangular
		System.Console.WriteLine($"Is R upper triangular? {QRGS.isUpperTriangular(R)}");

		//Checks Q_transpose * Q = I
		matrix I = Q.transpose() * Q;
		I.print("Matrix Q_transposed * Q");
		System.Console.WriteLine($"Does Q_transposed * Q approximate to the identity matrix: {(I).approx(identity4)}");

		matrix QR = Q * R;
		QR.print("Matrix QR");
		System.Console.WriteLine($"Does A approximate to QR: {A.approx(QR)}");
		matrix identity5 = new matrix(5);
		for (int i = 0; i<5;i++) identity5[i,i] = 1;


		System.Console.WriteLine("#################################################################### \n Testing solve for square matrix\n####################################################################");
		//Random square matrix and vector
		matrix squareA = new matrix(5,5);
		vector b = new vector(5);
		for (int i = 0; i<squareA.size1; i++){
			for (int j = 0; j<squareA.size2; j++){
				squareA[i,j] = rnd.NextDouble();
			}
		}		
		for (int i = 0; i<b.size; i++){
			b[i] = rnd.NextDouble();
		}
		squareA.print("Square A matrix");
		b.print("b Vector");

		//QR-decomposition
		(matrix squareQ, matrix squareR) = QRGS.decomp(squareA);
		squareQ.print("Square Q matrix");
		squareR.print("Square R matrix");
		matrix squareQR = squareQ * squareR;
		squareQR.print("QR");

		//Solve for x
		vector x = QRGS.solve(squareQ,squareR,b);
		x.print("QRGS solve");
		vector Ax = squareA*x;
		Ax.print("Ax");
		System.Console.WriteLine($"Does Ax approximate b: {Ax.approx(b)}");

		//Square matrix from before is reused
		matrix squareB = QRGS.inverse(squareA);
		squareB.print("Inverse of square A");
		matrix AB = squareA * squareB;
		AB.print("A*B");
		System.Console.WriteLine($"Does AB=I :{AB.approx(identity4)}");
	}
}
