using System;

namespace HackAssembler.Instructions
{
    [Flags]
    public enum JumpCondition
    {
        None = 0,
        GreaterThan = 1,
        Equal = 2,
        LessThan = 4
    }
}
