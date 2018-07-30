using HackAssembler.Instructions;

namespace HackAssembler.Parsing.InstructionParsers
{
    public interface IComputationOptionsParser
    {
        Result<ComputationOption> Parse(string computationOptionsString);
    }
}
