namespace HackAssembler
{
    public class Result<T>
    {
        public Result(T value)
        {
            Value = value;
            Error = null;
        }

        public Result(T value, string error)
        {
            Value = value;
            Error = error;
        }

        public string Error { get; }
        public T Value { get; }
    }
}
