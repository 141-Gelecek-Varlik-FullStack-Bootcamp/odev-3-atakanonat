namespace Comm.Model
{
    public class Common<T>
    {
        public bool IsSuccess { get; set; }
        public T Entity { get; set; }
        public string ExceptionMessage { get; set; }
    }
}