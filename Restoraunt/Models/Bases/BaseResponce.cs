namespace Restoraunt.Models.Bases
{
    public class BaseResponce<T>
    {
        public bool Success => (Error ?? "") == string.Empty;

        public string Error { get; set; }

        public T Result { get; set; }

        public BaseResponce() { }

        public BaseResponce(T data) { Result = data; }
    }
}
