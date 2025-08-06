# Surah Renamer Console App

## Overview
This C# console application renames audio files of Quran surahs in a given folder based on their numeric file names. It maps surah numbers to their correct Arabic names and renames the files in the format:
```
1- الفاتحة.mp3
2- البقرة.mp3
...
```

## Features
- **Automatic Renaming**: Maps numeric file names to surah names using a predefined dictionary.
- **Skip Already Renamed Files**: If a file already contains a dash (`-`) in its name, it is skipped.
- **Check If File Is Open**: Skips renaming if the file is currently in use.
- **Avoid Duplicate Names**: If the target file name already exists, it is skipped to prevent overwriting.
- **Preserves Original Extension**: Maintains `.mp3`, `.wav`, etc., as they are.

## How It Works
1. The program prompts the user to enter the folder path.
2. It verifies the folder exists.
3. For each file:
   - Checks if it has already been renamed.
   - Checks if it is locked (open in another program).
   - Parses the file name as a surah number.
   - Looks up the surah name from a dictionary.
   - Renames the file to `Number- SurahName.Extension`.
4. Skips files that don't meet renaming criteria.

## Usage
1. Clone this repository.
2. Open the project in Visual Studio or VS Code.
3. Build and run the project.
4. Enter the folder path containing surah files (named with numbers only).
5. The program will rename the files accordingly.

## Example
**Before:**
```
1.mp3
2.mp3
3.mp3
```
**After:**
```
1- الفاتحة.mp3
2- البقرة.mp3
3- آل عمران.mp3
```

## Notes
- Ensure the folder contains only surah files named as numbers.
- If a file is open in a player, it will be skipped until closed.
- Surah names are predefined in the code; no internet connection is required.
