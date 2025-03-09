namespace Parallel_Lab2;

public class NumList
{
    private List<int> _nums;
    private int _counter;

    public NumList(int size)
    {
        _nums = new List<int>(size);
        _counter = 0;
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
        foreach (var num in _nums)
        {
            if (num > numToCompare)
            {
                _counter++;
            }
        }

        return _counter;
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
}