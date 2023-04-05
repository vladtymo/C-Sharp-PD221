namespace _10_overloading.Indexer
{
    public class Laptop
    {
        public string Vendor { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $"{Vendor} {Price}";
        }
    }
    public class Shop
    {
        private Laptop[] laptopArr;
        public Shop(int size)
        {
            laptopArr = new Laptop[size];
        }
        public int Length
        {
            get { return laptopArr.Length; }
        }

        //public Laptop GetLaptop(int index)
        //{
        //    if (index >= 0 && index < laptopArr.Length)
        //    {
        //        return laptopArr[index];
        //    }
        //    throw new IndexOutOfRangeException();
        //}
        //public void SetLaptop(int index, Laptop value)
        //{
        //    laptopArr[index] = value;
        //}

        // overload indexer operator
        public Laptop this[int index]
        {
            get
            {
                if (index >= 0 && index < laptopArr.Length)
                {
                    return laptopArr[index];
                }
                throw new IndexOutOfRangeException();
                //Console.WriteLine("Index Out Of Range");
                //return null;
            }
            set
            {
                if (index >= 0 && index < laptopArr.Length)
                    laptopArr[index] = value;
            }
        }
    }


}
