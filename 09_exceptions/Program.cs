namespace _09_exceptions
{
    class Book
    {
        private string title;

        public string Title
        {
            get { return title; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Title can not be empty!");

                if (!char.IsUpper(value[0]))
                    throw new Exception("Title must start with upper letter!");

                title = value;
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // input data
            }
            catch (Exception)
            {
                // handling
            }
        }
    }
}