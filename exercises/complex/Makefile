Out.txt: main.exe
	mono main.exe > Out.txt

complex.dll: complex.cs
	mcs -target:library -out:complex.dll complex.cs

cmath.dll: cmath.cs complex.dll
	mcs -target:library -reference:complex.dll -out:cmath.dll cmath.cs

main.exe: main.cs cmath.dll complex.dll
	mcs -target:exe -reference:System.Numerics.dll -reference:cmath.dll -reference:complex.dll -out:main.exe main.cs

clean:
	rm -f Out.txt main.exe cmath.dll complex.dll

