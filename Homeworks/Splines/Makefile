SDKDIR=$(HOME)/.dotnet/sdk/6.0.102 # or whatever your sdk is
CSCPATH=$(SDKDIR)/Roslyn/bincore/csc.dll
NETSTANDARD=$(SDKDIR)/ref/netstandard.dll
CONFIG=$(SDKDIR)/vstest.console.runtimeconfig.json
DOTNET=DOTNET_CLI_TELEMETRY_OPTOUT=1; dotnet
CSC=$(DOTNET) $(CSCPATH) -reference:$(NETSTANDARD)
RUN=$(DOTNET) exec --runtimeconfig $(CONFIG)
CSC = mcs
RUN = mono

all: out.txt
	cat $<

out.txt: main.exe
	$(RUN) $< > $@

main.exe: main.cs library.dll
	$(CSC) -reference:library.dll $<

library.dll: splines.cs vector3.cs
	mcs -target:library -out:library.dll splines.cs vector3.cs

LinearSpline.svg : interpolated.txt dataPoints.txt Makefile
	echo "\
		set terminal svg background 'white' ;\
		set out '$@' ;\
		set xlabel 'x' ;\
		set ylabel 'rel' ;\
		set grid ;\
		set title 'Errorfunction' ;\
		plot 'interpolated.txt' using 1:2 with lines lt 7 lc rgb 'purple' notitle, \
		     'interpolated.txt' using 1:3 with lines lt 7 lc rgb 'green' notitle, \
		     'dataPoints.txt' using 1:2 with points lt 7 lc rgb 'red' notitle;\
	" | tee log.gpi | gnuplot

QSpline.svg : qinterpolated.txt qdatapoints.txt Makefile
	echo "\
		set terminal svg background 'white' ;\
		set out '$@' ;\
		set xlabel 'x' ;\
		set ylabel 'rel' ;\
		set grid ;\
		set title 'Errorfunction' ;\
		plot 'qinterpolated.txt' using 1:2 with lines lt 7 lc rgb 'purple' notitle, \
		     'qinterpolated.txt' using 1:3 with lines lt 7 lc rgb 'green' notitle, \
		     'qdatapoints.txt' using 1:2 with points lt 7 lc rgb 'red' notitle;\
	" | tee log.gpi | gnuplot

clean:
	$(RM) *.dll *.exe [Oo]ut* *.txt *.svg