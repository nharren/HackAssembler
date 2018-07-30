namespace HackAssembler.Instructions
{
    public class ComputeInstruction : Instruction
    {
        public ComputeInstruction(Destination destinations, ComputationOption computationOptions, JumpCondition jumpConditions)
        {
            Destinations = destinations;
            ComputationOptions = computationOptions;
            JumpConditions = jumpConditions;
        }

        public Destination Destinations { get; }
        public ComputationOption ComputationOptions { get; }
        public JumpCondition JumpConditions { get; }
    }
}
