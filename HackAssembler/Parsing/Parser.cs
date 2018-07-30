using HackAssembler.Instructions;
using HackAssembler.Parsing.InstructionParsers;
using System.Collections.Generic;

namespace HackAssembler.Parsing
{
    public class Parser : IParser
    {
        private readonly IEnumerable<IInstructionParser> _instructionParsers;

        public Parser(IEnumerable<IInstructionParser> instructionParsers)
        {
            _instructionParsers = instructionParsers;
        }

        public Result<List<Instruction>> Parse(string[] source)
        {
            var instructions = new List<Instruction>();

            for (int i = 0; i < source.Length; i++)
            {
                bool couldParse = false;

                foreach (var instructionParser in _instructionParsers)
                {
                    var parseResult = instructionParser.Parse(source[i]);

                    if (parseResult.Error != null)
                    {
                        continue;
                    }

                    instructions.Add(parseResult.Value);
                    couldParse = true;

                    break;
                }

                if (!couldParse)
                {
                    return new Result<List<Instruction>>(null, $"Unrecognized instruction: {source[i]}.");
                }
            }

            return new Result<List<Instruction>>(instructions);
        }
    }
}
