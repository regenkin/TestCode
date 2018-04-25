using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Util.Expression
{
    public class Token
    {
        public virtual string TokenName
        {
            get { throw new System.NotImplementedException(); }
        }

        public virtual bool IsOperator
        {
            get { return false; }
        }

        public virtual bool IsOperand
        {
            get { return false; }
        }

        public virtual bool IsBinary
        {
            get { return false; }
        }

        public virtual bool IsUnary
        {
            get { return false; }
        }

        public virtual bool IsFunction
        {
            get { return false; }
        }

        public virtual bool IsParentheses
        {
            get { return false; }
        }
    }
}
