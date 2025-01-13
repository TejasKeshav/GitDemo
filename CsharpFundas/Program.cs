using System;
namespace CSharpFundas;
 class Program : Program4 {

    public void getData()
    {
        Console.WriteLine("I am inside method");
    }
    public static void Main(string[] args)
    {

        Program p = new Program();
        p.getData();

        int a = 4;
        String name = "rahul";
        Console.WriteLine("Hello World!");
        Console.WriteLine(a);
        Console.WriteLine(name);
        var age = 23;
        dynamic height = "13.2";
        height = "hello";
        Console.WriteLine(height);


        Console.WriteLine(age);


    }

    
}
