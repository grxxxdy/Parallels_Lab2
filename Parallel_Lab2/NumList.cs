namespace Parallel_Lab2;

public class NumList
{
    private List<int> _nums;

    public NumList(int size)
    {
        _nums = new List<int>(size);
    }

    public void FillWithRands()
    {
        Random rand = new Random();
        
        for (int i = 0; i < _nums.Capacity; i++)
        {
            _nums.Add(rand.Next(0, 10001));
        }
    }

    public int CountBiggerNumbers(int numToCompare)
    {
        int counter = 0;
        
        foreach (var num in _nums)
        {
            if (num > numToCompare) counter++;
        }

        return counter;
    }

    public int FindMax()
    {
        int maxNum = -1;
        
        foreach (var num in _nums)
        {
            if (num > maxNum) maxNum = num;
        }

        return maxNum;
    }

    public int CountBiggerNumbersMutex(int numToCompare, int threadAmount)
    {
        int counter = 0;

        Mutex mutex = new Mutex();

        Thread[] threads = new Thread[threadAmount];
        int rowsPerThread = _nums.Count / threadAmount;
        
        for (int t = 0; t < threadAmount; t++)
        {
            int start = rowsPerThread * t;
            int finish = (t == threadAmount - 1) ? _nums.Count : start + rowsPerThread;
            
            threads[t] = new Thread(() =>
            {
                int localCount = 0;
                
                for (int i = start; i < finish; i++)
                {
                    if (_nums[i] > numToCompare)
                    {
                        localCount++;
                    }
                }
                
                mutex.WaitOne();
                counter += localCount;
                mutex.ReleaseMutex();
            });
            
            threads[t].Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return counter;
    }

    public int FindMaxMutex(int threadAmount)
    {
        int maxNum = -1;
        
        Mutex mutex = new Mutex();

        Thread[] threads = new Thread[threadAmount];
        int rowsPerThread = _nums.Count / threadAmount;
        
        for (int t = 0; t < threadAmount; t++)
        {
            int start = rowsPerThread * t;
            int finish = (t == threadAmount - 1) ? _nums.Count : start + rowsPerThread;
            
            threads[t] = new Thread(() =>
            {
                int localMax = -1;
                
                for (int i = start; i < finish; i++)
                {
                    if (_nums[i] > localMax)
                    {
                        localMax = _nums[i];
                    }
                }
                
                mutex.WaitOne();
                if (localMax > maxNum)
                {
                    maxNum = localMax;
                }
                mutex.ReleaseMutex();
            });
            
            threads[t].Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return maxNum;
    }
}