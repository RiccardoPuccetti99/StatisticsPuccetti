// Array

// Declaration
const myArray = []; // empty array
const myArray = ['value1', 'value2', 'value3']; // with values
// Loop
for (let i = 0; i < myArray.length; i++) {
    if (myArray[i] === 'condition1') {
        break; // break the loop and exit
    }
    if (myArray[i] === 'condition2') {
        continue; // continue to the next iteration 
    }
}
// Operations
myArray.push('value4'); // add a new element to the end of the array
myArray.pop(); // remove the last element from the array
myArray.unshift(element); // // add a new element to the to the beginning of the array
myArray.shift(); // removes the first element from the array
const x = myArray[0]; // get an element by index
myArray[1] = 'something else'; // set the value of the element of index 1 in this case
const isPresent = myArray.includes('value1'); // check if an element exists in the array
const valueIndex = myArray.indexOf('value1'); // find the index of an element in the array

// ---------------------------------------------------------------------------------------------------------//

// Queue (FIFO: First In First Out)
// Can be simulated with arrays, using the methods push() and shift()

const queue = []; 
// Enqueue (add to the back)
queue.push(1);
queue.push(2);
queue.push(3);
// Dequeue (remove from the front)
const removedElement = queue.shift();

// ---------------------------------------------------------------------------------------------------------//

// Stack (LIFO: Last In First Out)
// Can be simulated with arrays, using the methods push() and pop()

const stack = [];
// Push (add to the end)
stack.push(1);
stack.push(2);
stack.push(3);
// Pop (remove from the end)
const poppedElement = stack.pop();

// ---------------------------------------------------------------------------------------------------------//

// Dictionary using Map

// Declaration
// https://stackoverflow.com/questions/71820682/dictionary-map-vs-object-in-javascript  it is preferable to use Map over Object
// https://stackoverflow.com/questions/18541940/map-vs-object-in-javascript
const dictionary = new Map();
// Loop
for (const [key, value] of dictionary) {
    console.log(`Key: ${key}, Value: ${value}`);
}
// Operations
// Add key-value pairs
dictionary.set('key1', 'value1');
dictionary.set('key2', 'value2');
// Remove a key-value pair
dictionary.delete('key1');
// Get the value using a key
const value = dictionary.get('key1'); 
// Check if a key exists
const hasKey = dictionary.has('key1'); // true

// ---------------------------------------------------------------------------------------------------------//

// Sorted List

class SortedList {
    constructor() {
        this.list = [];
    }
    // Add an element to the sorted list (maintains sorting order)
    addItem(value) {
        const index = this.list.findIndex(item => item > value);
        if (index === -1) {
            this.list.push(value); // If value is larger than all elements, add it to the end
        } else {
            this.list.splice(index, 0, value); // Insert value at the appropriate position
        }
    }
    // Remove an element from the sorted list
    removeItem(value) {
        const index = this.list.indexOf(value);
        if (index !== -1) {
            this.list.splice(index, 1); // Remove the item if it exists
        }
    }
    // Check if an element exists in the sorted list
    doesItemExist(value) {
        return this.list.includes(value);
    }
    // Loop through the sorted list and print each element
    printList() {
        this.list.forEach(item => {
            console.log(item);
        });
    }
}

// Usage
const myList = new SortedList();
myList.addItem(18);
myList.addItem(7);
myList.removeItem(7);
myList.loopThroughList();

// ---------------------------------------------------------------------------------------------------------//

// Linked list

class Node {
    constructor(data) {
        this.data = data;
        this.next = null;
    }
}
class LinkedList {
    constructor() {
        this.head = null;
    }
    append(data) {
        const newNode = new Node(data);
        if (!this.head) {
            this.head = newNode;
        } else {
            let current = this.head;
            while (current.next) {
                current = current.next;
            }
            current.next = newNode;
        }
    }
    // remove first occurrence
    remove(data) {
        if (!this.head) {
            return;
        }

        if (this.head.data === data) {
            this.head = this.head.next;
            return;
        }

        let current = this.head;
        while (current.next) {
            if (current.next.data === data) {
                current.next = current.next.next;
                return;
            }
            current = current.next;
        }
    }
    // index of first occerrence
    indexOf(data) {
        let current = this.head;
        let index = 0;

        while (current) {
            if (current.data === data) {
                return index;
            }

            current = current.next;
            index++;
        }

        return -1; // Data not found in the list
    }
    display() {
        let current = this.head;
        while (current) {
            console.log(current.data);
            current = current.next;
        }
    }
}
const myList = new LinkedList();
myList.append(1);
myList.append(2);
myList.remove((1));
myList.append(3);
myList.display(); // Output: 2, 3

// ---------------------------------------------------------------------------------------------------------//

// Hash set

// Creating a set
const mySet = new Set();
// Adding elements to the set
mySet.add(1);
mySet.add(2);
// Checking for the existence of elements
const hasTwo = mySet.has(2); // Returns true
// Removing elements from the set
mySet.delete(2);
// Looping through the set and printing values
mySet.forEach(value => {
    console.log(value);
});

// ---------------------------------------------------------------------------------------------------------//

// Sorted set

class SortedSet {
    constructor() {
        // it's more efficient using both
        this.values = []; // Maintain elements in sorted order
        this.set = new Set(); // Ensure uniqueness
    }
    add(value) {
        if (!this.set.has(value)) {
            this.set.add(value);
            this.values.push(value);
            this.values.sort(); // Keep the array sorted
        }
    }
    remove(value) {
        if (this.set.has(value)) {
            this.set.delete(value);
            this.values = this.values.filter(item => item !== value);
        }
    }
    has(value) {
        return this.set.has(value);
    }

    toArray() {
        return this.values;
    }
}
const mySortedSet = new SortedSet();
mySortedSet.add(3);
mySortedSet.add(1);
mySortedSet.add(2);
console.log(mySortedSet.toArray()); // Output: [1, 2, 3]
mySortedSet.remove(2);
console.log(mySortedSet.toArray()); // Output: [1, 3]