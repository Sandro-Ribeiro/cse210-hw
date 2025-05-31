using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // **** VIDEOS SETUPS ****

        // *** VIDEO 01 SETUP ***

        // Define title, author, and duration for video01
        string titleVideo01 = "Aula 1 - Introdução ao Machine Learning";
        string authorVideo01 = "Universidade de São Paulo (USP)";
        int lengthOfVideo01 = 5556;

        // Create first comment for video01
        Comment comment01Video01 = new Comment();
        comment01Video01.SetAuthor("@fabiosouza0899");
        comment01Video01.SetText("Adorei a aula parabéns pelo ensinamento");

        // Create second comment for video01
        Comment comment02Video01 = new Comment();
        comment02Video01.SetAuthor("@valcost42");
        comment02Video01.SetText("muito boa a aula, parabens galera, e obrigada!");

        // Create third comment for video01
        Comment comment03Video01 = new Comment();
        comment03Video01.SetAuthor("@RomuloMagalhaesAutoTOPO");
        comment03Video01.SetText("Grato");

        // Instantiate video01 object and set its properties
        Video video01 = new Video();
        video01.SetTitle(titleVideo01);
        video01.SetAuthor(authorVideo01);
        video01.SetLengthOfVideo(lengthOfVideo01);
        video01.AddComment(comment01Video01);
        video01.AddComment(comment02Video01);
        video01.AddComment(comment03Video01);


        // *** VIDEO 02 SETUP ***

        // Define title, author, and duration for video02
        string titleVideo02 = "Aula 02 - Aprofundando no Machine Learning";
        string authorVideo02 = "Universidade de São Paulo (USP)";
        int lengthOfVideo02 = 5981;

        // Create first comment for video02
        Comment comment01Video02 = new Comment();
        comment01Video02.SetAuthor("@andersonmiranda672");
        comment01Video02.SetText(
            "CARACA...VCS SÃO MUITO BONS.....certamente a pratica leva a perfeição....e" +
            "vcas devem ter suado muito para fazer com que esse conhecimento seja ensinado" +
            " de forma natural.... MUITO AGRADECIDO PELA OPORTUNIDADE"
            );

        // Create second comment for video02
        Comment comment02Video02 = new Comment();
        comment02Video02.SetAuthor("@empresasquevendem");
        comment02Video02.SetText("Louco para dominar o assunto!");

        // Create third comment for video02
        Comment comment03Video02 = new Comment();
        comment03Video02.SetAuthor("@pedrobatista5364");
        comment03Video02.SetText(
            "Ola estou participando apartir de Angola e gostei da aula." +
            "Existe muito conceito matematico para construção dos algoritmos" +
            " de aprendizado de máquina. Me ajudam a entender qual é a diferença" +
            " e vantagem em utilizar algoritmos ja prontos a partir das bibliotecas" +
            " que o python tem dentro do sklearn e a construção de algoritmos do zero?"
            );

        // Instantiate video02 object and set its properties
        Video video02 = new Video();
        video02.SetTitle(titleVideo02);
        video02.SetAuthor(authorVideo02);
        video02.SetLengthOfVideo(lengthOfVideo02);
        video02.AddComment(comment01Video02);
        video02.AddComment(comment02Video02);
        video02.AddComment(comment03Video02);


        // *** VIDEO 03 SETUP ***

        // Define title, author, and duration for video03
        string titleVideo03 = "Aula 02 - Aprofundando no Machine Learning";
        string authorVideo03 = "Universidade de São Paulo (USP)";
        int lengthOfVideo03 = 5981;

        // Create first comment for video03
        Comment comment01Video03 = new Comment();
        comment01Video03.SetAuthor("@andersonmiranda672");
        comment01Video03.SetText(
            "CARACA...VCS SÃO MUITO BONS.....certamente a pratica leva a perfeição....e" +
            "vcas devem ter suado muito para fazer com que esse conhecimento seja ensinado" +
            " de forma natural.... MUITO AGRADECIDO PELA OPORTUNIDADE"
            );

        // Create second comment for video03
        Comment comment02Video03 = new Comment();
        comment02Video03.SetAuthor("@empresasquevendem");
        comment02Video03.SetText("Louco para dominar o assunto!");

        // Create third comment for video03
        Comment comment03Video03 = new Comment();
        comment03Video03.SetAuthor("@pedrobatista5364");
        comment03Video03.SetText(
            "Ola estou participando apartir de Angola e gostei da aula." +
            "Existe muito conceito matematico para construção dos algoritmos" +
            " de aprendizado de máquina. Me ajudam a entender qual é a diferença" +
            " e vantagem em utilizar algoritmos ja prontos a partir das bibliotecas" +
            " que o python tem dentro do sklearn e a construção de algoritmos do zero?"
            );

        // Instantiate video03 object and set its properties
        Video video03 = new Video();
        video03.SetTitle(titleVideo03);
        video03.SetAuthor(authorVideo03);
        video03.SetLengthOfVideo(lengthOfVideo03);
        video03.AddComment(comment01Video03);
        video03.AddComment(comment02Video03);
        video03.AddComment(comment03Video03);


        // **** VISUALIZATION OF VIDEOS ****

        Console.Clear();
        int widthMax = 80;
        string mainTitle = "LIST OF VIDEOS AND ITS COMMENTS";
        int widthRemaining = widthMax - mainTitle.Length;
        int widthLeft = widthRemaining / 2;
        int widthRight = widthRemaining - widthLeft;
        string leftPadding = new string(' ', widthLeft-1);
        string rightPadding = new string(' ', widthRight - 1);

        Console.WriteLine(new string('-', widthMax));
        Console.WriteLine($"|" + new string(' ',widthMax-2) + "|");
        Console.WriteLine("|" + $"{leftPadding}{mainTitle}{rightPadding}" + "|");
        Console.WriteLine($"|" + new string(' ', widthMax -2) + "|");
        Console.WriteLine(new string('-', widthMax));


        // *** Video 01 ***

        int counter = 1;
        Console.WriteLine();
        Console.WriteLine($"VIDEO {counter}");
        Console.WriteLine();
        Console.WriteLine($"Title: {video01.GetTitle()}");
        Console.WriteLine($"Author: {video01.GetAuthor()}");
        Console.WriteLine($"Length: {video01.GetLengthOfVideo()}");
        Console.WriteLine();
        Console.WriteLine($"COMMENTS");
        video01.DisplayComments();
        Console.WriteLine();
        Console.WriteLine(new string('-', 80));



        // *** Video 02 ***

        counter += 1;
        Console.WriteLine();
        Console.WriteLine($"VIDEO {counter}");
        Console.WriteLine();
        Console.WriteLine($"Title: {video02.GetTitle()}");
        Console.WriteLine($"Author: {video02.GetAuthor()}");
        Console.WriteLine($"Length: {video02.GetLengthOfVideo()}");
        Console.WriteLine();
        Console.WriteLine($"COMMENTS");
        video02.DisplayComments();
        Console.WriteLine();
        Console.WriteLine(new string('-', 80));



        // *** Video 03 ***

        counter += 1;
        Console.WriteLine();
        Console.WriteLine($"VIDEO {counter}");
        Console.WriteLine();
        Console.WriteLine($"Title: {video03.GetTitle()}");
        Console.WriteLine($"Author: {video03.GetAuthor()}");
        Console.WriteLine($"Length: {video03.GetLengthOfVideo()}");
        Console.WriteLine();
        Console.WriteLine($"COMMENTS");
        video03.DisplayComments();
        Console.WriteLine();
        Console.WriteLine(new string('-', 80));

        // Exit and clean terminal

        Console.WriteLine();
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
        Console.Clear();

    }
}