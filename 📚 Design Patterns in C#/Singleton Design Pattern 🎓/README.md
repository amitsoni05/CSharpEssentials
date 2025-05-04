

# 🎓 **C# Design Patterns - Singleton Design Pattern** 🎓


### 📝 **Overview**

There are three main categories of design patterns:
1. **Creational**
2. **Behavioral**
3. **Structural**

The **Singleton Design Pattern** falls under the **Creational Design Patterns** category. 




### 💡 **Understanding Singleton Design Pattern**

The name **Singleton** itself gives us a hint—**single**. The main concept of the **Singleton Design Pattern** is to ensure that a class has only one instance and provides a global point of access to that instance. 🌍

#### 🛠️ **Without Singleton Design Pattern**

Normally, when we work with classes, we can create multiple objects. For example, if we have a class, we can create multiple objects like `c1`, `c2`, `c3`, etc. 

```csharp
var c1 = new MyClass();
var c2 = new MyClass();
var c3 = new MyClass();
```

Creating multiple objects consumes more memory 🧠, and this can impact the performance of your application. 🚶‍♂️

#### 🛡️ **With Singleton Design Pattern**

When we use the **Singleton Design Pattern**, we create a single instance of a class that will be used throughout the application. No additional instances can be created, ensuring that memory is conserved and performance is optimized. ⚡

```csharp
public class MyClass
{
    private static MyClass _instance;

    private MyClass() { }

    public static MyClass Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MyClass();
            }
            return _instance;
        }
    }
}
```

### 📈 **Benefits of Singleton Design Pattern**

1. **Memory Efficiency**: 🚀 By having only one instance, memory usage is minimized.
2. **Improved Performance**: 🏎️ With fewer instances, the application's performance is enhanced.
3. **Consistent Access**: 🌐 Throughout the application, the same instance is used, ensuring consistent data access.



