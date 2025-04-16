out.txt : main.exe
	mono main.exe > out.txt

main.exe : main.cs ODE.dll
	mcs -target:exe -out:main.exe -reference:ODE.dll main.cs

ODE.dll : ODE.cs Vector.cs
	mcs -target:library -out:ODE.dll ODE.cs vector.cs

oscillator.svg : osc.txt oscwfriction.txt Makefile
	echo "\
		set terminal svg background 'white' ;\
		set out '$@' ;\
		set xlabel 'x' ;\
		set ylabel 'rel' ;\
		set grid ;\
		set title 'Pendulum with friction' ;\
		plot 'osc.txt' with lines smooth csplines title 'theta(t)', 'oscwfriction.txt' with lines smooth csplines title 'omega(t)';\
	" | tee log.gpi | gnuplot

orbit.svg : Newtonian.txt Elliptical.txt Rec.txt Makefile
	echo "\
		set terminal svg background 'white';\
		set output 'orbit.svg';\
		set title 'Comparison of Orbital Motion';\
		set grid;\
		set xlabel 'Angle (phi)';\
		set ylabel 'Radial Distance (r)';\
		set yrange [0.4:1.8]; \
		plot \
		'Newtonian.txt' using 1:2 with lines lw 2 lc rgb 'red' title 'Newtonian Circular', \
		'Elliptical.txt' using 1:2 with lines lw 2 lc rgb 'green' title 'Newtonian Elliptic', \
		'Rec.txt' using 1:2 with lines lw 2 lc rgb 'blue' title 'Relativistic Precession';\
	" | tee log.gpi | gnuplot

clean:
	rm -f *.dll *.exe [Oo]ut* *.svg *.png *.gpi *.txt