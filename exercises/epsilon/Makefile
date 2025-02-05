Out.txt : epsilon.exe
	mono epsilon.exe > Output.txt

epsilon.exe : epsilon.cs
	mcs -target:exe -out:epsilon.exe epsilon.cs

clean:
	rm -f Out.txt epsilon.exe
