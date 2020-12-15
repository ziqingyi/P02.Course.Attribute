using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Util;

namespace P32.Course.LuceneProject.Lucene.AnalyzerCustom
{
    public class BlankTokenizer:CharTokenizer
    {
        public BlankTokenizer(TextReader in_Renamed)
            : base(in_Renamed)
        {
        }
        public BlankTokenizer(AttributeSource source, TextReader in_Renamed)
            : base(source, in_Renamed)
        {
        }
        public BlankTokenizer(AttributeSource.AttributeFactory factory, TextReader in_Renamed)
            : base(factory, in_Renamed)
        {
        }
        protected override bool IsTokenChar(char c)
        {
            return c != ' ';
        }

    }
}
