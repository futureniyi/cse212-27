using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue values with different priorities, including the highest priority item added last.
    // Expected Result: Dequeue returns the item with the highest priority.
    // Defect(s) Found: The last item in the queue was ignored when searching for the highest priority.
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        Assert.AreEqual("High", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple values with the same highest priority.
    // Expected Result: Dequeue returns the first highest-priority value that was added.
    // Defect(s) Found: The later item with the same priority was returned instead of the first one.
    public void TestPriorityQueue_SamePriorityUsesFifo()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Lower", 1);

        Assert.AreEqual("First", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue several values, then dequeue repeatedly.
    // Expected Result: Each dequeue removes one item and returns values in priority order.
    // Defect(s) Found: Dequeue returned the value but did not remove it from the queue.
    public void TestPriorityQueue_DequeueRemovesItems()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 10);
        priorityQueue.Enqueue("Middle", 5);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Middle", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found: None.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}
