CODE = $(filter %.cs,$^)
LIBS = $(addprefix -reference:,$(filter %.dll,$^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

default: Out.erf.gnuplot.svg Out.gamma.gnuplot.svg Out.lngamma.gnuplot.svg

Out.erf.gnuplot.svg : Out.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set xlabel "x" ;\
		set ylabel "Erf(x)" ;\
		set grid ;\
		set title "Errorfunction" ;\
		plot \
			"Out.txt" with lines lc "red" notitle \
	'|tee log.gpi | gnuplot

Out.gamma.gnuplot.svg : Out2.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set xlabel "x" ;\
		set ylabel "gamma(x)" ;\
		set yrange [-5:5] ;\
		set grid ;\
		set title "Gammafunction" ;\
		plot \
			"Out2.txt" with lines lc "red" notitle \
	'|tee log2.gpi | gnuplot

Out.lngamma.gnuplot.svg : Out3.txt Makefile
	echo '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set xlabel "x" ;\
		set ylabel "lngamma(x)" ;\
		set yrange [1:10];\
		set grid ;\
		set title "lngammafunction" ;\
		plot \
			"Out3.txt" with lines lc "red" notitle \
	'|tee log3.gpi | gnuplot


sfuns.dll : sfuns.cs ; $(MKLIB)

mainerf.exe : mainerf.cs sfuns.dll ; $(MKEXE)

maingamma.exe : maingamma.cs sfuns.dll ; $(MKEXE)

mainlngamma.exe : mainlngamma.cs sfuns.dll ; $(MKEXE)

Out.txt : mainerf.exe
	mono $< > $@

Out2.txt : maingamma.exe
	mono $< > $@

Out3.txt : mainlngamma.exe
	mono $< > $@

clean: 
	$(RM) *.exe *.dll [Oo]ut* [Llog]* 