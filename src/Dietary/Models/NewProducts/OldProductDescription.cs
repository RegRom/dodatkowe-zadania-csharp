using System;

namespace LegacyFighter.Dietary.Models.NewProducts
{
    public class OldProductDescription
    {
        public string Desc { get; private set; }
        public string LongDesc { get; private set; }

        public OldProductDescription(string desc, string longDesc)
        {
            Desc = desc;
            LongDesc = longDesc;
        }
        
        public void ReplaceCharFromDesc(string charToReplace, string replaceWith)
        {
            if (string.IsNullOrWhiteSpace(LongDesc) || string.IsNullOrWhiteSpace(Desc))
            {
                throw new InvalidOperationException("null or empty desc");
            }

            LongDesc = LongDesc.Replace(charToReplace, replaceWith);
            Desc = Desc.Replace(charToReplace, replaceWith);
        }

        public string FormatDesc()
        {
            if (string.IsNullOrWhiteSpace(LongDesc) || string.IsNullOrWhiteSpace(Desc))
            {
                return "";
            }

            return Desc + " *** " + LongDesc;
        }
    }
}