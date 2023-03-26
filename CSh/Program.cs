using System;
using System.Collections;
using System.ComponentModel.Design;
using static System.Collections.Specialized.BitVector32;

namespace Lesson2;

public static class Program
{
    public static int ReadInt()
    {
        Console.WriteLine("Введите объем массива:");

        try
        {
            var i = Console.ReadLine();
            int arraySize = int.Parse(i);
            return arraySize; 
        }
      
     
        catch (Exception)
        {
            Console.WriteLine("Неправильный тип данных");
            return 0;
        }
    }
    
    public static int ArrayNumber()//введение чисел массива
    {
        try
        {
            var n = Console.ReadLine();
            int number = int.Parse(n);
            return number;
        }
        catch (Exception)
        {
            Console.WriteLine("Неправильный тип данных");
            return 0;
        }
        
    }
    
    public static void Main() //введение чисел в массив
    {
        
        int i;
        
        int[] array = new int[ReadInt()];

        if (array.Length < 2)
        {
            Console.WriteLine("Объем массива должен быть больше или равен 2");
            
        }
        else
        {
            Console.WriteLine("Введите числа:");
            for (i = 0; i < array.Length; i++)
            {

                try
                {
                    array[i] = ArrayNumber();

                }
                catch (Exception)
                {
                    Console.WriteLine("Неправильный тип данных");
                }
            }
            Array.Sort(array);
           
            Console.WriteLine($"Второй наибольший элемент: {array[i - 2]}");
        }
        
    }
}




   
