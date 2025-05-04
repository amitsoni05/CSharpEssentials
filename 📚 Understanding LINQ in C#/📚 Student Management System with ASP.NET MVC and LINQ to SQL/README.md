
# 📚 **Student Management System with ASP.NET MVC and LINQ to SQL**

Welcome to the Student Management System! This application allows you to **Create**, **Read**, **Update**, and **Delete** student records using ASP.NET MVC and LINQ to SQL. 🎉


## 🛠️ **Setup**

1. **Open Visual Studio**:
   - Start Visual Studio and create a new application.
   - Select **Visual C#** → **Web** → **ASP.NET Web Application**.
   - Choose **ASP.NET MVC 5** and click **OK**.

2. **Name Your Project**:
   - Enter the name `CodeASP_MVC` and click **OK**.
   - Make sure to check the **MVC** option to include the necessary folders and files.

## 🗂️ **Create Database**

1. **Add Database**:
   - Right-click on the **App_Data** folder.
   - Choose **Add** → **New Item** → **SQL Server Database**.
   - Name it `StudentDB` and click **Add**.

2. **Create Table**:
   - Open the **Server Explorer**.
   - Expand **StudentDB** → **Tables**.
   - Right-click on **Tables** and select **New Query**.

   Paste the following SQL query to create the `Student` table:

   ```sql
   CREATE TABLE Student (
       ID INT PRIMARY KEY IDENTITY,
       Name NVARCHAR(50),
       Gender NVARCHAR(10),
       Age INT,
       Standard NVARCHAR(10)
   );
   ```

   - Click **Execute** to run the query and create the table.

3. **Insert Sample Data**:
   - Right-click on the **Student** table and choose **Show Table Data**.
   - Add the following records:

     | Name    | Gender | Age | Standard |
     |---------|--------|-----|----------|
     | Anil    | Male   | 17  | 11       |
     | Farah   | Female | 18  | 12       |
     | Sama    | Male   | 19  | 12       |

   - Refresh the table to see the inserted records.

## 🔧 **Add Controller**

1. **Create Controller**:
   - Right-click on the **Controllers** folder.
   - Choose **Add** → **Controller**.
   - Select **MVC 5 Controller - Empty** and name it `HomeController`.
   - Click **Add**.

2. **Configure LINQ to SQL**:
   - Right-click on the **Models** folder.
   - Choose **Add** → **New Item**.
   - Select **Visual C#** → **Data** → **LINQ to SQL Classes**.
   - Name the file `StudentDB.dbml` and click **Add**.

3. **Define ORM Mapping**:
   - Drag and drop the **Student** table from **Server Explorer** into the LINQ to SQL Classes designer.
   - This will generate the class and properties for the table.

## 🎨 **Features**

### 1. **Create New Student** ✏️

- **Navigate to:** `Create` page.
- **Form:** Fill out the form with student details.
- **Error Handling:** Errors will be displayed if any field is missing.
- **Action:** Click `Create` to add the student to the database.

   Upon successful creation, you'll be redirected to the `Index` view showing all students.

   **Example Code:**

   ```csharp
   [HttpPost]
   public ActionResult Create(Student student)
   {
       if (ModelState.IsValid)
       {
           db.Students.InsertOnSubmit(student);
           db.SubmitChanges();
           return RedirectToAction("Index");
       }
       return View(student);
   }
   ```

### 2. **Read Student Records** 📋

- **Navigate to:** `Index` page.
- **View:** Displays a list of all students.
- **Columns:** Name, Gender, Age, Standard, and ID.

   **Example Code:**

   ```csharp
   public ActionResult Index()
   {
       var students = db.Students.ToList();
       return View(students);
   }
   ```

### 3. **Update Student Information** 🛠️

- **Navigate to:** `Edit` page by clicking the `Edit` button next to a student record.
- **Form:** Update the student's details.
- **Error Handling:** Ensure all fields are filled to avoid errors.
- **Action:** Click `Save` to update the record.

   Upon successful update, you'll be redirected to the `Index` view with updated information.

   **Example Code:**

   ```csharp
   [HttpPost]
   public ActionResult Edit(Student student)
   {
       if (ModelState.IsValid)
       {
           db.Students.Attach(student);
           db.Refresh(RefreshMode.KeepCurrentValues, student);
           db.SubmitChanges();
           return RedirectToAction("Index");
       }
       return View(student);
   }
   ```

### 4. **Delete Student Records** ❌

- **Navigate to:** `Index` page.
- **Action:** Click the `Delete` button next to a student record.
- **Confirmation:** Confirm deletion to remove the student from the database.

   **Example Code:**

   ```csharp
   [HttpPost]
   public ActionResult Delete(int id)
   {
       var student = db.Students.SingleOrDefault(s => s.ID == id);
       if (student != null)
       {
           db.Students.DeleteOnSubmit(student);
           db.SubmitChanges();
       }
       return RedirectToAction("Index");
   }
   ```

## 🛠️ **How It Works**

### Create

1. When you click the `Create` button, a POST request is made to handle the data submission.
2. Data is validated and then stored in the database using `InsertOnSubmit`.
3. After successful insertion, a redirect is made to the `Index` view.

### Edit

1. Clicking `Edit` directs to the `Edit` view with a form pre-populated with the student’s current details.
2. A POST request updates the student record with the new details.
3. After successful update, a redirect is made to the `Index` view.

### Delete

1. Clicking `Delete` removes the student record from the database.
2. The list of students is refreshed on the `Index` view after deletion.

## 📄 **Code Overview**

- **Models**: Define your database structure.
- **Controllers**: Handle user requests and interact with models.
- **Views**: Display data to users.

