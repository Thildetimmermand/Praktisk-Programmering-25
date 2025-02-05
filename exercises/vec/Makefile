Out.txt : vec.exe
	mono $< > $@

vec.exe : vec.cs vec.dll
	mcs -target:exe -reference:vec.dll -out:vec.exe vec.cs

vec.dll : veclib.cs
	mcs -target:library -out:vec.dll veclib.cs

.PHONEY: clean
clean:
	$(RM) vec.dll vec.exe Out.txt
