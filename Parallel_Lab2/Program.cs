using System.Diagnostics;

namespace Parallel_Lab2;

class Program
{
    static void Main(string[] args)
    {
        const int numsSize = 100000000;
        const int numToCompare = 101;

        NumList nums = new NumList(numsSize);
        Stopwatch stopwatch = new Stopwatch();
        
        stopwatch.Start();
        nums.FillWithRands();
        stopwatch.Stop();

        long fillTime = stopwatch.ElapsedMilliseconds;
        stopwatch.Reset();
        
        stopwatch.Start();
        int count = nums.CountBiggerNumbers(numToCompare);
        stopwatch.Stop();
        
        long countTime = stopwatch.ElapsedMilliseconds;
        stopwatch.Reset();
        
        stopwatch.Start();
        int max = nums.FindMax();
        stopwatch.Stop();
        
        long searchTime = stopwatch.ElapsedMilliseconds;
        stopwatch.Reset();
        
        Console.WriteLine($"List size: {numsSize}\n");
        Console.WriteLine($"Fill time: {fillTime}");
        Console.WriteLine($"Count time: {countTime}");
        Console.WriteLine($"Search time: {searchTime}");
        Console.WriteLine($"Total time: {fillTime + countTime + searchTime}\n");
        Console.WriteLine($"Elements bigger than {numToCompare}: {count}");
        Console.WriteLine($"Max number: {max}");
        
    }
}