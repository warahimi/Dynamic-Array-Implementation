using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    internal class GenericDynamicArray<T>
    {
        private T[] array;      // The static array to store elements, declared but not instantiated
        private int capacity;   // The current capacity of the array
        private int size;      // The number of elements in the array
        private EqualityComparer<T> comparer = EqualityComparer<T>.Default;


        public GenericDynamicArray()
        {
            capacity = 4;        // Initial capacity of the array
            this.array = new T[capacity];
            size = 0;
        }
        // over loaded contructor 
        public GenericDynamicArray(int capacity)
        {
            this.capacity = capacity;
            this.array = new T[capacity];
            size = 0;
        }

        public void Add(T item)
        {
            if (size == capacity) // if we are at the capacity ?
            {
                grow();  // If the array is full, resize it
            }

            // there is still empty room in the array 
            array[size] = item;  // Add the new item to the array
            size++;
        }
        public void inserAtIndex(T item, int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();  // Throw an exception if the index is out of range
            }

            if (size >= capacity)
            {
                grow();
            }
            // shifting all the element after index to the right to make room for insertions 
            for (int i = size; i >= index; i--)
            {
                array[i + 1] = array[i];
            }
            array[index] = item;
            size++;
        }


        public T GetItemAtIndex(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();  // Throw an exception if the index is out of range
            }

            return array[index];  // Return the element at the specified index
        }

        public int search(T item)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < size; i++)
            {
                if (comparer.Equals(item, array[i]))
                    return i;
            }
            return -1;
        }
        public void RemoveAtIndex(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();  // Throw an exception if the index is out of range
            }

            // Shift elements to fill the gap created by removing the element at the specified index
            for (int i = index; i < size - 1; i++)
            {
                array[i] = array[i + 1];
            }

            size--;  // Update the size to reflect the removal of an element
        }
        public void removeItem(T item)
        {
            for (int i = 0; i < size; i++)
            {
                if (comparer.Equals(array[i], item))
                {
                    // shifting the elements to the left
                    for (int j = i; j < size - 1; j++)
                    {
                        array[j] = array[j + 1];
                    }
                    size--;
                    // if size is under the 3rd of capacity
                    if (size <= capacity / 3)
                    {
                        shrink();
                    }
                    break;
                }
            }
        }
        private void grow()
        {
            // increasing the capacity 
            capacity *= 2;  // Double the capacity of the array

            T[] newArray = new T[capacity];  // Create a new array with the increased capacity
                                                 //Array.Copy(array, newArray, size);  // Copy the existing elements to the new array
            for (int i = 0; i < size; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;  // Update the reference to the new array
        }
        private void shrink()
        {
            // increasing the capacity 
            capacity /= 2;  // Double the capacity of the array

            T[] newArray = new T[capacity];  // Create a new array with the increased capacity
                                                 //Array.Copy(array, newArray, size);  // Copy the existing elements to the new array
            for (int i = 0; i < size; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;  // Update the reference to the new array
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public int getCapacity()
        {
            return capacity;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < size; i++)
            {
                str += array[i].ToString() + ", ";
            }
            if (str != "")
            {
                str = "[" + str.Substring(0, str.Length - 2) + "]";
            }
            else
            {
                str = "[]";
            }
            return str;
        }

        public void print()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        public void printEntireArray()
        {
            for (int i = 0; i < capacity; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        public int getSize()
        {
            return size;
        }
    }
}
