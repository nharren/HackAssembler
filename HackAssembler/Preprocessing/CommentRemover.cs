namespace HackAssembler.Preprocessing
{
    public class CommentRemover : IPreprocessor
    {
        public void Process(ref string[] source)
        {
            for (int i = 0; i < source.Length; i++)
            {
                source[i] = source[i].Split("//")[0];
            }
        }
    }
}
