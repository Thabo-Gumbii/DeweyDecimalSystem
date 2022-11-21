using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DeweySystemSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //Readfile();


        }

        public static void Readfile()
        {
            string[] lines = System.IO.File.ReadAllLines(@"call_number.txt");
            List<CallNumber> mylist = new List<CallNumber>();
            Random random = new Random();

            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                String book = line.Substring(0, 1);
                String option = line.Substring(0, 2)+"0";
                String number = line.Substring(0, 3);
                string title = line.Replace(number, "").Trim();
                if (title == "") continue;
                //Console.WriteLine("\t" + title);
                mylist.Add(new CallNumber(Int16.Parse(number), title));
            }


            int  newNumber = random.Next(0, mylist.Count);

            Console.WriteLine("\t" + newNumber + " call: "+mylist[newNumber].number+ " "+mylist[newNumber].title);


            return;
        }

        class CallNumber
        {
            public int number;
            public String title;

            public CallNumber(int number, string title)
            {
                this.number = number;
                this.title = title;
            }
        }

        class Node
        {
            public CallNumber value;
            public Node left;
            public Node right;
        }

        class Tree
        {
            public Node insert(Node root, CallNumber v)
            {
                if (root == null)
                {
                    root = new Node();
                    root.value = v;
                }
                else if (v.number < root.value.number)
                {
                    root.left = insert(root.left, v);
                }
                else
                {
                    root.right = insert(root.right, v);
                }

                return root;
            }

            public void traverse(Node root)
            {
                if (root == null)
                {
                    return;
                }

                traverse(root.left);
                traverse(root.right);
            }
        }
        //Author: A. Choudary
        //Link: https://www.edureka.co/blog/java-binary-tree

        class BinarySearchTree
        {
            static void start()
            {
                Node root = null;
                Tree bst = new Tree();
                int SIZE = 1000;
                CallNumber[] a = new CallNumber[SIZE];
                List<CallNumber> mylist = new List<CallNumber>();

                Console.WriteLine("Generating array with {0} values...", SIZE);

                Random random = new Random();
                string[] lines = System.IO.File.ReadAllLines(@"call_number.txt");

                Stopwatch watch = Stopwatch.StartNew();

                foreach (string line in lines)
                {
                    // Use a tab to indent each line of the file.
                    String book = line.Substring(0, 1);
                    String option = line.Substring(0, 2) + "0";
                    String number = line.Substring(0, 3);
                    string title = line.Replace(number, "").Trim();
                    if (title == "") continue;
                    //Console.WriteLine("\t" + title);
                    mylist.Add(new CallNumber(Int16.Parse(number), title));
                }


                watch.Stop();

                Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
                Console.WriteLine();
                Console.WriteLine("Filling the tree with {0} nodes...", SIZE);

                watch = Stopwatch.StartNew();

                for (int i = 0; i < mylist.Count; i++)
                {
                    root = bst.insert(root, mylist[i]);
                }

                watch.Stop();

                Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
                Console.WriteLine();
                Console.WriteLine("Traversing all {0} nodes in tree...", SIZE);

                watch = Stopwatch.StartNew();

                bst.traverse(root);

                watch.Stop();

                Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
                Console.WriteLine();

                Console.ReadKey();
            }
        }

    }
}
