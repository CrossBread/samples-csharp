using System.Collections.Generic;
using System.Text;

namespace Common.Model
{
    public class TreeNode<T>
    {
        public T Value;
        public List<TreeNode<T>> Children = new List<TreeNode<T>>();

        public TreeNode(T value, List<TreeNode<T>> children = null)
        {
            Value = value;
            if (children != null) Children.AddRange(children);
        }

        public void AddChildren(T[] values)
        {
            foreach (var value in values)
            {
                Children.Add(new TreeNode<T>(value));
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(Value.ToString());
            stringBuilder.Append(" children: ");
            foreach (var child in Children)
            {
                stringBuilder.Append(child.Value + " ");
            }
            return stringBuilder.ToString();
        }

        public static TreeNode<char> SetupSampleTree()
        {
            /*  A 4 tier tree with A as the root with 3 children B, C, D and so on.
             *                   A
             *         B         C         D
             *       E  F      G         H
             *     IJK       L         M   N
             */
            var root = new TreeNode<char>('A');
            root.AddChildren("BCD".ToCharArray());
            root.Children[0].AddChildren("EF".ToCharArray());
            root.Children[0].Children[0].AddChildren("IJK".ToCharArray());
            
            root.Children[1].AddChildren("G".ToCharArray());
            root.Children[1].Children[0].AddChildren("L".ToCharArray());
            
            
            root.Children[2].AddChildren("H".ToCharArray());
            root.Children[2].Children[0].AddChildren("MN".ToCharArray());
            return root;
        }
    }
}