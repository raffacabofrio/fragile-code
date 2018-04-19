using System;
using System.Collections.Generic;
using FizzWare.NBuilder;

namespace fragile
{
    internal class Program
    {
        static void Main(string[] args) => new BTNComparer(BTN.GetBTrees(50)).Run();
    }

    internal class BTN
    {
        public int Val { get; set; }
        public BTN Left { get; set; }
        public BTN Right { get; set; }

        internal static IList<BTN> GetBTrees(int count = 10)
        {
            var trees = Builder<BTN>
            .CreateListOfSize(count)
            .Random(count / 2)
            .With(x => x.Val, 1)
            .And(x => x.Left, new BTN
            {
                Val = 2,
                Right = new BTN { Val = 3 },
                Left = new BTN { Val = 4 }
            })
            .And(x => x.Right, new BTN
            {
                Val = 5,
                Right = new BTN { Val = 6 },
                Left = new BTN { Val = 7 }
            })
            .Random(count / 2)
            .With(x => x.Val, 7)
            .And(x => x.Left, new BTN
            {
                Val = 6,
                Right = new BTN { Val = 5 },
                Left = new BTN { Val = 4 }
            })
            .And(x => x.Right, new BTN
            {
                Val = 3,
                Right = new BTN { Val = 2 },
                Left = new BTN { Val = 1 }
            })
            .Build();

            return trees;
        }
    }

    internal class BTNComparer
    {
        private readonly IList<BTN> trees;

        public BTNComparer(IList<BTN> trees) => this.trees = trees;

        public void Run()
        {
            for (int i = 0; i < trees.Count - 1; i++)
                for (int j = i + 1; j < trees.Count; j++)
                    Console.WriteLine($"Is Tree {i} equal to Tree {j}? {BTreesAreEquals(trees[i], trees[j])}");
        }

        bool BTreesAreEquals(BTN a, BTN b) => BTreeAsString(a) == BTreeAsString(b);

        string BTreeAsString(BTN a)
        {
            var result = a.Val.ToString();

            if (a.Left != null)
                result = $"{result}-L-{BTreeAsString(a.Left)}";

            if (a.Right != null)
                result = $"{result}-R-{BTreeAsString(a.Right)}";

            return result;
        }
    }
}