Out.txt : main.exe
	mono main.exe > Out.txt

library.dll : MC.cs Vectors.cs
	mcs -target:library -out:library.dll MC.cs Vectors.cs

main.exe : main.cs library.dll
	mcs -target:exe -out:main.exe -reference:library.dll main.cs

errorplot.svg : errordata.txt Makefile
	echo "\
		set terminal svg background 'white'; \
		set output '$@'; \
		set xlabel 'N (samples)'; \
		set ylabel 'Error'; \
		set title 'Monte Carlo Integration Error vs Sample Size'; \
		set grid; \
		set key top right; \
		set logscale x 10; \
		set logscale y 10; \
		set xrange [90:1100000]; \
		set style line 1 lt 1 lw 2 pt 7 ps 0.7 linecolor rgb 'blue'; \
		set style line 2 lt 1 lw 2 pt 7 ps 0.7 linecolor rgb 'red'; \
		set style line 3 lt 2 lw 2 dt (5,5) linecolor rgb 'black'; \
		C = 0.2; \
		plot \
			'errordata.txt' using 1:3 with linespoints ls 1 title 'Estimated error', \
			'errordata.txt' using 1:4 with linespoints ls 2 title 'Actual error', \
			C/sqrt(x) with lines ls 3 title '1/sqrt(N) reference' \
	" | tee log.gpi | gnuplot

clean:
	rm -f *.dll *.txt *.svg *.gpi main.exe