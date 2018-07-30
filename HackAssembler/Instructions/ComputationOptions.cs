namespace HackAssembler.Instructions
{
    public enum ComputationOption
    {
        None = 0,
        NegateOutput = 1,
        UseArithmetic = 2,
        NegateY = 4,
        ZeroY = 8,
        NegateX = 16,
        ZeroX = 32,       
        UseAddressMemory = 64
    }
}
