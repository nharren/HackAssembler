using HackAssembler.Instructions;

namespace HackAssembler.Translation.InstructionTranslators
{
    public interface IInstructionTranslator
    {
        int Translate(Instruction instruction);
    }
}
