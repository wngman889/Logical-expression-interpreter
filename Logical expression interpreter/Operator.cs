using System;
using System.Collections.Generic;
using System.Text;

namespace Kursowa_rabota_SAA
{
    public abstract class Operator : Token
    {
        public override string Symbol { get;}
        public Operator(string symbol)
        {
            Symbol = symbol;
        }
    }
    public class LogicalAnd : Operator
    {
        public LogicalAnd()
            : base("&")
        {
        }
        public override void ProcessWith(MyStack<Operand> stack)
        {
            var opr2 = stack.Pop();
            var opr1 = stack.Pop();
            stack.Push(new Operand(opr1.Value && opr2.Value));
         }
    }
    public class LogicalOr : Operator
    {
        public LogicalOr()
            : base("|")
        {
        }
        public override void ProcessWith(MyStack<Operand> stack)
        {
            var opr2 = stack.Pop();
            var opr1 = stack.Pop();
            stack.Push(new Operand(opr1.Value || opr2.Value));
        }
    }
    public class LogicalNot : Operator
    {
        public LogicalNot()
            : base("!")
        {
        }
        public override void ProcessWith(MyStack<Operand> stack)
        {
            var opr1 = stack.Pop();
            var opr2 = !opr1.Value;
            stack.Push(new Operand(opr2));
        }
    }
}
