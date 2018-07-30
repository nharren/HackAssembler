using HackAssembler.Instructions;

namespace HackAssembler.Parsing.InstructionParsers
{
    public interface IInstructionParser
    {
        Result<Instruction> Parse(string instructionString);
    }
}
