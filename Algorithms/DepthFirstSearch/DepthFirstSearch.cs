using System;
using System.Collections.Generic;
using Common.Model;

namespace DepthFirstSearch
{
    public class DepthFirstSearchExample
    {
        public static void Main(string[] args)
        {
            new DepthFirstSearchExample().run();
        }

        private void run()
        {
            // Setup input tree
            var root = TreeNode<char>.SetupSampleTree();

            // Print tree
            // Since the DFS prints the deepest node first and '?' is not in the tree
            // , we will see all nodes processed, but NOT in alphabetical order
            DepthFirstSearch(root, '?');

            // DFS
            // get a random target value
            var possibleValues = "ABCDEFGHIJKLMN".ToCharArray();
            var target = possibleValues[new Random().Next(possibleValues.Length)];

            // Search
            var dfsResult = DepthFirstSearch(root, target);
        }

        public static TreeNode<T> DepthFirstSearch<T>(TreeNode<T> root, T target)
        {
            Console.Out.WriteLine($"Depth First Searching for {target} from root {root}");

            /*
            Note that the only difference between DFS and BFS is the underlying data structure.  DFS utilizes a
            LIFO (last in first out) structure called a Stack.  We "Push" to add an item to the top of the stack
            and "Pop" to remove one from the top.
            */
            var discovered = new Stack<TreeNode<T>>();
            discovered.Push(root);

            while (discovered.Count > 0)
            {
                // Process Node
                var node = discovered.Pop();
                Console.Out.WriteLine("node = {0}", node);

                // Check for equality
                if (target.Equals(node.Value))
                {
                    Console.Out.WriteLine("Found!");
                    return node;
                }

                // Discover Children
                foreach (var child in node.Children) discovered.Push(child);
            }

            // No matches found
            return null;
        }
    }
}