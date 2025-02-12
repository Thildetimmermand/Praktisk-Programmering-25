Out.txt: inputoutput2.exe input.txt
	@mono inputoutput2.exe < input.txt 2> Out.txt

inputoutput2.exe: inputoutput2.cs
	mcs -target:exe -out:inputoutput2.exe inputoutput2.cs

input.txt:
	@echo "1 2 3 4 5" > input.txt

clean:
	rm -f Out.txt inputoutput2.exe input.txt
