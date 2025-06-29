class MultithreadingAPiTesting
{
    static async Task Main(string[] args)
    {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] Calling two APIs in parallel...\n");

        // Create a list to hold tasks
        var tasks = new List<Task>();

        // Start both API tasks asynchronously
        Task<string> weatherTask = GetWeatherAsync();      // Task to get weather info
        Task<double> stockPriceTask = GetStockPriceAsync(); // Task to get stock price

        // Add both tasks to the task list
        tasks.Add(weatherTask);
        tasks.Add(stockPriceTask);

        // Wait until both tasks complete (parallel execution)
        await Task.WhenAll(tasks);

        // Get the results after tasks complete
        string weatherResult = await weatherTask;
        double stockResult = await stockPriceTask;

        Console.WriteLine($"\n[{DateTime.Now:HH:mm:ss.fff}] ✅ Weather API Result: {weatherResult}");
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] ✅ Stock API Result: ${stockResult}");

        sw.Stop();
        Console.WriteLine($"\n[{DateTime.Now:HH:mm:ss.fff}] Total Time: {sw.ElapsedMilliseconds} ms");
    }

    static async Task<string> GetWeatherAsync()
    {
        await Task.Delay(5000); // Simulate network/API delay of 5 seconds
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] ✅ Delay and Returned Completed GetWeatherAsync");
        return "Sunny, 75°F";
    }

    // Simulate an async method that fetches stock price data
    static async Task<double> GetStockPriceAsync()
    {
        await Task.Delay(2000); // Simulate network/API delay of 2 seconds
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] ✅ Delay and Returned Completed GetStockPriceAsync");
        return Math.Round(100 + new Random().NextDouble() * 900, 2);
    }
}
