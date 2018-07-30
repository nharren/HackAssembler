namespace HackAssembler.Preprocessing
{
    public interface IPreprocessor
    {
        void Process(ref string[] source);
    }
}
