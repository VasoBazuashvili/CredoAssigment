using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTreeNode
    {
        public int Value;
        public BinaryTreeNode Left;
        public BinaryTreeNode Right;

        public BinaryTreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
        static void Main(string[] args)
        {
            BinaryTreeNode root = new BinaryTreeNode(1);
            root.Left = new BinaryTreeNode(2);
            root.Right = new BinaryTreeNode(3);

            root.Left.Left = new BinaryTreeNode(4);
            root.Left.Right = new BinaryTreeNode(5);
            root.Right.Left = new BinaryTreeNode(6);
            root.Right.Right = new BinaryTreeNode(7);

            root.Left.Left.Left = new BinaryTreeNode(8);
            root.Left.Left.Right = new BinaryTreeNode(9);

            root.Left.Right.Left = new BinaryTreeNode(10);
            var sums = BranchSums(root);
            Console.WriteLine(string.Join(", ", sums));
            Console.ReadLine();
        }
        public static List<int> BranchSums(BinaryTreeNode root)
        {
            //sums = BranchSums(root.Left) + BranchSums(root.Right); ვინახავთ ყველა ბრენჩის ჯამს
            //აქ არ დასრულებულა ამოცანა, საჭიროა დავუმატოთ ველიუ(მნიშვნელობა)
            //sums + root.Value; ყველა ელემენტს უნდა მივუმატოთ ველიუ. BranchSums აბრუნებს ჯამების სიას.
            //sums = BranchSums(root.Left).Concat(BranchSums(root.Right)).ToList();
            if (root == null)
            {
                return new List<int>(); 
            }
            List<int> leftSum = BranchSums(root.Left);
            List<int> rightSum = BranchSums(root.Right);
            foreach (var right in rightSum)
            {
                leftSum.Add(right);
            }
            if (leftSum.Count == 0)
            {
                return  new List<int>() { root.Value};
            }
            for (int i = 0; i < leftSum.Count; i++)
            {
                leftSum[i] += root.Value;
            }
            return leftSum;
            
        }
    }
}
