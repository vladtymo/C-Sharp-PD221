namespace _12_polymorphism
{
    // abstract class can contains abstract methods
    abstract class File
    {
        enum Sizes { B, KB, MB, GB, TB };

        public const short BYTES_LIMIT = 1024;
        public string Name { get; set; }
        public string Extension { get; set; }
        public string FullName => $"{Name}.{Extension}";
        public long Bytes { get; private set; }
        public string NormilizedSize
        {
            get 
            {
                // 8 bytes          = 8 Bytes
                // 3450 bytes       = 3.5 KB
                // 2570000 bytes    = 2.6 MB
                // ...

                int sizeCount = Enum.GetValues(typeof(Sizes)).Length;
                double result = Bytes;
                int i = 0;

                while (i < sizeCount - 1 && result >= BYTES_LIMIT)
                {
                    result /= BYTES_LIMIT;
                    ++i;
                }

                return $"{Math.Round(result, 1)} {Enum.GetNames(typeof(Sizes))[i]}";
            }
        }
        public string? FullPath { get; private set; }
        public bool IsOpen { get; set; } = false;
        public DateTime CreationDate { get; }

        public File(string name, string ext, long bytes)
        {
            this.Name = name;
            this.Extension = ext;
            this.Bytes = bytes;
            this.CreationDate = DateTime.Now;
        }

        public void Open()
        {
            if (IsOpen)
            {
                Console.WriteLine($"File {Name} is already opened!");
            }
            else
            {
                Console.WriteLine($"File {Name} opened!");
                IsOpen = false;
            }
        }
        public void Clear()
        {
            Bytes = 0;
        }

        // abstract = virtual implicit
        public abstract void Preview();

        public override string ToString()
        {
            return $"File: {FullName} | {CreationDate} | {NormilizedSize}";
        }
    }

    class PresentationFile : File
    {
        public int Slides { get; set; }

        public PresentationFile(string name, string ext, long bytes) : base(name, ext, bytes)
        { }

        public void AddSlide(string name)
        {
            ++Slides;
            Console.WriteLine($"Slide {name} was successfuly added!");
        }
        public override void Preview()
        {
            Console.WriteLine($"Presentation {FullName} content ({Slides} slides):");
            for (int i = 0; i < Slides; i++)
            {
                Console.Write($"{'\u2588'} | ");
            }
            Console.WriteLine();
        }
    }

    class ImageFile : File
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public ImageFile(string name, string ext, long bytes, int w, int h) : base(name, ext, bytes)
        {
            Width = w;
            Height = h;
        }

        public void Crop(int w, int h)
        {
            Width = w;
            Height = h;
            Console.WriteLine($"Image {FullName} was successfuly cropped!");
        }
        public override void Preview()
        {
            Console.WriteLine($"Image preview content block:");
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write("X");
                }
                Console.WriteLine();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // cannot create an instance of an abstract class
            //File file1 = new File("test", "pdf", 780);

            PresentationFile presentation = new PresentationFile("classes", "pptx", 345362440)
            {
                Slides = 12
            };
            ImageFile avatar = new ImageFile("me", "png", 38573874, 1070, 1440);

            presentation.AddSlide("Introduction");
            avatar.Crop(44, 12);
            avatar.Open();

            File[] files =
            {
                presentation,
                avatar,
                new PresentationFile("Power BI", "pptx", 1037568200),
                new ImageFile("docker", "jpeg", 104834, 30, 14)
            };

            foreach (var f in files)
            {
                Console.WriteLine(f);
                f.Preview();
            }

            Console.WriteLine("--------------------------------");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"[{i}] - {files[i].FullName}");
            }
            Console.Write("---------------- Select a file:");
            int choice = int.Parse(Console.ReadLine());

            File selectedFile = files[choice];

            selectedFile.Preview();

            // -------------- casting types
            // 1 - using (type)object, throw the InvalidCast exception
            try
            {
                ((PresentationFile)selectedFile).AddSlide("New Slide");
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }

            // 2 - using {as} operator, return defaul value (null in our case)
            ImageFile image = selectedFile as ImageFile;
            image?.Crop(1, 1);

            // 3 - using {is} and {as} operators
            if (selectedFile is ImageFile)
            {
                (selectedFile as ImageFile).Crop(3, 3);
            }

            // feature: auto create a casted reference
            if (selectedFile is ImageFile picture)
            {
                picture.Crop(5, 5);
            }
        }
    }
}