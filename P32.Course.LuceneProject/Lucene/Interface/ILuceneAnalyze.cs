using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P32.Course.LuceneProject.Lucene.Interface
{
    public interface ILuceneAnalyze
    {
        //word segmentation based on field
        string[] AnalyzerKey(string keyword);
    }
}
