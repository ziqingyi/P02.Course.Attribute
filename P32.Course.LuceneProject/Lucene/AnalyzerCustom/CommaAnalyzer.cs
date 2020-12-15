using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis;

namespace P32.Course.LuceneProject.Lucene.AnalyzerCustom
{
    public class CommaAnalyzer : Analyzer
    {
        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {
            return new CommaTokenizer(reader);
        }
        public override TokenStream ReusableTokenStream(string fieldName, TextReader reader)
        {
            Tokenizer tokenizer = (Tokenizer)this.PreviousTokenStream;
            if (tokenizer == null)
            {
                tokenizer = new CommaTokenizer(reader);
                this.PreviousTokenStream = tokenizer;
            }
            else
            {
                tokenizer.Reset(reader);
            }
            return tokenizer;
        }
    }
}
