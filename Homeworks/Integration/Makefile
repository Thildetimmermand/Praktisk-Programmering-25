out.txt: main.exe
	mono main.exe > out.txt

library.dll: integrator.cs
	mcs -target:library -out:library.dll integrator.cs

main.exe: main.cs library.dll
	mcs -target:exe -out:main.exe -reference:library.dll main.cs

errorfunc.svg : Errorfunc.txt Makefile
	echo "\
		set terminal svg background 'white' ;\
		set out '$@';\
		set xlabel 'x' ;\
		set ylabel 'Errorfunction(x)' ;\
		set key top right ;\
		set grid ;\
		set yrange [-1:1] ;\
		set xrange [-3:3] ;\
		set title 'Errorfunction' ;\
		plot 'Errorfunc.txt' using 1:2 with points pointtype 7 pointsize 0.5 title 'erf(x)';\
	" | tee log.gpi | gnuplot

clean:
	rm -f *.dll *.exe *.svg *.txt *.gpi