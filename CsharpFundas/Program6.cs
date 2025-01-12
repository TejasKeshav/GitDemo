using System;
using System.Collections;


ArrayList a = new ArrayList();
a.Add("hello");
a.Add("bye");
a.Add("rahul");
a.Add("Apple");

foreach (String item in a) { 

    Console.WriteLine(item);
    Console.WriteLine(a.Contains("rahul"));
    a.Sort();

}



