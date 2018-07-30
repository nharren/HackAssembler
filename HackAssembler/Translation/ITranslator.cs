using HackAssembler.Instructions;
using System.Collections.Generic;

namespace HackAssembler.Translation
{
    public interface ITranslator
    {
        Result<List<int>> Translate(IEnumerable<Instruction> instructions);
    }
}
