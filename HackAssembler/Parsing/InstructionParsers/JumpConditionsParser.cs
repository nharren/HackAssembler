using HackAssembler.Instructions;

namespace HackAssembler.Parsing.InstructionParsers
{
    public class JumpConditionsParser : IJumpConditionsParser
    {
        public Result<JumpCondition> Parse(string jumpConditionsString)
        {
            switch (jumpConditionsString)
            {
                case "JLT":
                    return new Result<JumpCondition>(JumpCondition.LessThan);
                case "JLE":
                    return new Result<JumpCondition>(JumpCondition.LessThan | JumpCondition.Equal);
                case "JEQ":
                    return new Result<JumpCondition>(JumpCondition.Equal);
                case "JNE":
                    return new Result<JumpCondition>(JumpCondition.GreaterThan | JumpCondition.LessThan);
                case "JGE":
                    return new Result<JumpCondition>(JumpCondition.GreaterThan | JumpCondition.Equal);
                case "JGT":
                    return new Result<JumpCondition>(JumpCondition.GreaterThan);
                case "JMP":
                    return new Result<JumpCondition>(JumpCondition.LessThan | JumpCondition.Equal | JumpCondition.GreaterThan);
                default:
                    return new Result<JumpCondition>(JumpCondition.None, $"Could not parse C-Instruction jump field: {jumpConditionsString}.");
            }
        }
    }
}
