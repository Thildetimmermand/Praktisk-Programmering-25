out.txt : main.exe
	mono main.exe > out.txt

library.dll: matrix2.cs vector2.cs QRGS2.cs leastsquares.cs
	mcs -target:library -out:library.dll matrix2.cs vector2.cs QRGS2.cs leastsquares.cs

main.exe: main.cs library.dll
	mcs -target:exe -out:main.exe -reference:library.dll main.cs

rad.svg : datapoints.txt fit.txt envelope.txt Makefile
	echo "\
		set terminal svg background 'white' ;\
		set out '$@' ;\
		set xlabel 'Time (days)' ;\
		set ylabel 'Activity' ;\
		set key top right;\
		set logscale y ;\
		set grid ;\
		set title 'Radioactive decay' ;\
		plot 'datapoints.txt' using 1:2:3 with yerrorbars title 'Data',\
		'fit.txt' using 1:2 with lines title 'Best fit',\
		'envelope.txt' using 1:3 with lines title '1 sigma over',\
		'envelope.txt' using 1:4 with lines title '1 sigma under';\
	" | tee log.gpi | gnuplot
																															
clean:
		rm -f *.dll *.exe [Oo]ut* *.svg *.png *.gpi *.txt