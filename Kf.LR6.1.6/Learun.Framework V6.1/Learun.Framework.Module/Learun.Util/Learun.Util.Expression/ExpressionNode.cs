namespace Learun.Util.Expression
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Operand;
    using Operator;

    public class ExpressionNode
    {
        public ExpressionNode Left;
        public ExpressionNode Right;
        public Token Token;

        public ExpressionNode Copy()
        {
            ExpressionNode node = new ExpressionNode() { Left = this.Left, Right = this.Right, Token = this.Token };

            return node;
            //return this;
        }
    }
}
