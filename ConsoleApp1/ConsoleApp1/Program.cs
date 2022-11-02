using System;

namespace ConsoleApp1;

class Program
{
    static readonly System.Random _random;
    public void addProduct()
    {
        int id = (int)_random.NextInt64(100000, 999999);
        Console.WriteLine("enter :");

    }
    static void Main(string[] args)
    {
        Console.WriteLine("enter a number:");
        int number = int.Parse(Console.ReadLine());
        switch(number)
        { 
             case 0: break;
            case 1:
                Console.WriteLine("enter 1 for add an object,\n2 for show an object,\n 3 for show all of the objects,\n 4 for update, \n 5 for delete:");
                int choose = int.Parse(Console.ReadLine());
                switch (choose)
                { 
                    case 1:
                        addProduct();
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    default: break;

                }
      
           
        }

    }
}
