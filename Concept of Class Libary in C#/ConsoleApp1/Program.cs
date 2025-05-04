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