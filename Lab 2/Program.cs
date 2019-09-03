using System;

namespace Lab_2
{
    public class IntegerSet
    {
        // boolean array which represents a set with possible values 0-100
        private bool[] set = new bool[101];

        // default constructor
        public IntegerSet() { }

        // constructor to handle int arrays
        public IntegerSet(int[] a)
        {
            //loops through the int array and sets values to true in the bool array if between 0-100
            for (int i = 0; i < a.Length; i++ )
            {
                if (a[i] >= 0 && a[i] <= 100)
                {
                    this.set[a[i]] = true;
                }
            }
        }

        // method which returns the union of two sets
        public IntegerSet Union(IntegerSet b)
        {
            // temporary set which is returned
            IntegerSet c = new IntegerSet();
            // loops through the two sets and uses the OR operator to create the union
            for (int i = 0; i < 101; i++)
            {
                c.set[i] = this.set[i] | b.set[i];
            }
            return c;
        }

        // method which returns the intersection of two sets
        public IntegerSet Intersection(IntegerSet b)
        {
            // temporary set which is returned
            IntegerSet c = new IntegerSet();
            // loops through the two sets and uses the AND operator to create the intersection
            for (int i = 0; i < 101; i++)
            {
                c.set[i] = this.set[i] & b.set[i];
            }
            return c;
        }

        // method to insert an element into a set
        public void InsertElement(int num)
        {
            // determines if the number is between 0 and 100, then sets the value to true if it is
            if (num >= 0 && num <= 100)
            {
                this.set[num] = true;
            }
            // displays message if the number attempting to be inserted is out of bounds
            else
            {
                Console.WriteLine("Number must be between 0 and 100\n");
            }
        }

        // method to delete an element in a set
        public void DeleteElement(int num)
        {
            // determines if the number is between 0 and 100, then sets the value to false if it is
            if (num >= 0 && num <= 100)
            {
                this.set[num] = false;
            }
            // displays message if the number attempting to be deleted is out of bounds
            else
            {
                Console.WriteLine("Number must be between 0 and 100\n");
            }
        }

        // method which returns the set as a string
        public string ToString()
        {
            // empty temporary string to return the set
            string s = "";
            // loops through the set, if a value is true, then it is added to the string
            for (int i = 0; i < 101; i++)
            {
                if (this.set[i] == true)
                {
                    s += (i.ToString() + " ");
                }
            }
            // returns the string if it isn't empty
            if (s.Length != 0)
            {
                return s;
            }
            // returns '---' if the string is empty
            else
            {
                return "---";
            }
        }

        // method to determine if two sets are equal
        public bool IsEqualTo(IntegerSet b)
        {
            // temporary boolean value to return
            bool r = true;
            // loops through the set, if two values do not mach, return false
            for (int i = 0; i < this.set.Length; i++)
            {
                if (this.set[i] != b.set[i])
                {
                    return false;
                }
            }
            return r;
        }

    }

    class Program
    {
        // function to input a set as an int array
        static IntegerSet InputSet()
        {
            // reads in the input as a string
            string input = Console.ReadLine();
            // splits the string into an array of strings
            string[] nums = input.Split();
            // creates an array which will store the numbers as integers
            int[] cleanNumbers = new int[nums.Length];
            // loops through the string array and converts the strings to integers
            for (int i = 0; i < nums.Length; i++)
            {
                cleanNumbers[i] = int.Parse(nums[i]);
            }
            // converts the integer array into an integer set
            IntegerSet s = new IntegerSet(cleanNumbers);
            return s;
        }
        static void Main(string[] args)
        {
            // initialize two sets
            Console.WriteLine("Input Set A");
            IntegerSet set1 = InputSet();
            Console.WriteLine("\nInput Set B");
            IntegerSet set2 = InputSet();

            IntegerSet union = set1.Union(set2);
            IntegerSet intersection = set1.Intersection(set2);

            // prepare output
            Console.WriteLine("\nSet A contains elements:");
            Console.WriteLine(set1.ToString());
            Console.WriteLine("\nSet B contains elements:");
            Console.WriteLine(set2.ToString());
            Console.WriteLine(
            "\nUnion of Set A and Set B contains elements:");
            Console.WriteLine(union.ToString());
            Console.WriteLine(
            "\nIntersection of Set A and Set B contains elements:");
            Console.WriteLine(intersection.ToString());

            // test whether two sets are equal
            if (set1.IsEqualTo(set2))
                Console.WriteLine("\nSet A is equal to set B");
            else
                Console.WriteLine("\nSet A is not equal to set B");

            // test insert and delete
            Console.WriteLine("\nInserting 77 into set A...");
            set1.InsertElement(77);
            Console.WriteLine("\nSet A now contains elements:");
            Console.WriteLine(set1.ToString());

            Console.WriteLine("\nDeleting 77 from set A...");
            set1.DeleteElement(77);
            Console.WriteLine("\nSet A now contains elements:");
            Console.WriteLine(set1.ToString());

            // test constructor
            int[] intArray = { 25, 67, 2, 9, 99, 105, 45, -5, 100, 1 };
            IntegerSet set3 = new IntegerSet(intArray);

            Console.WriteLine("\nNew Set contains elements:");
            Console.WriteLine(set3.ToString());
        }
    }
}
