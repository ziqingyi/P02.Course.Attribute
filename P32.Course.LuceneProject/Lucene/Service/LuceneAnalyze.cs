using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using P32.Course.LuceneProject.Lucene.Interface;
using P32.Course.LuceneProject.Utility;
using Version = Lucene.Net.Util.Version;

namespace P32.Course.LuceneProject.Lucene.Service
{
    public class LuceneAnalyze:ILuceneAnalyze
    {
        private Logger logger = new Logger(typeof(LuceneAnalyze));

        #region AnalyzerKey
        public string[] AnalyzerKey(string keyword)
        {
            Analyzer analyzer = new PanGuAnalyzer();
            QueryParser parser = new QueryParser(Version.LUCENE_30, "title", analyzer);
            Query query = parser.Parse(this.CleanKeyword(keyword));
            if (query is TermQuery)
            {
                Term term = ((TermQuery) query).Term;
                return new string[]{term.Text};
            }

            if (query is PhraseQuery)
            {
                Term[] terms = ((PhraseQuery) query).GetTerms();
                string[] res = terms.Select(t => t.Text).ToArray();
                return res;
            }

            if (query is BooleanQuery)
            {
                BooleanClause[] clauses = ((BooleanQuery) query).GetClauses();
                List<string> analyzerWords = new List<string>();
                foreach (BooleanClause clause in clauses)
                {
                    Query childQuery = clause.Query;
                    if (childQuery is TermQuery)
                    {
                        Term term = ((TermQuery) childQuery).Term;
                        analyzerWords.Add(term.Text);
                    }
                    else if (childQuery is PhraseQuery)
                    {
                        Term[] terms = ((PhraseQuery) childQuery).GetTerms();
                        analyzerWords.AddRange(terms.Select(t => t.Text));
                    }
                }
                return analyzerWords.ToArray();
            }
            else
            {
                logger.Debug(string.Format("AnalyzerKey will convert keyword={0} to new string[]{keyword}", keyword));
                return new string[]{keyword};
            }

        }
        #endregion


        #region clean:  "and"  "or" at the beginning and end. 

        private string CleanKeyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {

            }
            else
            {
                bool isClean = false;
                while (!isClean)
                {
                    keyword = keyword.Trim();
                    if (keyword.EndsWith(" AND"))
                    {
                        keyword = string.Format("{0}and", keyword.Remove(keyword.Length - 3, 3));
                    }
                    else if (keyword.EndsWith(" OR"))
                    {
                        keyword = string.Format("{0}or", keyword.Remove(keyword.Length - 2, 2));
                    }
                    else if (keyword.EndsWith("AND "))
                    {
                        keyword = string.Format("and{0}", keyword.Substring(3));
                    }
                    else if (keyword.StartsWith("OR "))
                    {
                        keyword = string.Format("or{0}", keyword.Substring(2));
                    }
                    else if (keyword.Contains(" OR "))
                    {
                        keyword = keyword.Replace(" OR ", " or ");
                    }
                    else if (keyword.Contains(" AND "))
                    {
                        keyword = keyword.Replace(" AND ", " and ");
                    }
                    else{
                        isClean = true;
                    }
                }
            }
            string result = QueryParser.Escape(keyword);
            return result;
        }


        #endregion





    }
}
