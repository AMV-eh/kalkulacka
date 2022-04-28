PROJ_FINAL = xnguye22_xwagne12_xkalaa00
PROJ_EXE = Calculator\Calculator\bin/Debug\netcoreapp3.1\Calculator.exe

all: run


pack: clean
	zip -r ../$(PROJ_FINAL).zip ../

clean:
	rmdir /s /Q "Calculator\Calculator\bin"
	rmdir /s /Q "Calculator\Calculator\obj"
	rmdir /s /Q "Calculator\MathFunctions\bin"
	rmdir /s /Q "Calculator\MathFunctions\obj"
	rmdir /s /Q "Calculator\MathFunctions.Tests\bin"
	rmdir /s /Q "Calculator\MathFunctions.Tests\obj"
	rmdir /s /Q "Calculator\.vs"
	rmdir /s /Q "html"
	rmdir /s /Q "latex"

run:
	$(PROJ_EXE)

help:
    @echo "all: spustí program"
    @echo "pack: zabalí projekt tak, aby mohl být odevzdán"
    @echo "clean: smaže všechny soubory, co nemají být odevzdány"
    @echo "run: spustí program"
    @echo "help: vypíše nápovědu s popisem"

