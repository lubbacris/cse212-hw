using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with priorities, ensuring the highest priority is at the END of the list.
    // Expected Result: The item at the end (highest priority) should be dequeued first.
    // Defect(s) Found: The loop in Dequeue stopped at '_queue.Count - 1', skipping the last item.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        // This should return "High". If the loop limit is wrong, it might return "Medium".
        var result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result, "The item with the highest priority was not dequeued.");
    }

    [TestMethod]
    // Scenario: Enqueue items, Dequeue one, and check if the queue is empty or if the item persists.
    // Expected Result: The item should be removed from the internal list.
    // Defect(s) Found: The Dequeue method returned the value but did not call RemoveAt.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 10);

        // First dequeue should return Item1
        var result1 = priorityQueue.Dequeue();
        Assert.AreEqual("Item1", result1);

        // The queue should now be empty. Trying to dequeue again should fail.
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("The queue should be empty, but Dequeue succeeded (Item was not removed).");
        }
        catch (InvalidOperationException)
        {
            // This is the expected behavior if the item was correctly removed.
        }
    }
}