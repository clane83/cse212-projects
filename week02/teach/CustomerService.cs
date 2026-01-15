using System;


/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Can I add a customer and serve them?
        // Expected Result: This should display the customer that was added
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(2);
        cs1.AddNewCustomer();
        cs1.ServeCustomer();
        // Defect(s) Found: the "var customer = _queue[0];" was not created before it was used


        Console.WriteLine("=================");

        // Test 2
        // Scenario: Can I serve a customer if none are added to the queue?
        // Expected Result: I am not adding a customer so this should give an error message
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(4);
        cs2.ServeCustomer();
        // Defect(s) Found: the queue count was 0 and threw an error, had to add a check for the queue count

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3
        // Scenario: I have added two customers to the queue, can I serve one and have one left in the queue?
        // Expected Result: The first customer is served and the second is still in the queue
        Console.WriteLine("Test 3");
        var cs3 = new CustomerService(5);
        cs3.AddNewCustomer();
        cs3.AddNewCustomer();
        cs3.ServeCustomer();
        Console.WriteLine($"Customer in the queue {cs3}");
        // Defect(s) Found: none

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Does the max size get defaulted to 10?
        // Expected Result: The max size should be defaulted to 10
        Console.WriteLine("Test 4");
        var cs4 = new CustomerService(0);
        Console.WriteLine($"Size should default to 10 {cs4}");
        // Defect(s) Found: none

        Console.WriteLine("=================");

        // Test 5
        // Scenario: I have added 2 customers and served them in order.
        // Expected Result: An error should display when the 5th customer is added
        Console.WriteLine("Test 5");
        var cs5 = new CustomerService(4);
        cs5.AddNewCustomer();
        cs5.AddNewCustomer();
        cs5.AddNewCustomer();
        cs5.AddNewCustomer();
        cs5.AddNewCustomer();
        Console.WriteLine($"Service queue: {cs5}");
        // Defect(s) Found: (_queue.Count > _maxSize) should be changed to (_queue.Count >= _maxSize)

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count <= 0)
        {
            Console.WriteLine("No Customers in Queue.");
            return;
        }
        else
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }


    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}