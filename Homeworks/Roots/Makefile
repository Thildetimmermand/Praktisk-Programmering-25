EXEC = main.exe
SRC = main.cs vector.cs matrix.cs QRGS.cs newton.cs jacobian.cs
OUT_TXT = Out.txt

# Default rule
all: $(OUT_TXT)

# Compile
$(EXEC): $(SRC)
	mcs -target:exe -out:$@ $(SRC)

# Run the executable to generate Out.txt
$(OUT_TXT): $(EXEC)
	mono $(EXEC) > $(OUT_TXT)

# Clean up
clean:
	rm -f $(EXEC) $(OUT_TXT)
