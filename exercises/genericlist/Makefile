Out.txt: genericlist.exe input.txt
	mono genericlist.exe < input.txt > Out.txt

genericlist.exe: genericlist.cs
	mcs -target:exe -out:genericlist.exe genericlist.cs

clean:
	rm -f Out.txt genericlist.exe input.txt	
