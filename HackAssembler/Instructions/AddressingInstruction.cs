namespace HackAssembler.Instructions
{
    public class AddressingInstruction : Instruction
    {
        public AddressingInstruction(int address)
        {
            Address = address;
        }

        public int Address { get; }
    }
}
