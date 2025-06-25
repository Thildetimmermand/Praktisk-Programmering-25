Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : main.cs library.dll
	mcs -target:exe -out:main.exe -reference:library.dll main.cs

library.dll : matrix.cs vector.cs svd.cs
	mcs -target:library -out:library.dll matrix.cs vector.cs svd.cs

clean:
	rm -f *.dll *.txt main.exe