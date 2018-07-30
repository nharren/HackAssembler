using HackAssembler.Instructions;

namespace HackAssembler.Parsing.InstructionParsers
{
    public interface IDestinationsParser
    {
        Result<Destination> Parse(string destinationString);
    }
}
