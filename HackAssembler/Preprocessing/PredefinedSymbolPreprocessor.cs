namespace HackAssembler.Preprocessing
{
    public class PredefinedSymbolPreprocessor : IPreprocessor
    {
        public void Process(ref string[] source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                switch (source[i])
                {
                    case "@SP":
                    case "@R0":
                        source[i] = "@0";
                        break;
                    case "@LCL":
                    case "@R1":
                        source[i] = "@1";
                        break;
                    case "@ARG":
                    case "@R2":
                        source[i] = "@2";
                        break;
                    case "@THIS":
                    case "@R3":
                        source[i] = "@3";
                        break;
                    case "@THAT":
                    case "@R4":
                        source[i] = "@4";
                        break;
                    case "@R5":
                        source[i] = "@5";
                        break;
                    case "@R6":
                        source[i] = "@6";
                        break;
                    case "@R7":
                        source[i] = "@7";
                        break;
                    case "@R8":
                        source[i] = "@8";
                        break;
                    case "@R9":
                        source[i] = "@9";
                        break;
                    case "@R10":
                        source[i] = "@10";
                        break;
                    case "@R11":
                        source[i] = "@11";
                        break;
                    case "@R12":
                        source[i] = "@12";
                        break;
                    case "@R13":
                        source[i] = "@13";
                        break;
                    case "@R14":
                        source[i] = "@14";
                        break;
                    case "@R15":
                        source[i] = "@15";
                        break;
                    case "@SCREEN":
                        source[i] = "@16384";
                        break;
                    case "@KBD":
                        source[i] = "@24576";
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
