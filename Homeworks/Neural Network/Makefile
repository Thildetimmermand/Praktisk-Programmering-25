Out.txt: main.exe
	mono main.exe > Out.txt

main.exe: main.cs library.dll
	mcs -target:exe -out:main.exe main.cs -r:library.dll

library.dll : ann.cs vector.cs matrix.cs QRGS.cs minimization.cs
	mcs -target:library -out:library.dll ann.cs vector.cs matrix.cs QRGS.cs minimization.cs

Ann_approx.svg: anndata.txt
	echo '\
	set term svg background "white";\
	set output "Ann_approx.svg";\
	set title "Artificial Neural Network Approximation of f(x) = cos(5x - 1) * exp(-x^2)";\
	set xlabel "x";\
	set ylabel "f(x)";\
	set key top right;\
	plot \
	 "anndata.txt" using 1:2 with lines title "Actual f(x)" lw 2 lc rgb "red",\
	 "anndata.txt" using 1:3 with lines title "Approximation" lw 2 lc rgb "blue"\
	' | gnuplot


clean:
	rm -f *.exe *.dll *.txt *.svg