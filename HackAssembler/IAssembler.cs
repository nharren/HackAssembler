using System.Collections.Generic;

namespace HackAssembler
{
    public interface IAssembler
    {
        Result<List<string>> Assemble(string[] source);
    }
}
