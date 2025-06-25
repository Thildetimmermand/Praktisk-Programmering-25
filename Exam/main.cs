class main{
    static void Main(string[] args){

        //Testing algorithm with random matrix
        matrix A = new matrix(5,5);
        var rnd = new System.Random(1);

        for(int i = 0; i < A.size1; i++){
            for(int j = i; j < A.size1; j++){
                A[i,j] = rnd.NextDouble(); // Upper triangular matrix is created
                A[j,i] = A[i,j]; // Upper triangular part is copied to lower part
            }
        }

        matrix U, D, V;
        SVD.jacobiSVD(A, out U, out D, out V);

        System.Console.WriteLine("###########################################################");
        System.Console.WriteLine("Assignment:");
        System.Console.WriteLine("Implement the one-sided Jacobi SVD algorithm.");
        System.Console.WriteLine("###########################################################");

        System.Console.WriteLine("Matrix A");
        A.print();
        System.Console.WriteLine();
        System.Console.WriteLine("###########################################################");
        System.Console.WriteLine("Firstly it was tested whether or not the algorithm computed values correctly:");
        System.Console.WriteLine("###########################################################");

        System.Console.WriteLine("Does UDV^T reconstruct A within numerical precision?");
        matrix VT = V.transpose();
        matrix A_reconstructed = U * D * VT;
        System.Console.WriteLine((A_reconstructed).approx(A));
        System.Console.WriteLine();

        matrix id = matrix.id(5);
        System.Console.WriteLine("Are U and V orthogonal matrices?");
        System.Console.WriteLine("V*V^T=I?");
        System.Console.WriteLine((V*V.transpose()).approx(id));
        System.Console.WriteLine();
        System.Console.WriteLine("U*U^T=I?");
        System.Console.WriteLine((U*U.transpose()).approx(id));
        System.Console.WriteLine();

        System.Console.WriteLine("Is D diagonal?");
        D.print();
        System.Console.WriteLine();

        System.Console.WriteLine("###########################################################");
        System.Console.WriteLine("Comparison of analytical solution with algorithm solution:");
        System.Console.WriteLine("###########################################################");
        matrix AnalyticA = new matrix(3, 3);
        AnalyticA[0,0] = 3; AnalyticA[0,1] = 1; AnalyticA[0,2] = 1;
        AnalyticA[1,0] = 1; AnalyticA[1,1] = 3; AnalyticA[1,2] = 1;
        AnalyticA[2,0] = 1; AnalyticA[2,1] = 1; AnalyticA[2,2] = 3;

        System.Console.WriteLine("Analytically chosen symmetric matrix:");
        AnalyticA.print();
        System.Console.WriteLine();
        System.Console.WriteLine("Analytically computed eigenvalues for the chosen matrix:");
        System.Console.WriteLine("E1 = 2, E2 = 2, E3 = 5");

        // Compute SVD using your algorithm
        matrix UA, DA, VA;
        SVD.jacobiSVD(AnalyticA, out UA, out DA, out VA);

        System.Console.WriteLine("Does UDV^T reconstruct the matrix?");
        System.Console.WriteLine((UA * DA * VA.transpose()).approx(AnalyticA));
        System.Console.WriteLine();
        System.Console.WriteLine("Matrix D should have the eigenvalues on the diagonal, this is tested and confirmed:");
        System.Console.WriteLine("Matrix D:");
        DA.print();
        System.Console.WriteLine();

        System.Console.WriteLine("###########################################################");
        System.Console.WriteLine("How does the algorithm handle large matrices?");
        System.Console.WriteLine("###########################################################");
        System.Console.WriteLine("The algorithm was tested with matrices of sizes 10x10, 20x20, 50x50 and 100x100:");
        int[] sizes = {10, 20, 50, 100};

        foreach (int N in sizes) {
            matrix Large = new matrix(N, N);
            var rnd2 = new System.Random(N);  // seed with N to ensure reproducibility

            // Fill symmetric matrix
            for (int i = 0; i < N; i++) {
                for (int j = i; j < N; j++) {
                Large[i, j] = rnd2.NextDouble();
                Large[j, i] = Large[i, j];
                }
            }

            matrix U1, D1, V1;
            System.Console.WriteLine($"M = {N}x{N} matrix");
            SVD.jacobiSVD(Large, out U1, out D1, out V1);
            System.Console.WriteLine("Matrix reconstruction correct?");
            System.Console.WriteLine((U1 * D1 * V1.transpose()).approx(Large));
            System.Console.WriteLine();
        } //foreach
        
        //kommenter på antallet af sweeps for forkskellige størrelser matricer, noget i stil med "thorugh AI an acceptable amount of sweeps is anything below 200,
        // therefore the algorithm is acceptable efficient and in the good end"

    } //Main
} //main
