using System;

namespace fragile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running task 1 - compare bTrees.");
            var comparer = new BTNComparer();
            comparer.run();

            Console.ReadLine();
        }

    }

    class BTN
    {
        public int val;
        public BTN left;
        public BTN right;
    }

    class BTNComparer
    {
        public void run()
        {
            BTN a = new BTN
            {
                val = 1,
                left = new BTN
                {
                    val = 2
                },
                right = new BTN
                {
                    val = 3,
                    left = new BTN
                    {
                        val = 4
                    },
                    right = new BTN
                    {
                        val = 5
                    }
                }
            };

            BTN b = new BTN
            {
                val = 1,
                left = new BTN
                {
                    val = 2,
                    left = new BTN
                    {
                        val = 4
                    },
                    right = new BTN
                    {
                        val = 5
                    }
                },
                right = new BTN
                {
                    val = 3
                }
            };

            BTN c = new BTN
            {
                val = 1,
                left = new BTN
                {
                    val = 2
                },
                right = new BTN
                {
                    val = 3,
                    left = new BTN
                    {
                        val = 4
                    },
                    right = new BTN
                    {
                        val = 5
                    }
                }
            };

            BTN d = new BTN
            {
                val = 1,
                left = new BTN
                {
                    val = 2,
                    left = new BTN
                    {
                        val = 4
                    },
                    right = new BTN
                    {
                        val = 5
                    }
                },
                right = new BTN
                {
                    val = 3
                }
            };

            Console.WriteLine("Is a equal to b? {0}", BTreesAreEquals(a, b));
            Console.WriteLine("Is a equal to c? {0}", BTreesAreEquals(a, c));
            Console.WriteLine("Is a equal to d? {0}", BTreesAreEquals(a, d));
            Console.WriteLine("Is b equal to c? {0}", BTreesAreEquals(b, c));
            Console.WriteLine("Is b equal to d? {0}", BTreesAreEquals(b, d));
        }

        bool BTreesAreEquals(BTN a, BTN b)
        {
            if (BTreeAsString(a) == BTreeAsString(b))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        string BTreeAsString(BTN a)
        {
            var result = a.val.ToString();

            if (a.left != null)
            {
                result = result + "-L-" + BTreeAsString(a.left);
            }

            if (a.right != null)
            {
                result = result + "-R-" + BTreeAsString(a.right);
            }

            return result;
        }

    }   

}
