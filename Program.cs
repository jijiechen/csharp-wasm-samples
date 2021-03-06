using System;
using System.Runtime.InteropServices;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Debug.IndentLevel = 2;
PrintLine("start");
PrintLine("Hello World from C# by Jijie Chen!");
PrintLine("end");
        }

	   private static unsafe void PrintString(string s)
    {
        int length = s.Length;
        fixed (char* curChar = s)
        {
            for (int i = 0; i < length; i++)
            {
                TwoByteStr curCharStr = new TwoByteStr();
                curCharStr.first = (byte)(*(curChar + i));
                printf((byte*)&curCharStr, null);
            }
        }
    }

    public static void PrintLine(string s)
    {
        PrintString(s);
        PrintString("\n");
    }

	    [DllImport("*")]
    private static unsafe extern int printf(byte* str, byte* unused);
    }

    public struct TwoByteStr
    {
      public byte first;
      public byte second;
    }
}
