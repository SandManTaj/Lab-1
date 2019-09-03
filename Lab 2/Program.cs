using System;

namespace Lab_2
{
    public class IntegerSet
    {
        private bool[] set = new bool[101];

        public IntegerSet() { }

        public IntegerSet(int[] a)
        {
            for (int i = 0; i < a.Length; i++ )
            {
                if (a[i] >= 0 && a[i] <= 100)
                {
                    this.set[a[i]] = true;
                }
            }
        }
        public IntegerSet Union(IntegerSet b)
        {
            IntegerSet c = new IntegerSet();
            for (int i = 0; i < 101; i++)
            {
                c.set[i] = this.set[i] | b.set[i];
            }
            return c;
        }

        public IntegerSet Intersection(IntegerSet b)
        {
            IntegerSet c = new IntegerSet();
            for (int i = 0; i < 101; i++)
            {
                c.set[i] = this.set[i] & b.set[i];
            }
            return c;
        }

        public void InsertElement(int num)
        {
            if (num >= 0 && num <= 100)
            {
                this.set[num] = true;
            }
            else
            {
                Console.WriteLine("Number must be between 0 and 100\n");
            }
        }

        public void DeleteElement(int num)
        {
            if (num >= 0 && num <= 100)
            {
                this.set[num] = false;
            }
            else
            {
                Console.WriteLine("Number must be between 0 and 100\n");
            }
        }

        public string ToString()
        {
            string s = "";
            for (int i = 0; i < 101; i++)
            {
                if (this.set[i] == true)
                {
                    s += (i.ToString() + " ");
                }
            }
            if (s.Length != 0)
            {
                return s;
            }
            else
            {
                return "---";
            }
        }

        public bool IsEqualTo(IntegerSet b)
        {
            bool r = true;
            for (int i = 0; i < this.set.Length; i++)
            {
                if (this.set[i] != b.set[i])
                {
                    r = false;
                }
            }
            return r;
        }

    }

    class Program
    {
        static IntegerSet InputSet()
        {
            string input = Console.ReadLine();
            string[] nums = input.Split();
            int[] cleanNumbers = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                cleanNumbers[i] = int.Parse(nums[i]);
            }
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
