all: out.txt; cat $<

out.txt: main.exe
		mono $< > $@

main.exe : main.cs QRGS.dll matrix.dll
	mcs -target:exe -reference:QRGS.dll -reference:matrix.dll -out:main.exe main.cs

out.times.data : main.exe
	>$@
	for N in $$(seq 100 20 200); do \
		time --format "$$N %e" --output $@ --append \
		mono $< -size:$$N 1>out 2>err ;\
	done

matrix.dll : vector.cs matrix.cs
	mcs -target:library -out:matrix.dll vector.cs matrix.cs

QRGS.dll : QRGS.cs matrix.dll
	mcs -target:library -out:QRGS.dll -reference:matrix.dll QRGS.cs

clean:
		$(RM) *.dll *.exe [Oo]ut*