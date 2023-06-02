using System;
using System.Collections.Generic;
using System.Text;

namespace Kursowa_rabota_SAA
{
      public abstract class Token
      {
        public virtual string Symbol { get; }
        public abstract void ProcessWith(MyStack<Operand> stack);
        public virtual void SetValue(bool value)
        {
        }
      }
}
