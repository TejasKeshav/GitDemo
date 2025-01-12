using System;
using System.Security.Cryptography;

String[] a = {"hello","bye","rahul","shetty" };
int[] b = { 1, 2, 3, 4, 5, };
String[] a1 = new String[4];
//a1[0] = "hello";
//a1[1] = "bye";

//Console.WriteLine(a[2]);

for (int i=0;i<a.Length;i++) {
    //Console.WriteLine(a[i]);
    if (a[i]==("rahul"))
     {
        Console.WriteLine(a[i].IndexOf("rahul"));
    }
        
    }
    
