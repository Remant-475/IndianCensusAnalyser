using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianCensus
{
    public class CensusAnalyserException : Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            File_Not_Exist, Improper_Extension, Deliminator_Not_Found,
            Incorrect_Header
        }
        public CensusAnalyserException()
            {
            }
        public CensusAnalyserException(ExceptionType type,string name) : base(name)
        {
            this.type = type;
        }
    }
}
