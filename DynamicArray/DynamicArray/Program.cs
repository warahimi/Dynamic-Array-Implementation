using System;

namespace DynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MyDynamicArray da = new MyDynamicArray();
            // GenericDynamicArray<int> da = new GenericDynamicArray<int>();
            //da.Add(1);
            //da.Add(2);
            //da.Add(3);
            //da.Add(4);
            //da.Add(5);
            //da.Add(6);

            //GenericDynamicArray<char> da = new GenericDynamicArray<char>();
            //da.Add('A');
            //da.Add('B');
            //da.Add('C');
            //da.Add('D');

            GenericDynamicArray<string> da = new GenericDynamicArray<string>();
            da.Add("Code with cougar");
            da.Add("Wahidullah");
            da.Add("Rahimi");
            da.Add("Jan");

            


            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Empty: " + da.isEmpty());
            Console.WriteLine("Capacity: " + da.getCapacity());
            Console.WriteLine("Size: " + da.getSize());
            Console.WriteLine(da);
            Console.Write("Array Emelents: ");
            da.print();
            Console.WriteLine();
            Console.Write("Entire Array: ");
            da.printEntireArray();
            Console.WriteLine();
        }
    }
}