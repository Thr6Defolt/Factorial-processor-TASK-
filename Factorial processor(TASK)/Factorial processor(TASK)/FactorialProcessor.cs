﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial_processor_TASK_
{
    internal class FactorialProcessor
    {
        public void Go(int param, bool parallelMode)
        {
            Stopwatch stopWatch = new Stopwatch();
            if (param <= 15)
            {
                if (parallelMode == false)
                {
                    stopWatch.Start();
                    for (int i = 1; i <= param; i++)
                    {
                        Console.WriteLine($"Послідовно {CalculateFactorial(i)}");
                    }
                    stopWatch.Stop();

                    TimeSpan ts = stopWatch.Elapsed;

                    string elapsedTime = String.Format("{0:00}.{1:000}",
                        ts.Seconds, ts.Milliseconds);
                    Console.WriteLine("RunTime " + elapsedTime);
                }

                else if (parallelMode == true)
                {
                    stopWatch.Start();
                    Task[] tasks = new Task[param];
                    for (int i = 1; i <= param; i++)
                    {
                        tasks[i - 1] = Task.Run(() =>
                        {
                            Console.WriteLine($"Паралельно {CalculateFactorial(i)}");
                        });
                    }

                    Task.WaitAll(tasks);
                    stopWatch.Stop();

                    TimeSpan ts = stopWatch.Elapsed;

                    string elapsedTime = String.Format("{0:00}.{1:000}",
                        ts.Seconds, ts.Milliseconds);
                    Console.WriteLine("RunTime " + elapsedTime);
                }
                else
                {
                    Console.WriteLine("Erorr");
                }
            }
            else
            {
                Console.WriteLine("Erorr");
            }
        }
        private int CalculateFactorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            return n * CalculateFactorial(n - 1);
        }
    }
}
