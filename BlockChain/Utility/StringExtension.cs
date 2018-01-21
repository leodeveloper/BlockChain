using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Utility
{
    public static class StringExtension
    {
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // The sec parameter takes the difficulty of the mining or Proof Work
        //Not inuse
        public static string GenerateStringForProofWork(this string str, int difficulty)
        {
            StringBuilder strBuilder = new StringBuilder(str, difficulty);            
            return strBuilder.ToString();
        }        
    }
}
