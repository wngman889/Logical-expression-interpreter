using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Kursowa_rabota_SAA
{
    public class Operand : Token
    {
        public bool Value { get; set; }
        public string Name { get; set; }
        public Operand(string name)
        {
            Name = name;
        }
        public Operand(bool value)
        {
            Value = value;
        }
        public override void ProcessWith(MyStack<Operand> stack)
        {
            stack.Push(this);
        }
        public override void SetValue(bool value)
        {
            Value = value;
        }
    }
}
