Out.txt : math.exe
	mono $< > $@

math.exe : math.cs sfuns.dll
	mcs -target:exe -out:math.exe -reference:sfuns.dll math.cs

sfuns.dll : sfuns.cs
	mcs -target:library -out:sfuns.dll sfuns.cs

clean:
	$(RM) sfuns.dll main.exe Out.txt

test:
	echo $(RM)
