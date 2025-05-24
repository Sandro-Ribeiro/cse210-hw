using System;

class Program
{
    static void Main(string[] args)
    {
        string book = "Alma";
        int chapter = 34;
        int verse = 30;
        int endVerse = 32;
        string text = "And now, my brethren, I would that, after ye have received so many witnesses," +
        " seeing that the holy scriptures testify of these things, ye come forth and bring fruit unto repentance." +
        " Yea, I would that ye would come forth and harden not your hearts any longer; for behold, now is the time" +
        " and the day of your salvation; and therefore, if ye will repent and harden not your hearts, immediately" +
        " shall the great plan of redemption be brought about unto you.For behold, this life is the time for men to" +
        " prepare to meet God; yea, behold the day of this life is the day for men to perform their labors.";

        Reference reference = new Reference(book, chapter, verse, endVerse);
        Scripture scripture = new Scripture(reference, text);  
    }
}