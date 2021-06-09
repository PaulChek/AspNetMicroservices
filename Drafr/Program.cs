using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

//'Hello world' = true
//' Hello world' = false
//'Hello world  ' = false
//'Hello  world' = false
//'Hello' = true
//// Even though there are no spaces, it is still valid because none are needed
//'Helloworld' = true
//// true because we are not checking for the validity of words.
//'Helloworld ' = false
//' ' = false
//'' = true

namespace Drafr {

    class Program {
        static void Main(string[] args) {
            var tree = new Tree();
            foreach (int item in Generate(6))
                tree.Add(item);

            tree.ShowInOrder();

        }
        static IEnumerable<int> Generate(int number) {
            var rnd = new Random();
            while (number-- > 0)
                yield return rnd.Next(1, 7);
        }
    }
    class Tree {
        public Node Root { get; set; }
        public void Add(int data) => Root = Add(Root, data);

        private Node Add(Node node, int data) {

            if (node == null) return new Node(data);

            if (node.Data < data) node.Right = Add(node.Right, data);

            else node.Left = Add(node.Left, data);

            return node;
        }
        public void ShowInOrder() => ShowInOrder(Root);

        private void ShowInOrder(Node node) {
            if (node == null) return;
            ShowInOrder(node.Left);
            Console.WriteLine(node.Data);
            ShowInOrder(node.Right);
        }
    }
    class Node {
        public Node(int data, Node left = null, Node right = null) {
            Data = data;
            Left = left;
            Right = right;
        }

        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Data { get; set; }
    }
}
