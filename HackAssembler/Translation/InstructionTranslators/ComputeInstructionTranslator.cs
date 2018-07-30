using HackAssembler.Instructions;

namespace HackAssembler.Translation.InstructionTranslators
{
    public class ComputeInstructionTranslator : IInstructionTranslator
    {
        // This represents the first three ones at the beginning of a C-instruction.
        private const int InstructionCodeBitMask = 7 << 13;

        public int Translate(Instruction instruction)
        {
            var computeInstruction = (ComputeInstruction)instruction;

            var computationOptionsBitMask = (int)computeInstruction.ComputationOptions << 6;
            var destinationsBitMask = (int)computeInstruction.Destinations << 3;
            var jumpConditionsBitMask = (int)computeInstruction.JumpConditions;

            return InstructionCodeBitMask
                | computationOptionsBitMask
                | destinationsBitMask
                | jumpConditionsBitMask;
        }
    }
}
