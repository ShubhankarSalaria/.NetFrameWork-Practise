using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

public class Order
{
    public int OrderId { get; set; }
}

public class Program
{
    private static BlockingCollection<Order> orderQueue = new BlockingCollection<Order>();
    private static int processedCount = 0;

    public static async Task Main()
    {
        Console.WriteLine("Order Processing Started...\n");

        // Producer Task
        Task producer = Task.Run(() => ProduceOrders(10));

        // Consumer Tasks (3 workers)
        Task[] consumers = new Task[3];
        for (int i = 0; i < 3; i++)
        {
            int workerId = i + 1;
            consumers[i] = Task.Run(() => ConsumeOrders(workerId));
        }

        // Wait for producer to finish
        await producer;

        // Signal consumers no more items will be added
        orderQueue.CompleteAdding();

        // Wait for all consumers to finish
        await Task.WhenAll(consumers);

        Console.WriteLine($"\nTotal Orders Processed: {processedCount}");
    }

    // Producer Method
    private static void ProduceOrders(int totalOrders)
    {
        for (int i = 1; i <= totalOrders; i++)
        {
            var order = new Order { OrderId = i };
            orderQueue.Add(order);

            Console.WriteLine($"Produced Order {order.OrderId}");
            Thread.Sleep(300); // Simulate incoming orders delay
        }
    }

    // Consumer Method
    private static void ConsumeOrders(int workerId)
    {
        foreach (var order in orderQueue.GetConsumingEnumerable())
        {
            Console.WriteLine($"Worker {workerId} processing Order {order.OrderId}");

            Thread.Sleep(1000); // Simulate processing time

            Interlocked.Increment(ref processedCount);
        }

        Console.WriteLine($"Worker {workerId} shutting down...");
    }
}
