using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeweySystemSystem
{
    public partial class Form6 : Form
    {
        //BookCallNumber is a class that handles the book categories and its properties

        // a private list that will be used in this class
        private List<BookCallNumber> Bookcalls =new List<BookCallNumber>();

        // public list that will interact with bookcall numbers class
        List<BookCallNumber> Booklist = new List<BookCallNumber>();

        int points = 0;
        public Form6()
        {
            InitializeComponent();
            GameOn();
            
        }
        //Author: J.S White
        //Link: https://docs.oracle.com/javase/tutorial/java/javaOO/methods.html
        //method to start the game play
        public void GameOn()
        {
            //adding the callnumbers to the private list
            Bookcalls.Add(new BookCallNumber(Properties.Resources._000, "Computer science, information & general works", "Class 000 is the most general class and is used for works not limited to any one specific discipline, e.g., encyclopedias, newspapers, general periodicals.This class is also used for certain specialized disciplines that deal with knowledge and information, e.g., computer science, library and information science, journalism.Each of the other main classes(100-900) comprises a major discipline or group of related disciplines."));
            Bookcalls.Add(new BookCallNumber(Properties.Resources._100, "Philosophy & psychology", "Class 100 covers philosophy, parapsychology and occultism, and psychology. "));
            Bookcalls.Add(new BookCallNumber(Properties.Resources._200, "Religion", "Class 200 is devoted to religion"));
            Bookcalls.Add(new BookCallNumber(Properties.Resources._300, "Social sciences", "Class 300 covers the social sciences. Class 300 includes sociology, anthropology, statistics, political science, economics, law, public administration, social problems and services, education, commerce, communications, transportation, and customs."));
            Bookcalls.Add(new BookCallNumber(Properties.Resources._400, "Language", "Class 400 comprises language, linguistics, and specific languages. Literature, which is arranged by language, is found in 800."));
            Bookcalls.Add(new BookCallNumber(Properties.Resources._500, "Science", "Class 500 is devoted to the natural sciences and mathematics."));
            Bookcalls.Add(new BookCallNumber(Properties.Resources._600, "Technology", "Class 600 is technology"));
            Bookcalls.Add(new BookCallNumber(Properties.Resources._700, "Arts & recreation", "Class 700 covers the arts: art in general, fine and decorative arts, music, and the performing arts.Recreation, including sports and games, is also classed in 700."));
            Bookcalls.Add(new BookCallNumber(Properties.Resources._800, "Literature", "Class 800 covers literature, and includes rhetoric, prose, poetry, drama, etc. Folk literature is classed with customs in 300."));
            Bookcalls.Add(new BookCallNumber(Properties.Resources._900, "History & geography", "Class 900 is devoted primarily to history and geography. A history of a specific subject is classed with the subject."));

            
            //creating an object to take the selected data
            BookCallNumber c1 = selectQuestion();
            c1.Bookdescription = Bookcalls[c1.Bookbook].Bookdescription;
            c1.Bookimage = Bookcalls[c1.Bookbook].Bookimage;

            



            //to randomise the questions
            Random random = new Random();

            int newNumber = random.Next(0, Bookcalls.Count);
            int newNumber2 = random.Next(0, Bookcalls.Count);
            int newNumber3 = random.Next(0, Bookcalls.Count);
            points = random.Next(1, 10);

            BookCallNumber c2 = Bookcalls[newNumber];
            BookCallNumber c3 = Bookcalls[newNumber2];
            BookCallNumber c4 = Bookcalls[newNumber3];

            option1.BackgroundImage = (Image)(c1.Bookimage); desc1.Text = c1.Bookdescription;
            option2.BackgroundImage = (Image)(c2.Bookimage); desc2.Text = c2.Bookdescription;
            option3.BackgroundImage = (Image)(c3.Bookimage); desc3.Text = c3.Bookdescription;
            option4.BackgroundImage = (Image)(c4.Bookimage); desc4.Text = c4.Bookdescription;

            assert.Text = c1.Booktitle;

        }
        //Author: P. Smith
        //Link: https://www.javatpoint.com/how-to-generate-random-number-in-java
        //to check that the question is not repeated
        private BookCallNumber selectTheme()
        {
            Random random = new Random();

            int newNumber = random.Next(0, Bookcalls.Count);

            return Bookcalls[newNumber];
        }

        //to restart the game
        private void button14_Click(object sender, EventArgs e)
        {
            GameOn();
        }

        //to take call numbers from textfile based on research, goes through the loop to get the numbers
        private BookCallNumber selectQuestion()
        {
            string[] lines = System.IO.File.ReadAllLines(@"call_number.txt");
           
            Random random = new Random();

            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                String Bookbook = line.Substring(0, 1);
                String option = line.Substring(0, 2) + "0";
                String Booknumber = line.Substring(0, 3);
                string Booktitle = line.Replace(Booknumber, "").Trim();
                if (Booktitle == "") continue;
                //Console.WriteLine("\t" + Booktitle);
                Booklist.Add(new BookCallNumber(Int16.Parse(Bookbook),Int16.Parse(Booknumber), Booktitle));
            }


            int newNumber = random.Next(0, Booklist.Count);

            Console.WriteLine("\t" + newNumber + " call: " + Booklist[newNumber].Booknumber + " " + Booklist[newNumber].Booktitle);


            return Booklist[newNumber];
        }

        //implementation of tree datastracture to store the book numbers
        class Node
        {
            public BookCallNumber value;
            public Node left;
            public Node right;
        }
        //Author: A. Choudary
        //Link: https://www.edureka.co/blog/java-binary-tree
        class Tree
        {
            public Node insert(Node root, BookCallNumber v)
            {
                if (root == null)
                {
                    root = new Node();
                    root.value = v;
                }
                else if (v.Booknumber < root.value.Booknumber)
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
        // implemetation of searching the tree for codes
        class SearchingTree
        {
            static void GameOn()
            {
                Node root = null;
                Tree bst = new Tree();
                int SIZE = 1000;
                BookCallNumber[] a = new BookCallNumber[SIZE];
                List<BookCallNumber> Booklist = new List<BookCallNumber>();

                Console.WriteLine("Generating array with {0} values...", SIZE);

                Random random = new Random();
                string[] lines = System.IO.File.ReadAllLines(@"call_number.txt");

                Stopwatch watch = Stopwatch.StartNew();

                foreach (string line in lines)
                {
                    // Use a tab to indent each line of the file.
                    String Bookbook = line.Substring(0, 1);
                    String option = line.Substring(0, 2) + "0";
                    String Booknumber = line.Substring(0, 3);
                    string Booktitle = line.Replace(Booknumber, "").Trim();
                    if (Booktitle == "") continue;
                    //Console.WriteLine("\t" + Booktitle);
                    Booklist.Add(new BookCallNumber(Int16.Parse(Booknumber), Booktitle));
                }


                watch.Stop();

                Console.WriteLine("Done. Took {0} seconds", (double)watch.ElapsedMilliseconds / 1000.0);
                Console.WriteLine();
                Console.WriteLine("Filling the tree with {0} nodes...", SIZE);

                watch = Stopwatch.StartNew();

                for (int i = 0; i < Booklist.Count; i++)
                {
                    root = bst.insert(root, Booklist[i]);
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

        //to show the points after user finish the game
        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form2 = new Form4(points);
            form2.Show();
        }
    }
}
