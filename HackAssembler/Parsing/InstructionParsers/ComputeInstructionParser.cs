using HackAssembler.Instructions;

namespace HackAssembler.Parsing.InstructionParsers
{
    public class ComputeInstructionParser : IInstructionParser
    {
        private readonly IDestinationsParser _destinationsParser;
        private readonly IComputationOptionsParser _computationOptionsParser;
        private readonly IJumpConditionsParser _jumpConditionsParser;

        public ComputeInstructionParser(
            IDestinationsParser destinationsParser,
            IComputationOptionsParser computationOptionsParser,
            IJumpConditionsParser jumpConditionsParser)
        {
            _destinationsParser = destinationsParser;
            _computationOptionsParser = computationOptionsParser;
            _jumpConditionsParser = jumpConditionsParser;
        }

        public Result<Instruction> Parse(string instructionString)
        {
            var equalsSplit = instructionString.Split('=');

            var destinations = Destination.None;
            var computationOptions = ComputationOption.None;
            var jumpConditions = JumpCondition.None;

            if (equalsSplit.Length > 1)
            {
                var destinationsParseResult = _destinationsParser.Parse(equalsSplit[0]);

                if (destinationsParseResult.Error != null)
                {
                    return new Result<Instruction>(null, destinationsParseResult.Error);
                }

                destinations = destinationsParseResult.Value;

                equalsSplit[0] = equalsSplit[1];
            }

            var semicolonSplit = equalsSplit[0].Split(';');

            var computationOptionsParseResult = _computationOptionsParser.Parse(semicolonSplit[0]);

            if (computationOptionsParseResult.Error != null)
            {
                return new Result<Instruction>(null, computationOptionsParseResult.Error);
            }

            computationOptions = computationOptionsParseResult.Value;

            if (semicolonSplit.Length > 1)
            {
                var jumpConditionsParseResult = _jumpConditionsParser.Parse(semicolonSplit[1]);

                if (jumpConditionsParseResult.Error != null)
                {
                    return new Result<Instruction>(null, jumpConditionsParseResult.Error);
                }

                jumpConditions = jumpConditionsParseResult.Value;
            }

            return new Result<Instruction>(new ComputeInstruction(destinations, computationOptions, jumpConditions));
        }
    }
}
