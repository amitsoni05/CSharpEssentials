

# 📚 C# Class Library 

A C# Class Library is a collection of reusable classes, methods, and functions that can be shared across multiple applications. Building a class library helps promote code reuse, organization, and encapsulation of functionality. Here’s a brief tutorial to get you started with creating a C# Class Library:

## 1. 🎉 Creating a New Class Library

### Step 1: 🚀 Open Visual Studio
- Launch Visual Studio and go to `File` > `New` > `Project`.

### Step 2: 📝 Select the Project Type
- In the “Create a new project” window, select “Class Library” under the C# language. Choose `.NET Core` or `.NET Framework` based on your needs.

### Step 3: ⚙️ Configure the Project
- Enter a name for your class library, select a location to save the project, and click “Create”.

## 2. ✍️ Adding Classes and Methods

### Step 1: ➕ Add a Class
- Right-click on the project in the Solution Explorer, select `Add` > `Class`, and name your class (e.g., `MathUtilities.cs`).

### Step 2: 🛠️ Implement Methods
- Inside your class, add methods that provide the functionality you need. For example:

```csharp
namespace ClassLibrary
{
    public class MyUtility
    {
        public void SendEmail()
        {
            Console.WriteLine("Email Has Been Sent..");
        }
        public void SendSms()
        {
            Console.WriteLine("Sms Has Been Sent..");
        }

    }
}

```

## 3. 🏗️ Building the Class Library

- Click on `Build` > `Build Solution` to compile your library into a DLL (Dynamic Link Library).

## 4. 💻 Using the Class Library in a Project

### Step 1: 🆕 Create a New Console App
- Create a new Console App project in Visual Studio.

### Step 2: 📎 Add a Reference
- Right-click on the “Dependencies” or “References” node in the Solution Explorer of your Console App project.
- Select `Add Reference`.
- In the Reference Manager, go to the “Projects” section, and select the class library project you created earlier. Click “OK”.

### Step 3: 🔧 Use the Class Library
- In your Console App, add a `using` directive at the top to include your class library’s namespace, then use the classes and methods you defined:

```csharp
using ClassLibrary;

internal class Program
{
    private static void Main(string[] args)
    {
        MyUtility obj = new MyUtility();
        obj.SendEmail();
        obj.SendSms();
        Console.ReadLine();
    }
}
```



## 🎯 Additional Tips

- **Encapsulation**: Keep your classes and methods well-organized and encapsulated, exposing only the necessary components.
- **Documentation**: Document your code using XML comments to provide clear information to the users of your library.
- **Versioning**: Use version control for your library to manage updates and changes over time.

Creating a class library in C# is an effective way to encapsulate and share functionality across projects. With the steps above, you can create, use, and distribute your C# Class Library efficiently.
