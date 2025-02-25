using static System.Math;
public static class QRGS{

   //decomp - lineq pdf p. 3
   public static (matrix,matrix) decomp(matrix A){
      matrix Q=A.copy();
      matrix R=new matrix(A.size2,A.size2);
      /* orthogonalize Q and fill-in R */
      for(int i=0; i<A.size2; i++){
        R[i,i] = Q[i].norm();
        Q[i]/=R[i,i];
        for(int j=i+1; j<A.size2; j++){
            R[i,j] = Q[i].dot(Q[j]);
            Q[j] -=Q[i]*R[i,j];
        }
      }
      return (Q,R);
      }
   
   //solve - lineq pdf p. 2
   public static vector solve(matrix Q, matrix R, vector b){
    int n = Q.size1;
    vector QTb = Q.transpose()*b ;
    for(int i = n-1; i>=0; i--){
    double sum = 0;
    for(int j = i+1; j<n ; j++){
        sum += R[i,j]*QTb[j];
    }
    QTb[i] = (QTb[i] - sum) / R[i,i];
    }
    return QTb;
    }

   //det
   public static double det(matrix R){ 
    double determinant = 1.0; 
	for (int i = 0; i<R.size1; i++){
		determinant *= R[i,i];
		}
	return determinant; }

   //inverse
   public static matrix inverse(matrix A){
    int n = A.size1;
	matrix Ainverse = new matrix(n,n);
	(matrix Q, matrix R) = decomp(A);  // Compute QR once
    for(int i = 0; i<n; i++){
        vector e = new vector(n);
        e[i] = 1;  // Create unit vector correctly
        Ainverse[i] = solve(Q,R,e);
    }
		return Ainverse;}

    //Upper triangular
    public static bool isUpperTriangular(matrix R){
    for (int i = 0; i < R.size1; i++){
        for (int j = 0; j < i; j++){ // Elements below diagonal
            if (Abs(R[i,j]) > 1e-6) return false;
        }
    }
    return true;
}


}