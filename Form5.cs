using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeweySystemSystem
{
    public partial class Form5 : Form
    {
        // I am declaring the lists that i will use to store the words and definations and also the call numbers

        private List<String> wordexpression = new List<string>();
        private List<String> worddefinitions = new List<string>();
        private List<BookCallNumber> BookCallNumbers = new List<BookCallNumber>();

        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // Calling the method that will start the game play of the game
                BookGamePlay();
        }

      
        // method that will instantiate the game play 
        private void BookGamePlay()
        {
            // calling the method that will fill the game data before the game is played
            BookGamefillData();

            term1.Text = wordexpression[0];
            term2.Text = wordexpression[1];
            term3.Text = wordexpression[2];

            radioButton1.Text = worddefinitions[0];
            radioButton2.Text = worddefinitions[1];
            radioButton3.Text = worddefinitions[2];
            radioButton4.Text = worddefinitions[3];
            radioButton5.Text = worddefinitions[4];

            BookCallNumber c = selectTheme();

            themeButton.BackgroundImage = (Image)(c.Bookimage);
            themeDescription.Text = c.Bookdescription;
        }

       // method that will instantiate the filling of game data like call numbers, worddefinitions and wordexpression
        private void BookGamefillData()
        {
            wordexpression = new List<string>();
            worddefinitions = new List<string>();
            BookCallNumbers = new List<BookCallNumber>();

            wordexpression.Add("Performance");
            wordexpression.Add("Anti‐Pattern");
            wordexpression.Add("Architecture Pattern");
            wordexpression.Add("Religion Pattern");
            wordexpression.Add("Technology");
            wordexpression.Add("Architecture Design");
            wordexpression.Add("MVC Pattern");

            worddefinitions.Add("A common way of doing things that will not work accurately.");
            worddefinitions.Add("The security of computing frameworks and the information that they store or get to.");
            worddefinitions.Add("How fast a software application must be able to complete a specific task given a certain system load.");
            worddefinitions.Add("How quick a program application must be able to total a particular assignment given a certain framework stack.");
            worddefinitions.Add("Arrangements to common issues at an application wide level.");

            BookCallNumbers.Add(new BookCallNumber(Properties.Resources._000, "Computer science, information & general works", "Class 000 is the most general class and is used for works not limited to any one specific discipline, e.g., encyclopedias, newspapers, general periodicals.This class is also used for certain specialized disciplines that deal with knowledge and information, e.g., computer science, library and information science, journalism.Each of the other main classes(100-900) comprises a major discipline or group of related disciplines."));
            BookCallNumbers.Add(new BookCallNumber(Properties.Resources._100, "Philosophy & psychology", "Class 100 covers philosophy, parapsychology and occultism, and psychology. "));
            BookCallNumbers.Add(new BookCallNumber(Properties.Resources._200, "Religion", "Class 200 is devoted to religion"));
            BookCallNumbers.Add(new BookCallNumber(Properties.Resources._300, "Social sciences", "Class 300 covers the social sciences. Class 300 includes sociology, anthropology, statistics, political science, economics, law, public administration, social problems and services, education, commerce, communications, transportation, and customs."));
            BookCallNumbers.Add(new BookCallNumber(Properties.Resources._400, "Language", "Class 400 comprises language, linguistics, and specific languages. Literature, which is arranged by language, is found in 800."));
            BookCallNumbers.Add(new BookCallNumber(Properties.Resources._500, "Science", "Class 500 is devoted to the natural sciences and mathematics."));
            BookCallNumbers.Add(new BookCallNumber(Properties.Resources._600, "Technology", "Class 600 is technology"));
            BookCallNumbers.Add(new BookCallNumber(Properties.Resources._700, "Arts & recreation", "Class 700 covers the arts: art in general, fine and decorative arts, music, and the performing arts.Recreation, including sports and games, is also classed in 700."));
            BookCallNumbers.Add(new BookCallNumber(Properties.Resources._800, "Literature", "Class 800 covers literature, and includes rhetoric, prose, poetry, drama, etc. Folk literature is classed with customs in 300."));
            BookCallNumbers.Add(new BookCallNumber(Properties.Resources._900, "History & geography", "Class 900 is devoted primarily to history and geography. A history of a specific subject is classed with the subject."));


            trieworddefinitions();
            triewordexpression();
        }

        //method that will be responsible for randomising the defnitions that will be called
        private void trieworddefinitions()
        {
            Random random = new Random();
            List<String> worddefinitionsTrie = worddefinitions;
            worddefinitions = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                int newNumber = random.Next();

                newNumber = random.Next(0, worddefinitionsTrie.Count);

                worddefinitions.Add(worddefinitionsTrie[newNumber]);

            }
        }

        //method that will be responsible for randomising the defnitions that will be called
        private void triewordexpression ()
        {
            Random random = new Random();
            List<String> wordexpressionTrie = wordexpression;
            wordexpression = new List<string>();

            for (int i = 0; i < 3; i++)
            {
                int newNumber = random.Next();

                newNumber = random.Next(0, wordexpressionTrie.Count);
                System.Console.WriteLine(newNumber + "");
                wordexpression.Add(wordexpressionTrie[newNumber]);

            }
        }

        private int point = 0;
        private BookCallNumber selectTheme ()
        {
            Random random = new Random();

            int newNumber =  random.Next(0, BookCallNumbers.Count);

            point = newNumber;

            return BookCallNumbers[newNumber];
        }

        private void updateCallNumberPanel(object sender, EventArgs e)
        {
            term1.BackColor = Color.Transparent;
            term2.BackColor = Color.Transparent;
            term3.BackColor = Color.Transparent;

            ((Label)sender).BackColor = Color.FromArgb(192, 192, 255);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            BookGamePlay();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form2 = new Form4(point);
            form2.Show();
        }

        private void themeButton_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
