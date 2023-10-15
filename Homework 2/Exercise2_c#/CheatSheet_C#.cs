using System;

public class Class1
{
    public Class1()
    {
        // Array

        // Declaration
        int[] myArray = new int[] { 1, 2, 3, 4, 5 };

        // Loop
        for (int i = 0; i < myArray.Length; i++)
        {
            if (myArray[i] == 3)
            {
                break; // break the loop and exit
            }
            if (myArray[i] == 2)
            {
                continue; // continue to the next iteration
            }
        }

        // Operations
        Array.Resize(ref myArray, myArray.Length + 1); // Add a new element
        myArray[myArray.Length - 1] = 6; // Set the last element to a value
        int[] removedArray = myArray.Skip(1).ToArray(); // Remove the first element
        int x = myArray[0]; // Get an element by index
        bool isPresent = myArray.Contains(5); // Check if an element exists
        int valueIndex = Array.IndexOf(myArray, 4); // Find the index of an element

        //-----------------------------------------------------------------------------------------------//

        // Queue

        // Declaration
        Queue<int> myQueue = new Queue<int>();

        // Enqueue (add to the back)
        myQueue.Enqueue(1);
        myQueue.Enqueue(2);
        myQueue.Enqueue(3);

        // Dequeue (remove from the front)
        int removedElement = myQueue.Dequeue();

        //-----------------------------------------------------------------------------------------------//

        // Stack

        // Declaration
        Stack<int> myStack = new Stack<int>();

        // Push (add to the end)
        myStack.Push(1);
        myStack.Push(2);
        myStack.Push(3);

        // Pop (remove from the end)
        int poppedElement = myStack.Pop();

        //-----------------------------------------------------------------------------------------------//

        // Dictionary

        // Declaration
        Dictionary<string, string> myDictionary = new Dictionary<string, string>();

        // Loop
        foreach (var pair in myDictionary)
        {
            Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
        }

        // Operations
        myDictionary["key1"] = "value1"; // Add key-value pairs
        myDictionary["key2"] = "value2";
        myDictionary.Remove("key1"); // Remove a key-value pair
        string value = myDictionary["key2"]; // Get the value using a key
        bool hasKey = myDictionary.ContainsKey("key1"); // Check if a key exists

        //-----------------------------------------------------------------------------------------------//

        // Sorted List

        // Declaration
        SortedList<int, string> myList = new SortedList<int, string>();

        // Add an element to the sorted list
        myList.Add(3, "C");
        myList.Add(1, "A");
        myList.Add(2, "B");

        // Remove an element from the sorted list
        myList.Remove(1);

        // Check if an element exists in the sorted list
        bool doesExist = myList.ContainsValue("B");

        // Loop through the sorted list
        foreach (var pair in myList)
        {
            Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
        }

        //-----------------------------------------------------------------------------------------------//

        // Linked List

        LinkedList<int> myList = new LinkedList<int>();

        // Adding elements to the linked list
        myList.AddLast(1);
        myList.AddLast(2);
        myList.AddLast(3);

        // Removing an element from the linked list
        myList.Remove(1);

        // Finding the first occurrence of an element
        int indexOfTwo = myList.Find(2).Value;

        // Looping through the linked list and printing values
        foreach (var item in myList)
        {
            Console.WriteLine(item);
        }

        //-----------------------------------------------------------------------------------------------//

        // HashSet

        HashSet<int> mySet = new HashSet<int>();

        // Adding elements to the hash set
        mySet.Add(1);
        mySet.Add(2);

        // Checking for the existence of elements
        bool hasTwo = mySet.Contains(2); // Returns true

        // Removing elements from the hash set
        mySet.Remove(2);

        // Looping through the hash set and printing values
        foreach (var value in mySet)
        {
            Console.WriteLine(value);
        }

        //-----------------------------------------------------------------------------------------------//

        // SortedSet

        SortedSet<int> mySortedSet = new SortedSet<int>();

        // Adding elements to the sorted set
        mySortedSet.Add(3);
        mySortedSet.Add(1);
        mySortedSet.Add(2);

        // Checking for the existence of elements
        bool hasOne = mySortedSet.Contains(1); // Returns true

        // Removing elements from the sorted set
        mySortedSet.Remove(2);

        // Looping through the sorted set and printing values
        foreach (var value in mySortedSet)
        {
            Console.WriteLine(value);
        }
    }
}
