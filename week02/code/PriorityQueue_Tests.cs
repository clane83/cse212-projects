using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Three priorities and 1 is removed
    // Expected Result: Return "B" as highest priority
    // Defect(s) Found: none
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("B", result);
    }

    [TestMethod]
    // Scenario:  Three priorities and remove 2 from the queue with the same priority
    // Expected Result: Return "A" & "B" as highest priority
    // Defect(s) Found: Only "B" was removed, the code was not taking into account ties or removing from the queue
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 10);
        priorityQueue.Enqueue("B", 10);
        priorityQueue.Enqueue("C", 1);

        string[] expected = { "A", "B", "C" };

        for (int i = 0; i < expected.Length; i++)
        {
            var actual = priorityQueue.Dequeue();
            Assert.AreEqual(expected[i], actual);
        }


    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario:  4 priorities with 2 ties, B and C.  The remaining 2 should be removed in order by D then A.
    // Expected Result: Return "A" & "B" as highest priority
    // Defect(s) Found: B and C are removed.  The next to be removed should be D but is actually A.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);
        priorityQueue.Enqueue("D", 2);

        string[] expected = { "B", "C", "D", "A" };

        for (int i = 0; i < expected.Length; i++)
        {
            var actual = priorityQueue.Dequeue();
            Assert.AreEqual(expected[i], actual);
        }

    }
}