

# 📚 Student Management System

Welcome to the **Student Management System**! This project is a Windows Forms application that allows you to manage student data, including inserting, updating, deleting, and displaying records. Built with LINQ to SQL in C#, it’s a comprehensive tool for handling CRUD operations with a user-friendly interface.

## 🎯 Objectives

In this project, you will learn how to:
- 💻 Create a Windows Forms application in Visual Studio.
- 🔗 Use LINQ to SQL for database operations.
- 📝 Implement basic CRUD operations with a student database.
- 🎨 Design an intuitive interface for managing student records.

## 🏗️ Project Structure

- `StudentManagementSystem/` - Main project folder with the Windows Forms application.
- `StudentManagementSystem/Database/` - Contains SQL scripts for creating the student database.
- `StudentManagementSystem/Forms/` - Form designs and controls used in the application.

## 📋 Features

- **Add Student**: Insert new student records.
- **Update Student**: Modify existing student details.
- **Delete Student**: Remove student records.
- **View Students**: Display all student data in a DataGridView.
- **Clear Fields**: Reset input fields automatically after operations.
- **Auto-Adjust Columns**: Ensure grid columns fit data without horizontal scrolling.

## 🚀 How to Use

1. **Launch the application**: Run the project in Visual Studio.
2. **Add Student**: Input student details and click "Insert".
3. **Update Student**: Select a record, edit the details, and click "Update".
4. **Delete Student**: Select a record and click "Delete".
5. **Clear Fields**: Use the "Clear" button to reset the input fields.

## 🗃️ Database Setup

1. **Create a database** in SQL Server:
   ```sql
   CREATE DATABASE StudentDB;
   ```
2. **Create a table** for students:
   ```sql
   CREATE TABLE Students (
       Id INT PRIMARY KEY IDENTITY,
       Name NVARCHAR(50),
       Gender NVARCHAR(10),
       Age INT,
       Class NVARCHAR(20)
   );
   ```

## 📝 Code Overview

### 1. Setting up the DataContext

Create a LINQ to SQL DataContext to connect to the database:

```csharp
public class StudentDataContext : DataContext
{
    public Table<Student> Students;

    public StudentDataContext(string connectionString) : base(connectionString) { }
}
```

### 2. Defining the Student Class

```csharp
[Table(Name = "Students")]
public class Student
{
    [Column(IsPrimaryKey = true, IsDbGenerated = true)]
    public int Id { get; set; }

    [Column]
    public string Name { get; set; }

    [Column]
    public string Gender { get; set; }

    [Column]
    public int Age { get; set; }

    [Column]
    public string Class { get; set; }
}
```

### 3. Insert Operation

```csharp
private void InsertStudent(string name, string gender, int age, string className)
{
    using (var context = new StudentDataContext(connectionString))
    {
        Student newStudent = new Student()
        {
            Name = name,
            Gender = gender,
            Age = age,
            Class = className
        };

        context.Students.InsertOnSubmit(newStudent);
        context.SubmitChanges();
        ClearTextBoxes();  // Clear input fields after insertion
        BindGridView();    // Refresh grid view
    }
}
```

### 4. Update Operation

```csharp
private void UpdateStudent(int id, string name, string gender, int age, string className)
{
    using (var context = new StudentDataContext(connectionString))
    {
        var studentToUpdate = context.Students.SingleOrDefault(s => s.Id == id);
        if (studentToUpdate != null)
        {
            studentToUpdate.Name = name;
            studentToUpdate.Gender = gender;
            studentToUpdate.Age = age;
            studentToUpdate.Class = className;
            context.SubmitChanges();
            ClearTextBoxes();  // Clear input fields after update
            BindGridView();    // Refresh grid view
        }
    }
}
```

### 5. Delete Operation

```csharp
private void DeleteStudent(int id)
{
    using (var context = new StudentDataContext(connectionString))
    {
        var studentToDelete = context.Students.SingleOrDefault(s => s.Id == id);
        if (studentToDelete != null)
        {
            context.Students.DeleteOnSubmit(studentToDelete);
            context.SubmitChanges();
            BindGridView();  // Refresh grid view after deletion
        }
    }
}
```

### 6. Display Students

```csharp
private void BindGridView()
{
    using (var context = new StudentDataContext(connectionString))
    {
        dgvStudents.DataSource = context.Students.ToList();
    }
}

private void AdjustGridViewColumns()
{
    dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
}
```

### 7. Clear Input Fields

```csharp
private void ClearTextBoxes()
{
    foreach (Control ctr in this.Controls)
    {
        if (ctr is TextBox txt)
        {
            txt.Clear();
        }
    }
    txtName.Focus();
}
```

## 💡 Best Practices

- Keep code modular and well-organized.
- Use meaningful names for controls and variables.
- Handle exceptions to ensure the application runs smoothly.
- Always clear input fields after operations to improve user experience.



