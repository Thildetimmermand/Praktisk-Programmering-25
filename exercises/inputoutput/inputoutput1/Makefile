Out.txt: inputoutput.exe input.txt
	mono inputoutput.exe $(shell cat input.txt) > Out.txt

inputoutput.exe: inputoutput.cs
	mcs -target:exe -out:inputoutput.exe inputoutput.cs

input.txt:
	@echo "-numbers:1,2,3,4,5" > input.txt

clean:
	rm -f Out.txt inputoutput.exe input.txt
