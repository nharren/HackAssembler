using HackAssembler.Instructions;

namespace HackAssembler.Parsing.InstructionParsers
{
    public interface IJumpConditionsParser
    {
        Result<JumpCondition> Parse(string jumpConditionsString);
    }
}
