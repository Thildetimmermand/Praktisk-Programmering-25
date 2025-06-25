using System;
using static System.Math;

public static class SVD {
    public static void jacobiSVD(matrix A, out matrix U, out matrix D, out matrix V) {
        int m = A.size1;
        int n = A.size2;
        matrix A_copy = A.copy(); // We'll work on a copy of A
        V = matrix.id(n); // Initialize V as identity

        double eps = 1e-10;
        bool changed;
        int sweeps = 0;

        do {
            changed = false;
            sweeps++;

            for (int p = 0; p < n; p++) {
                for (int q = p + 1; q < n; q++) {
                    // Get column p and q
                    vector ap = A_copy[p];
                    vector aq = A_copy[q];

                    // Compute required quantities
                    double apTap = ap.dot(ap);
                    double aqTaq = aq.dot(aq);
                    double apTaq = ap.dot(aq);

                    // Compute angle theta
                    double phi = 0.5 * Atan2(2 * apTaq, aqTaq - apTap);
                    double c = Cos(phi);
                    double s = Sin(phi);

                    // Rotate columns p and q of A_copy
                    for (int i = 0; i < m; i++) {
                        double aip = A_copy[i, p];
                        double aiq = A_copy[i, q];
                        A_copy[i, p] = c * aip - s * aiq;
                        A_copy[i, q] = s * aip + c * aiq;
                    }

                    // Rotate columns p and q of V
                    for (int i = 0; i < n; i++) {
                        double vip = V[i, p];
                        double viq = V[i, q];
                        V[i, p] = c * vip - s * viq;
                        V[i, q] = s * vip + c * viq;
                    }

                    if (Abs(phi) > eps) changed = true;
                }
            }
        } while (changed);

        // Compute D and U
        D = new matrix(n, n);
        U = new matrix(m, n);
        for (int i = 0; i < n; i++) {
            vector ai = A_copy[i];
            double norm = ai.norm();
            D[i, i] = norm;
            if (norm > 0) {
                for (int j = 0; j < m; j++) {
                    U[j, i] = ai[j] / norm;
                }
            } else {
                for (int j = 0; j < m; j++) {
                    U[j, i] = 0;
                }
            }
        }

        // Report how many sweeps were required
        Console.WriteLine($"Jacobi SVD converged in {sweeps} sweep(s).");
    }
}