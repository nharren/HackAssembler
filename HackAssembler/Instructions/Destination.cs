using System;

namespace HackAssembler.Instructions
{
    [Flags]
    public enum Destination
    {
        None = 0,
        Memory = 1,
        DataRegister = 2,
        AddressRegister = 4
    }
}
