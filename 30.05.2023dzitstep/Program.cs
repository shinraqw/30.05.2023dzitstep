namespace _30._05._2023dz
{
    internal class Program
    {
        static void Main()
        {
            PoemCollection collect = new PoemCollection();



            Poem poem1 = new Poem
            {
                Title = "Wings",
                Author = "Lina Kostenko",
                Year = 1958,
                Text = "А й правда, крилатим ґрунту не треба.",
                Theme = "Freedom of thought"
            };
            collect.AddPoem(poem1);
            Console.WriteLine("Add poem 2 to file");

            Poem poem2 = new Poem
            {
                Title = "The Raven",
                Author = "Edgar Allan Poe",
                Year = 1845,
                Text = "Once upon a midnight dreary...",
                Theme = "Gothic"
            };
            collect.AddPoem(poem2);
            Console.WriteLine("Add poem 1 to file");

            Poem poem3 = new Poem
            {
                Title = "Sonnet 78",
                Author = "William Shakespeare",
                Year = 1914,
                Text = "I miraculously dreamed and created the Muse She appeared - so light, full of wings;",
                Theme = "Love"
            };
            collect.AddPoem(poem3);
            Console.WriteLine("Add poem 3 to file\n");


            List<Poem> poemsWithTitle = collect.SearchPoemsByTitle("The Raven");
            Console.WriteLine("Search poem with title 'Raven':");
            PrintPoems(poemsWithTitle);

            List<Poem> poemsWithAuthor = collect.SearchPoemsByAuthor("William Shakespeare");
            Console.WriteLine("Search poem with author 'William Shakespeare':");
            PrintPoems(poemsWithAuthor);

            List<Poem> poemsWithYear = collect.SearchPoemsByYear(1945);
            Console.WriteLine("Search poem with year of wrote '1945':");
            PrintPoems(poemsWithYear);

            List<Poem> poemsWithTheme = collect.SearchPoemsByTheme("Love");
            Console.WriteLine("Search poem with theme 'Love':");
            PrintPoems(poemsWithTheme);

            Poem poemUpdate = poemsWithAuthor[0];
            Poem updatedPoem = new Poem
            {
                Title = "The Raven",
                Author = "Edgar Allan Poe",
                Year = 1845,
                Text = "Thrilled me—filled me with fantastic terrors never felt before",
                Theme = "Gothic "
            };
            collect.UpdatePoem(poemUpdate, updatedPoem);
            Console.WriteLine("Poem 1 was updated\n");

            collect.RemovePoem(poem3);
            Console.WriteLine("Poem 3 was deleted\n");

            collect.SaveCollectionToFile("poems.txt");
            Console.WriteLine("Poems was saved to file\n");

            PoemCollection loadedCollect = new PoemCollection();
            loadedCollect.LoadCollectionFromFile("poems.txt");
            Console.WriteLine("Poems was loaded from file:");
            PrintPoems(loadedCollect.GetAllPoems());

            Console.WriteLine();
            Console.WriteLine("Reports=");
            Console.Write("Enter title the report: ");

            string reportTitle = Console.ReadLine();
            List<Poem> poemsByTitle = collect.GenerateReportByTitle(reportTitle);
            Console.WriteLine($"Report for poems with title '{reportTitle}':");
            PrintPoems(poemsByTitle);

            Console.Write("Enter author the report: ");
            string reportAuthor = Console.ReadLine();
            List<Poem> poemsByAuthor = collect.GenerateReportByAuthor(reportAuthor);
            Console.WriteLine($"Report for poems by author '{reportAuthor}':");
            PrintPoems(poemsByAuthor);

            Console.Write("Enter theme  the report: ");
            string reportTheme = Console.ReadLine();
            List<Poem> poemsByTheme = collect.GenerateReportByTheme(reportTheme);
            Console.WriteLine($"Report for poems with theme '{reportTheme}':");
            PrintPoems(poemsByTheme);

            Console.Write("Enter text the report: ");
            string reportWord = Console.ReadLine();
            List<Poem> poemsByWord = collect.GenerateReportByWordInText(reportWord);
            Console.WriteLine($"Report for poems containing the word '{reportWord}' in the text:");
            PrintPoems(poemsByWord);

            Console.Write("Enter year the report: ");
            int reportYear = int.Parse(Console.ReadLine());
            List<Poem> poemsByYear = collect.GenerateReportByYear(reportYear);
            Console.WriteLine($"Report for poems written in the year {reportYear}:");
            PrintPoems(poemsByYear);

            Console.Write("Enter the length of poem for the report: ");
            int reportLength = int.Parse(Console.ReadLine());
            List<Poem> poemsByLength = collect.GenerateReportByLength(reportLength);
            Console.WriteLine($"Report for poems with a length of {reportLength} characters:");
            PrintPoems(poemsByLength);
        }

        static void PrintPoems(List<Poem> poems)
        {
            if (poems.Count > 0)
            {
                foreach (Poem p in poems)
                {
                    Console.WriteLine($"Author: {p.Author}");
                    Console.WriteLine($"Title: {p.Title}");
                    Console.WriteLine($"Year: {p.Year}");
                    Console.WriteLine($"Theme: {p.Theme}");
                    Console.WriteLine($"Text: {p.Text}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No found poems ");
            }
        }
    }
}