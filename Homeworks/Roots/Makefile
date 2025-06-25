EXEC = main.exe
SRC = main.cs vector.cs matrix.cs QRGS.cs newton.cs jacobian.cs ODE.cs hydrogen.cs
OUT_TXT = Out.txt
WAVE_TXT = wavefunction.dat
PLOT = wavefunction.svg

# Default rule
all: $(PLOT) $(OUT_TXT)

# Compile all source files
$(EXEC): $(SRC)
	mcs -target:exe -out:$@ $(SRC)

# Run the program to generate output and wavefunction files
$(OUT_TXT) $(WAVE_TXT): $(EXEC)
	mono $(EXEC) > $(OUT_TXT)
	@mv wavefunction.txt $(WAVE_TXT)
	@sed -i '' 's/,/\./g' $(OUT_TXT) || sed -i 's/,/\./g' $(OUT_TXT)   # macOS/Linux compatible
	@sed -i '' 's/,/\./g' $(WAVE_TXT) || sed -i 's/,/\./g' $(WAVE_TXT)

# Generate wavefunction plot using gnuplot
$(PLOT): $(WAVE_TXT) Makefile
	echo '\
	set term svg background "white";\
	set out "$@";\
	set title "Hydrogen Ground State Wavefunction";\
	set xlabel "r";\
	set ylabel "f(r)";\
	plot \
	 "$(WAVE_TXT)" using 1:2 with lines lw 3 lc rgb "blue" title "Numerical",\
	 "$(WAVE_TXT)" using 1:3 with lines lw 2 lc rgb "red" title "Exact (re^{-r})"\
	' | gnuplot

# Clean up
clean:
	rm -f $(EXEC) $(OUT_TXT) $(WAVE_TXT) $(PLOT)