using HackAssembler.Instructions;

namespace HackAssembler.Parsing.InstructionParsers
{
    public class DestinationsParser : IDestinationsParser
    {
        public Result<Destination> Parse(string destinationString)
        {
            switch (destinationString)
            {
                case "M":
                    return new Result<Destination>(Destination.Memory);
                case "D":
                    return new Result<Destination>(Destination.DataRegister);
                case "MD":
                    return new Result<Destination>(Destination.Memory | Destination.DataRegister);
                case "A":
                    return new Result<Destination>(Destination.AddressRegister);
                case "AM":
                    return new Result<Destination>(Destination.AddressRegister | Destination.Memory);
                case "AD":
                    return new Result<Destination>(Destination.AddressRegister | Destination.DataRegister);
                case "AMD":
                    return new Result<Destination>(Destination.AddressRegister | Destination.Memory | Destination.DataRegister);
                default:
                    return new Result<Destination>(Destination.None, $"Could not parse C-Instruction dest field: {destinationString}.");
            }
        }
    }
}
