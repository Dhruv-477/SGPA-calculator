# SGPA Calculator

A comprehensive C# console application for calculating **SGPA (Semester Grade Point Average)** and **CGPA (Cumulative Grade Point Average)** for students.

## Features

- 📊 **SGPA Calculation**: Calculate grade point average for individual semesters
- 📈 **CGPA Calculation**: Calculate cumulative grade point average across multiple semesters
- ✅ **Input Validation**: Robust validation for grade points (0-10), credit hours, and subject names
- 💻 **Interactive Console Interface**: User-friendly command-line interface
- 📝 **Detailed Reports**: Comprehensive summary reports with semester-wise breakdown
- 🧪 **Built-in Tests**: Automated tests to verify calculation accuracy

## How SGPA and CGPA Work

### SGPA (Semester Grade Point Average)
```
SGPA = Σ(Grade Point × Credit Hours) / Σ(Credit Hours)
```
Calculated for a single semester using all subjects in that semester.

### CGPA (Cumulative Grade Point Average)
```
CGPA = Σ(Grade Point × Credit Hours for all semesters) / Σ(Credit Hours for all semesters)
```
Calculated across all semesters to give an overall academic performance measure.

## Usage

### Running the Application

1. **Clone or download** this repository
2. **Navigate** to the SGPACalculator directory
3. **Build** the application:
   ```bash
   dotnet build
   ```
4. **Run** the application:
   ```bash
   dotnet run
   ```

### Running Tests

To verify the calculations are working correctly:
```bash
dotnet run test
```

### Using the Interactive Interface

1. **Enter student name** when prompted
2. **Choose from menu options**:
   - `1` - Add semester data (subjects, grade points, credit hours)
   - `2` - View SGPA for a specific semester
   - `3` - View CGPA and complete summary
   - `4` - Exit application

### Example Usage

```
=================================
   SGPA & CGPA Calculator
=================================

Enter student name: John Doe

Options:
1. Add semester data
2. View SGPA for specific semester
3. View CGPA and summary
4. Exit
Choose an option (1-4): 1

Enter semester number: 1
Enter number of subjects: 3

Subject 1:
  Subject name: Mathematics
  Grade point (0-10): 9.0
  Credit hours: 4
  Added: Mathematics (9 GP, 4 CH)

Subject 2:
  Subject name: Physics
  Grade point (0-10): 8.5
  Credit hours: 3
  Added: Physics (8.5 GP, 3 CH)

Subject 3:
  Subject name: Programming
  Grade point (0-10): 9.5
  Credit hours: 4
  Added: Programming (9.5 GP, 4 CH)

Semester 1 added successfully!
SGPA for Semester 1: 9.05
```

## Project Structure

```
SGPACalculator/
├── Program.cs              # Main entry point
├── ConsoleInterface.cs     # Interactive console interface
├── Student.cs              # Student class with CGPA calculation
├── Semester.cs             # Semester class with SGPA calculation
├── Subject.cs              # Subject class with grade points and credits
├── CalculatorTests.cs      # Automated tests
└── SGPACalculator.csproj   # Project configuration
```

## Key Classes

### Subject
- Represents a single subject with name, grade point (0-10), and credit hours
- Validates input parameters
- Calculates weighted grade points

### Semester
- Contains multiple subjects for a specific semester
- Calculates total credit hours and weighted grade points
- Computes SGPA for the semester

### Student
- Manages multiple semesters for a student
- Calculates overall CGPA across all semesters
- Provides detailed academic summary reports

## Input Validation

- **Grade Points**: Must be between 0.0 and 10.0
- **Credit Hours**: Must be positive integers
- **Subject Names**: Cannot be empty or whitespace
- **Semester Numbers**: Must be positive integers

## Requirements

- **.NET 8.0** or later
- **Windows, macOS, or Linux**

## Building from Source

```bash
# Clone the repository
git clone <repository-url>
cd SGPA-calculator/SGPACalculator

# Build the application
dotnet build

# Run the application
dotnet run

# Run tests
dotnet run test
```

## Example Calculations

### SGPA Example
For a semester with:
- Mathematics: 9.0 GP × 4 CH = 36.0
- Physics: 8.5 GP × 3 CH = 25.5
- Programming: 9.5 GP × 4 CH = 38.0

SGPA = (36.0 + 25.5 + 38.0) ÷ (4 + 3 + 4) = 99.5 ÷ 11 = **9.05**

### CGPA Example
Across 2 semesters:
- Semester 1: 99.5 weighted GP, 11 credits
- Semester 2: 85.0 weighted GP, 10 credits

CGPA = (99.5 + 85.0) ÷ (11 + 10) = 184.5 ÷ 21 = **8.79**

## Contributing

Feel free to submit issues, feature requests, or pull requests to improve this calculator.

## License

This project is open source and available under the [MIT License](LICENSE).