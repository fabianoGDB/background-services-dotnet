using System.Collections.Concurrent;

namespace BackgroundServiceApp
{
    public class SampleData
    {
        public ConcurrentBag<string> Data { get; set; } = new();
    }
}
