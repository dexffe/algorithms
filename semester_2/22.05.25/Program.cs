using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Program
{
    unsafe static void Main()
    {
        bool isEnd = true;

        int* dict = stackalloc int[256];
        for (int i = 0; i < 256; i++)
        {
            dict[i] = 0;
        }
        while (isEnd)
        {
            string s = Console.ReadLine();
            isEnd = s == "" ? false : true;
            foreach (char c in s)
            {
                dict[c]++;
            }
        }
        for (int i = 0; i < 256; i++)
        {
            if (dict[i] != 0)
            {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    Console.WriteLine($"{(char)i}: {dict[i]}");
            }
        }
    }
}
