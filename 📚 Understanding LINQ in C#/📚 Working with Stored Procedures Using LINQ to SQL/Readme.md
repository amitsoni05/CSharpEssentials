

# 📚 Working with Stored Procedures Using LINQ to SQL

Welcome to this comprehensive guide on **working with stored procedures** in C# using LINQ to SQL! We'll cover creating, modifying, and using stored procedures to manage and manipulate database data efficiently.

## 🚀 Overview

In this guide, we will explore:
1. Creating a stored procedure
2. Mapping it in LINQ to SQL
3. Modifying the stored procedure to include parameters
4. Implementing the modified procedure in a C# application

## 🛠️ Prerequisites

Ensure you have the following setup before proceeding:
- SQL Server Management Studio (SSMS)
- Visual Studio with LINQ to SQL class added to your project
- A database with a table named `Student`

## 📝 Creating a Stored Procedure

First, create a stored procedure in SQL Server to retrieve data from the `Student` table:

```sql
CREATE PROCEDURE [dbo].[SP_ShowStudents]
AS
BEGIN
    SELECT 
        ID, 
        Name, 
        Gender, 
        [Standard]
    FROM 
        Student
END
```

Execute this command in SQL Server, and you should see the stored procedure under the `Programmability > Stored Procedures` section in SSMS.

## 🔄 Mapping Stored Procedure in LINQ to SQL

To map the stored procedure in your C# application:
1. Open **Visual Studio** and navigate to the **Server Explorer**.
2. Right-click on your LINQ to SQL class and select `Update from Database`.
3. Expand the `Stored Procedures` folder, check the box next to `SP_ShowStudents`, and click `Finish`.

The stored procedure is now mapped to a method in your LINQ to SQL class.

## 🎯 Using Stored Procedure in C#

Call the stored procedure from your C# code as follows:

```csharp
using (StudentDataContext context = new StudentDataContext())
{
    var students = context.SP_ShowStudents();
    
    foreach (var student in students)
    {
        Console.WriteLine($"ID: {student.ID}, Name: {student.Name}, Gender: {student.Gender}, Standard: {student.Standard}");
    }
}
```

## 🛠️ Modifying a Stored Procedure

To modify an existing stored procedure to include a new parameter:

```sql
-- Existing stored procedure creation command
CREATE PROCEDURE SP_ShowStudents
AS
BEGIN
    SELECT * FROM Students;
END
GO

-- Modify the stored procedure to include a parameter
ALTER PROCEDURE SP_ShowStudents
    @Standard INT = NULL
AS
BEGIN
    IF @Standard IS NULL
    BEGIN
        SELECT * FROM Students;
    END
    ELSE
    BEGIN
        SELECT * FROM Students WHERE Standard = @Standard;
    END
END
GO
```

### Refresh the Stored Procedure

After altering the stored procedure, refresh it in your database management tool:
1. Navigate to the **Server Explorer**.
2. Right-click on the **Stored Procedures** folder.
3. Select **Refresh**.

### Implement in Your Application

Update the method in your application to use the modified stored procedure:

```csharp
public void LoadStudents(int? standard = null)
{
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        SqlCommand cmd = new SqlCommand("SP_ShowStudents", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        
        if (standard.HasValue)
        {
            cmd.Parameters.AddWithValue("@Standard", standard.Value);
        }
        else
        {
            cmd.Parameters.AddWithValue("@Standard", DBNull.Value);
        }

        conn.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        
        if (reader.HasRows)
        {
            // Load data into the grid view or similar
        }
        else
        {
            MessageBox.Show("No rows found");
        }
    }
}
```

### Handle User Input

Add a condition in your form to check if the user has entered any data in the input field:

```csharp
private void btnSearch_Click(object sender, EventArgs e)
{
    string classText = txtClass.Text;

    if (string.IsNullOrEmpty(classText))
    {
        MessageBox.Show("Please fill in the field");
    }
    else
    {
        int standard = int.Parse(classText);
        LoadStudents(standard);
    }
}
```

### Test Your Implementation

Run your application and test the stored procedure:
- ✅ Enter a valid standard (e.g., 11) and verify that the correct records are retrieved.
- ❌ Enter a non-existent standard (e.g., 99) and check that the "No rows found" message appears.
