using System.Diagnostics;

namespace Parallel_Lab2;

class Program
{
    static void Main(string[] args)
    {
        const int numsSize = 200000000;
        const int numToCompare = 101010;
        const int threadAmount = 192;

        NumList nums = new NumList(numsSize);
        nums.FillWithRands();
        
        Console.WriteLine($"List size: {numsSize}");
        Console.WriteLine($"Thread amount: {threadAmount}\n");
        
        Console.WriteLine("------------Linear solution------------");
        ExecuteLinear(nums, numToCompare);
        Console.WriteLine("---------------------------------------\n");
        
        Console.WriteLine("------------Mutex solution-------------");
        ExecuteMutex(nums, numToCompare, threadAmount);
        Console.WriteLine("---------------------------------------\n");
        
        Console.WriteLine("------------Atomic solution------------");
        ExecuteAtomic(nums, numToCompare, threadAmount);
        Console.WriteLine("---------------------------------------\n");
    }

    static void ExecuteLinear(NumList nums, int numToCompare)
    {
        Stopwatch stopwatch = new Stopwatch();
        
        stopwatch.Start();
        long count = nums.CountBiggerNumbers(numToCompare);
        stopwatch.Stop();
        
        long countTime = stopwatch.ElapsedMilliseconds;
        stopwatch.Reset();
        
        stopwatch.Start();
        int max = nums.FindMax();
        stopwatch.Stop();
        
        long searchTime = stopwatch.ElapsedMilliseconds;
        stopwatch.Reset();
        
        PrintInfo(countTime, searchTime, numToCompare, count, max);
    }
    
    static void ExecuteMutex(NumList nums, int numToCompare, int threadAmount)
    {
        Stopwatch stopwatch = new Stopwatch();
        
        stopwatch.Start();
        long count = nums.CountBiggerNumbersMutex(numToCompare, threadAmount);
        stopwatch.Stop();
        
        long countTime = stopwatch.ElapsedMilliseconds;
        stopwatch.Reset();
        
        stopwatch.Start();
        int max = nums.FindMaxMutex(threadAmount);
        stopwatch.Stop();
        
        long searchTime = stopwatch.ElapsedMilliseconds;
        stopwatch.Reset();
        
        PrintInfo(countTime, searchTime, numToCompare, count, max);
    }
    
    static void ExecuteAtomic(NumList nums, int numToCompare, int threadAmount)
    {
        Stopwatch stopwatch = new Stopwatch();
        
        stopwatch.Start();
        long count = nums.CountBiggerNumbersAtomic(numToCompare, threadAmount);
        stopwatch.Stop();
        
        long countTime = stopwatch.ElapsedMilliseconds;
        stopwatch.Reset();
        
        stopwatch.Start();
        int max = nums.FindMaxAtomic(threadAmount);
        stopwatch.Stop();
        
        long searchTime = stopwatch.ElapsedMilliseconds;
        stopwatch.Reset();
        
        PrintInfo(countTime, searchTime, numToCompare, count, max);
    }

    static void PrintInfo(long countTime, long searchTime, int numToCompare, long count, int max)
    {
        Console.WriteLine($"Count time: {countTime}");
        Console.WriteLine($"Search time: {searchTime}");
        Console.WriteLine($"Total time: {countTime + searchTime}\n");
        Console.WriteLine($"Elements bigger than {numToCompare}: {count}");
        Console.WriteLine($"Max number: {max}");
    }
}