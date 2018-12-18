using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yysfz
{
   public class Pic
    {
        private string _name;
        private string _path;
        private int _x;
        private int _y;
        public Pic(string name, string path, int x, int y)
        {
            _name = name;
            _path = path;
            _x = x;
            _y = y;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
    }

    class Buff
    {
        public string Name { get; set; }
        public bool Sw { get; set; }
        public Buff(string name,bool sw)
        {
            Name = name;
            Sw = sw;
        }
    }
}
