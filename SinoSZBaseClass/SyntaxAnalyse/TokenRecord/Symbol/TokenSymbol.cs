using System;
using System.Collections.Generic;
using System.Text;

namespace SinoSZBaseClass.SyntaxAnalyse.TokenRecord.Symbol
{
        public class TokenSymbol:TokenRecord
        {
                public TokenSymbol(int Index, int Length)
                        : base(Index, Length)
                {
                        this.TokenValueType = TokenValueTypeEnum.String;
                }

                protected override void SetChildCount()
                {
                       
                }
                
                protected override void SetPriority()
                {
                       
                }
        }
}
