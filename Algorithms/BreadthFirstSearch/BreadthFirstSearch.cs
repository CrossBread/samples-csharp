﻿using System;
using System.Collections.Generic;
using Common.Model;

namespace Trees.Search
{
    public class BreadthFirstSearchExample
    {
        public static void Main(string[] args)
        {
            new BreadthFirstSearchExample().run();
        }

        private void run()
        {
            // Setup input tree
            var root = TreeNode<char>.SetupSampleTree();

            // Print tree
            // Since the BFS prints as it goes and '?' is not in the tree
            // , we should see all nodes processed in alphabetical order
            BreadthFirstSearch(root, '?');

            // BFS
            // get a random target value
            var possibleValues = "ABCDEFGHIJKLMN".ToCharArray();
            var target = possibleValues[new Random().Next(possibleValues.Length)];

            // Search
            var bfsResult = BreadthFirstSearch(root, target);
        }

        public static TreeNode<T> BreadthFirstSearch<T>(TreeNode<T> root, T target)
        {
            Console.Out.WriteLine($"Breadth First Searching for {target} from root {root}");
            
            /*
            Note that the only difference between DFS and BFS is the underlying datastructure.  BFS utilizes a
            FIFO (first in first out) structure called a Queue.  We "Enqueue" to add an item to the end of the queue
            and "De-queue" to remove one from the front.
            */
            
            var discovered = new Queue<TreeNode<T>>();
            discovered.Enqueue(root);

            while (discovered.Count > 0)
            {
                // Process Node
                var node = discovered.Dequeue();
                Console.Out.WriteLine("node = {0}", node);

                // Check for equality
                if (target.Equals(node.Value))
                {
                    Console.Out.WriteLine("Found!");
                    return node;
                }

                // Discover Children
                foreach (var child in node.Children)
                {
                    discovered.Enqueue(child);
                }
            }

            // No matches found
            return null;
        }
    }
}