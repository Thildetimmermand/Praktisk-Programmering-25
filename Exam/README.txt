Evaluation of project: 8.5 points

The goal of this assignment was to implement the one-sided Jacobi algorithm for computing the Singular Value Decomposition (SVD) of a real square matrix. The algorithm was successfully implemented based on the mathematical formulation provided in the assignment, using cyclic sweeps over pairs of columns and Jacobi rotations to orthogonalize them.

The code counts the number of full sweeps required to reach convergence, and this was achieved within a reasonable number of iterations (6–12) for matrix sizes up to 100×100. This confirms that the algorithm is both correct and efficient for reasonable matrix sizes.

The main implementation is located in svd.cs, which was then used in addition to vector.cs and matrix.cs as a library, which is structured into three stages:

    1. Iterative orthogonalization: A copy of the original matrix is created and repeatedly rotated via Jacobi transformations to drive the column vectors toward orthogonality.

    2. Convergence control: A convergence loop tracks whether any significant changes occur during a sweep over all column pairs. The total number of sweeps is counted and printed after convergence.

    3. Decomposition construction: After convergence, the orthogonal matrix V is returned from all the Jacobi rotations, D is constructed as a diagonal matrix of the norms of the orthogonalized columns, and U is formed by normalizing those columns.

I reused parts of the code from a previous homework about EVD (Eigenvalue Decomposition), this helped the implementation, especially the parts involving vector norms, dot products, and orthogonalization.

To verify correctness:
The decomposition was tested on randomly generated symmetric matrices.

It was shown that A=UDV^T reconstructs the original matrix within numerical precision. Both U and V were verified to be orthogonal. The diagonal matrix D contained non-negative values, as expected.

Additionally, the algorithm was validated analytically using a 3×3 matrix with known eigenvalues. The computed singular values matched the analytical results exactly, demonstrating the algorithm's correctness even in small-scale cases where theoretical results are known.

Finally, the algorithm’s performance was tested on matrices of increasing size (10×10 to 100×100), and in all cases, it converged efficiently and reconstructed the input matrix correctly.