﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Expression.Operator
{
	using Expression;
	using Expression.Operand;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class OperatorBase
	{
		public virtual bool Token
		{
			get;
			private set;
		}

		public virtual bool IsBinary
		{
			get;
			private set;
		}

		public virtual bool IsUnary
		{
			get;
			private set;
		}

		public virtual bool IsFunction
		{
			get;
			private set;
		}

		public virtual bool IsParentheses
		{
			get;
			private set;
		}

		public virtual OperandBase evaluate(OperandBase[] operands)
		{
			throw new System.NotImplementedException();
		}

		public virtual int ComparePriority(OperatorBase that)
		{
			throw new System.NotImplementedException();
		}

	}
}
