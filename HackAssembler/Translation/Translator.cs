using HackAssembler.Instructions;
using HackAssembler.Translation.InstructionTranslators;
using System;
using System.Collections.Generic;

namespace HackAssembler.Translation
{
    public class Translator : ITranslator
    {
        private readonly IDictionary<Type, IInstructionTranslator> _translatorDictionary;

        public Translator(IDictionary<Type, IInstructionTranslator> translatorDictionary)
        {
            _translatorDictionary = translatorDictionary;
        }

        public Result<List<int>> Translate(IEnumerable<Instruction> instructions)
        {
            var machineCode = new List<int>();

            foreach (var instruction in instructions)
            {
                IInstructionTranslator instructionTranslator = null;

                if (!_translatorDictionary.TryGetValue(instruction.GetType(), out instructionTranslator))
                {
                    return new Result<List<int>>(null, $"Could not translate instruction to machine code for type: {instruction.GetType()}.");
                }

                machineCode.Add(instructionTranslator.Translate(instruction));
            }

            return new Result<List<int>>(machineCode);
        }
    }
}
