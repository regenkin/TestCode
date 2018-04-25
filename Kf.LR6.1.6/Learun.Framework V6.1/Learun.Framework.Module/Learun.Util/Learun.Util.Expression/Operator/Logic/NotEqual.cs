namespace Learun.Util.Expression.Operator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using  Learun.Util.Expression.Operand;
    using  Learun.Util.Expression.Operator;

    public class NotEqual : BinaryOperator
    {
        public NotEqual()
            : base("!=", PriorityType.Logic)
        {
        }

        public override Operand Evaluate(Operand[] operands)
        {
            base.Evaluate(operands);

            return new Operand(operands[0].CompareTo(operands[1]) != 0);
        }
    }
}
