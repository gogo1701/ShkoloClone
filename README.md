# ShkoloClone - School Management System

A console-based school management system built with .NET 8 and RazorConsole, providing a comprehensive platform for managing students, teachers, classes, grades, and schools.

## Features

### For Students
- **View Grades**: Access all grades organized by subject with visual color-coding
- **Academic Performance**: See overall average and subject-specific averages
- **User Dashboard**: Easy navigation to view grades and account details

### For Teachers
- **Class Management**: View all assigned classes with student counts
- **Grade Entry**: Add grades for students in your classes
- **Student Management**: View students in each class and their individual grades
- **Subject Organization**: Organize grades by subject for easy tracking

### For Administrators
- **School Management**: Create and manage multiple schools
- **Class Creation**: Create classes with names, assign teachers, and add students
- **Room Management**: Add and manage school rooms
- **User Role Management**: Manage user roles and permissions
- **School Settings**: Update school information and website

## Technologies

- **.NET 8.0** - Framework
- **RazorConsole.Core** - Console UI framework
- **Spectre.Console** - Rich console UI components
- **JSON Database** - File-based data storage
- **Blazor/Razor Components** - UI component model

## Prerequisites

- .NET 8.0 SDK or later
- Windows OS (for console application)
- A terminal/console window

## Getting Started

### Installation

1. Clone the repository:
```bash
git clone <repository-url>
cd ShkoloClone/ShkoloClone/ShkoloClone
```

2. Restore dependencies:
```bash
dotnet restore
```

3. Build the project:
```bash
dotnet build
```

4. Run the application:
```bash
dotnet run
```

Or run the executable directly:
```bash
.\bin\Debug\net8.0\ShkoloClone.exe
```

## Project Structure

```
ShkoloClone/
├── Data/                  # Database context and JSON data access
│   ├── ApplicationDbContext.cs
│   └── DbContext.cs
├── Enums/                 # Application enumerations
│   └── AppUserEnum.cs
├── Models/                # Data models
│   ├── AppUser.cs
│   ├── Class.cs
│   ├── Grade.cs
│   ├── Result.cs
│   └── School.cs
├── Services/              # Business logic services
│   ├── AccountService.cs
│   ├── ClassService.cs
│   ├── GradeService.cs
│   ├── SchoolService.cs
│   ├── StudentService.cs
│   └── TeacherService.cs
├── UI/                    # User interface components
│   ├── Pages/
│   │   ├── Accounts/      # Login and registration
│   │   ├── Admin/         # Admin management pages
│   │   ├── Dashboard/     # User dashboards
│   │   ├── Student/       # Student pages
│   │   └── Teacher/       # Teacher pages
│   ├── App.razor
│   └── MainLayout.razor
├── bin/Debug/net8.0/
│   └── database.json      # JSON database file
├── Program.cs
└── ShkoloClone.csproj
```

## Default Login Credentials

The application comes with pre-populated sample data. Use these credentials to log in:

### Administrator
- **Username**: `admin`
- **Password**: `admin123`
- **Name**: Ivan Petrov

### Teachers
- **Username**: `teacher1` | **Password**: `teacher123` | **Name**: Maria Ivanova
- **Username**: `teacher2` | **Password**: `teacher123` | **Name**: Georgi Dimitrov
- **Username**: `teacher3` | **Password**: `teacher123` | **Name**: Elena Stoyanova

### Students
- **Username**: `student1` through `student10`
- **Password**: `student123`
- Sample names: Petar Georgiev, Anna Petrova, Nikolay Ivanov, etc.

## Sample Data

The application includes sample data:
- **3 Schools**: Sofia High School, Mathematics and Science Academy, Arts and Languages School
- **4 Classes**: Grade 5A (Mathematics), Grade 5B (Science), Grade 6A (Literature), Grade 7A (Advanced Mathematics)
- **20+ Grades**: Pre-populated grades across different subjects
- **Multiple Rooms**: Each school has various rooms and facilities

## Usage Guide

### Navigation
- Use **Tab** to navigate between options
- Press **Enter** to select/click
- Press **Ctrl+C** to exit the application

### Student Workflow
1. Log in with student credentials
2. Navigate to "View All Grades" from the dashboard
3. View grades organized by subject with color-coded averages
4. See overall academic performance

### Teacher Workflow
1. Log in with teacher credentials
2. Access "View My Classes" to see assigned classes
3. Select a class to view students
4. Use "Add Grade" to enter grades for students
5. View individual student grade histories

### Administrator Workflow
1. Log in with admin credentials
2. Access "School Settings" to manage schools
3. Create new classes with "Add Class"
4. Manage user roles and permissions
5. Add rooms and update school information

## Features Highlights

### Visual Grade Display
- **Color-coded averages**: 
  - 🟢 Green: Excellent (5.5+)
  - 🟡 Yellow: Good (4.5-5.49)
  - 🟠 Orange: Average (3.5-4.49)
  - 🔴 Red: Needs Improvement (<3.5)

### Class Management
- Named classes (e.g., "Grade 5A - Mathematics")
- Teacher assignment
- Student enrollment
- Class-to-school relationships

### Grade System
- Grade range: 2.00 - 6.00
- Subject-based organization
- Average calculations per subject and overall
- Multiple grades per subject support

## Configuration

The application uses a JSON-based database located at:
```
bin/Debug/net8.0/database.json
```

You can manually edit this file to add/modify data, or use the application's UI to manage data.

## Development Notes

- The application uses a file-based JSON database for simplicity
- All models include parameterless constructors for JSON deserialization
- Services follow a repository-like pattern
- UI components use Razor syntax with Spectre.Console for rendering

## Contributing

This is a learning project. Feel free to:
- Report issues
- Suggest improvements
- Fork and modify for your own use

## License

This project is for educational purposes.

## Acknowledgments

- Built with RazorConsole
- UI components powered by Spectre.Console

---

**Note**: This is a console application. Make sure you have a terminal window open to interact with the application. The UI is text-based and uses keyboard navigation.

