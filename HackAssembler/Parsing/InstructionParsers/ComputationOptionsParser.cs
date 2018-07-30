using HackAssembler.Instructions;

namespace HackAssembler.Parsing.InstructionParsers
{
    public class ComputationOptionsParser : IComputationOptionsParser
    {
        public Result<ComputationOption> Parse(string computationOptionsString)
        {
            var computationOption = ComputationOption.None;

            if (computationOptionsString.Contains("M"))
            {
                computationOption |= ComputationOption.UseAddressMemory;
            }

            if (!computationOptionsString.Contains("D"))
            {
                computationOption |= ComputationOption.ZeroX;
            }

            if (!computationOptionsString.Contains("A") && !computationOptionsString.Contains("M"))
            {
                computationOption |= ComputationOption.ZeroY;
            }

            if (computationOptionsString != "A"
                && computationOptionsString != "M"
                && computationOptionsString != "D"
                && !computationOptionsString.Contains("!")
                && !computationOptionsString.Contains("&")
                && !computationOptionsString.Contains("|"))
            {
                computationOption |= ComputationOption.UseArithmetic;
            }

            switch (computationOptionsString)
            {
                case "0":
                case "D+A":
                case "D+M":
                case "D&A":
                case "D&M":
                    break;
                case "-1":
                case "A":
                case "M":
                case "A-1":
                case "M-1":
                    computationOption |= ComputationOption.NegateX;
                    break;
                case "D":
                case "D-1":
                    computationOption |= ComputationOption.NegateY;
                    break;
                case "!D":
                case "-D":
                case "A-D":
                case "M-D":
                    computationOption |= ComputationOption.NegateY 
                        | ComputationOption.NegateOutput;
                    break;
                case "!A":
                case "!M":
                case "-A":
                case "D-A":
                case "D-M":
                    computationOption |= ComputationOption.NegateX
                        | ComputationOption.NegateOutput;
                    break;
                case "1":
                case "D+1":
                case "A+1":
                case "M+1":
                case "D|A":
                case "D|M":
                    computationOption |= ComputationOption.NegateX
                        | ComputationOption.NegateY
                        | ComputationOption.NegateOutput;
                    break;
                default:
                    return new Result<ComputationOption>(ComputationOption.None, $"Could not parse C-Instruction comp field: {computationOptionsString}.");
            }

            return new Result<ComputationOption>(computationOption);
        }
    }
}
