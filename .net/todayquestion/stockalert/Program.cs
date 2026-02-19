using System;

public class ThresholdChangedEventArgs<T> : EventArgs
{
    public T OldValue { get; set; }
    public T NewValue { get; set; }
    public string Message { get; set; } = "";
}

public class ThresholdMonitor<T> where T : IComparable<T>
{
    private readonly T _threshold;
    private T _current;

    public ThresholdMonitor(T threshold, T initial)
    {
        _threshold = threshold;
        _current = initial;
    }

    public event EventHandler<ThresholdChangedEventArgs<T>>? ThresholdCrossed;

    public void Update(T newValue)
    {
        // Check if threshold is crossed
        bool wasBelow = _current.CompareTo(_threshold) < 0;
        bool isNowAboveOrEqual = newValue.CompareTo(_threshold) >= 0;

        if (wasBelow && isNowAboveOrEqual)
        {
            ThresholdCrossed?.Invoke(this, new ThresholdChangedEventArgs<T>
            {
                OldValue = _current,
                NewValue = newValue,
                Message = $"Threshold {_threshold} crossed!"
            });
        }

        // Update current value
        _current = newValue;
    }
}

public class Program
{
    public static void Main()
    {
        var monitor = new ThresholdMonitor<int>(threshold: 100, initial: 90);

        monitor.ThresholdCrossed += (sender, e) =>
        {
            Console.WriteLine(e.Message);
            Console.WriteLine($"Old={e.OldValue}, New={e.NewValue}");
        };

        monitor.Update(95);    // No event
        monitor.Update(101);   // Event fires
    }
}
