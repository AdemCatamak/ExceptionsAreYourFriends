using System;
using BenchmarkDotNet.Running;

namespace BenchmarkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ExceptionVsOperationResult>();
        }
    }
}