Out.txt: inputoutput3.exe input.txt
	@mono inputoutput3.exe -input:input.txt -output:Out.txt

inputoutput3.exe: inputoutput3.cs
	mcs -target:exe -out:inputoutput3.exe inputoutput3.cs

input.txt:
	echo "1" > input.txt
	echo "2" >> input.txt
	echo "3" >> input.txt
	echo "4" >> input.txt
	echo "5" >> input.txt

clean:
	rm -f Out.txt inputoutput3.exe input.txt
