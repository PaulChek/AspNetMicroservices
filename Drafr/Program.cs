using System;
using System.Collections.Generic;
using System.Linq;
//Heron 's formula:
//sqrt (s * (s - a) * (s - b) * (s - c)),
//where s = (a + b + c) / 2.
//Output should have 2 digits precision.

namespace Drafr {

    class Program {

        static void Main(string[] args) {
        }
        static long SummNum(long n) =>
             (n + "").ToCharArray().Aggregate(0L, (a, c) => a + long.Parse(c + ""));

        public static double heron(double a, double b, double c) {
            double s = (a + b + c) / 2;
            return double.Parse(Math.Sqrt(s * (s - a) * (s - b) * (s - c)).ToString("F2"));
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
