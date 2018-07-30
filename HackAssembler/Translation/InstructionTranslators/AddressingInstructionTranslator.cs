using HackAssembler.Instructions;

namespace HackAssembler.Translation.InstructionTranslators
{
    class AddressingInstructionTranslator : IInstructionTranslator
    {
        public int Translate(Instruction instruction)
        {
            return ((AddressingInstruction)instruction).Address;
        }
    }
}
