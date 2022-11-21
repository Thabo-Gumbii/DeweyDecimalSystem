using DeweySystemSystem.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweySystemSystem
{
    class BookCallNumber
    {
        public int Booknumber;
        public String Booktitle;
        public String Bookdescription;
        public Bitmap Bookimage;
        public int Bookbook;
        private short Bookv;

        public BookCallNumber(Bitmap number, string name, string description)
        {
            this.Bookimage = number;
            this.Booktitle = name;
            this.Bookdescription = description;
        }

        public BookCallNumber(int book, short v, string title)
        {
            this.Bookbook = book;
            this.Bookv = v;
            this.Booktitle = title;
        }

        public BookCallNumber(int number, string title)
        {
            this.Booknumber = number;
            this.Booktitle = title;
        }
    }
}
