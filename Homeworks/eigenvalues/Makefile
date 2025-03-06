Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs matvec.dll
	mcs -target:exe -out:main.exe -reference:matvec.dll main.cs

matvec.dll : matrix1.cs vector1.cs
	mcs -target:library -out:matvec.dll matrix1.cs vector1.cs

clean:
	rm -f *.dll *.txt main.exe