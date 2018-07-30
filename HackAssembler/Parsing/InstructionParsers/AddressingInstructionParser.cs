using HackAssembler.Instructions;

namespace HackAssembler.Parsing.InstructionParsers
{
    public class AddressingInstructionParser : IInstructionParser
    {
        public Result<Instruction> Parse(string instructionString)
        {
            if (instructionString[0] != '@')
            {
                return new Result<Instruction>(null, $"An '@' prefix was not found for A-Instruction: {instructionString}.");
            }

            var addressString = instructionString.Substring(1);
            int address;

            if (int.TryParse(addressString, out address))
            {
                return new Result<Instruction>(new AddressingInstruction(address));
            }

            return new Result<Instruction>(null, $"An invalid character was found in the A-Instruction: {instructionString}.");
        }
    }
}
