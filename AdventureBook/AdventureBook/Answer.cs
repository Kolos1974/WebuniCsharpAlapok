using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBook
{
    class Answer
    {
        public Answer(int number, string label, string text, List<int> paths, int level)
        {
            Number = number;
            Label = label;
            Text = text;
            Paths = paths;
            Level = level;
        }

        public int Number { get; }
        public string Label { get; }
        public string Text { get; }
        public List<int> Paths { get; }
        public int Level { get; }
    }
}
