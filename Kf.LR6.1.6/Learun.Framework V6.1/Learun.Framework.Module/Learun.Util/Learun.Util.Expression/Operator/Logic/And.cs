﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Learun.Util.Expression.Operator
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
    using  Learun.Util.Expression.Operand;

	public class And : BinaryOperator
	{
        public And()
            : base("&&", PriorityType.AddAndSub)
        {
        }

        public override Operand Evaluate(Operand[] operands)
        {
            base.Evaluate(operands);

            return new Operand(operands[0].AsBoolean && operands[1].AsBoolean);
        }
	}
}

