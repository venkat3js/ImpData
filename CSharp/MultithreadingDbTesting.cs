public class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int DepartmentId { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

class MultithreadingDbTesting
{
    static async Task Main(string[] args)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] ⏳ Starting to fetch Employees and Departments...\n");
        var sw = System.Diagnostics.Stopwatch.StartNew();

        // Create a list to hold tasks
        var tasks = new List<Task>();

        var employeeTask = GetEmployeesAsync();
        var departmentTask = GetDepartmentsAsync();

        // Add both tasks to the task list
        tasks.Add(employeeTask);
        tasks.Add(departmentTask);

        // Wait until both tasks complete (parallel execution)
        await Task.WhenAll(tasks);
        // OR await Task.WhenAll(employeeTask, departmentTask);

        // Get the results after tasks complete
        var employees = await employeeTask;
        var departments = await departmentTask;

        sw.Stop();
        Console.WriteLine($"\n[{DateTime.Now:HH:mm:ss.fff}] Total Time: {sw.ElapsedMilliseconds} ms");
    }

    static async Task<List<Employee>> GetEmployeesAsync()
    {
        await Task.Delay(5000);  // Simulate delay
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] ✅ Delay and Returned Completed Async in GetEmployeesAsync");
        return new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", DepartmentId = 1 },
            new Employee { Id = 2, Name = "Bob", DepartmentId = 2 },
            new Employee { Id = 3, Name = "Charlie", DepartmentId = 1 },
        };
    }

    static async Task<List<Department>> GetDepartmentsAsync()
    {
        await Task.Delay(2000);  // Simulate delay
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] ✅ Delay and Returned Completed Async in GetDepartmentsAsync");
        return new List<Department>
        {
            new Department { Id = 1, Name = "IT" },
            new Department { Id = 2, Name = "HR" },
            new Department { Id = 3, Name = "Finance" },
        };
    }
}
