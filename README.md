# EH CALCULATOR

## Prostředí

---------
<!---Ubuntu 64bit-->
`Windows 64bit`



## Autoři

Název týmu: `eh`
- `xkalaa00` Adam Kala 
- `xnguye22` Hoang Nam Nguyen 
- `xwagne12` Michal Wagner 

## Licence
-------

Tento program je poskytován pod licencí [GNU General Public License](LICENSE)



## Zprovoznění projektu
1. Stáhněte a nainstalujte si Visual Studio (https://visualstudio.microsoft.com/cs/)
2. Otevřete soubor `src/Calculator/Calculator.sln` v programu Visual Studio
3. Pro překlad stiskněte kombinaci kláves `Ctrl + Shift + B`
4. Pro překlad a spuštění stiskněte klávesu `F5`
5. Přeložené soubory najdete ve složce `src/Calculator/Calculator/bin/Debug/netcoreapp3.1/`
6. Spustíte dvojklikem na `Calculator.exe`



## Struktura projektu
- `installer` - složka s instalátorem
- `src/` 
  - `Calculator`
    - `Calculator`
      - `MainWindow.xaml` - GUI
      - `MainWindow.xaml.cs` - Interakce s GUI
      - `OperationHelper.cs` - Pomocné metody
    - `MathFunctions`
      - `MathFunctions.cs` - Matematická knihovna
    - `MathFunctions.Tests`
      - `MathFunctionTests.cs` - Testy pro matematickou knihovnu
