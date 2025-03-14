using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Wk8Ex2_BookSerializeToDeserialize_Json
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Goal: Serialize book information to a text file, then unserialize it
            // create a book object. Get a file name in a string.
            // create a serialize method: Input the file name and book.
            // Serialize the book info to a string. StreamWrite the string to a text file.
            // in main, call the module and serialze the book
            // create a deserialize function: Input file name string
            // convert file content into a string, deserialize it using a parameterless Book constuctor
            // in main, call the deserialize module and deserialize the book back into an object
            // output the object details after deserialization


            // put file path/name into a string to call from modules "C:\Users\radec\source\repos\Wk8Ex2_BookSerializeToDeserialize_Json\Wk8Ex2_BookSerializeToDeserialize_Json\bookSerializationPractice.txt"
            string fileName = "C:\\Users\\radec\\source\\repos\\Wk8Ex2_BookSerializeToDeserialize_Json\\Wk8Ex2_BookSerializeToDeserialize_Json\\bookSerializationPractice.txt";

            // make the instance of book
            Book book1 = new Book("To Kill a Mockingbird", "Harper Lee", 1900);

            // serialize the book and put it into a file
            SerializeToJson(fileName, book1);

            // deserialize the book and put it in a new Book object called deserializedBook
            Book deserializedBook = DeserializeFromJson(fileName);

            // output the details of the deserialized book
            Console.WriteLine("Deserialized Book: {0}, {1}, {2}", deserializedBook.Title, deserializedBook.Author, deserializedBook.Year);

            // pause at the end of the program for user to read
            Console.Read();
        }

        // Book Class
        public class Book
        {
            // properties
            public string Title { get; set; }        // declare string property of the book class called Title
            public string Author { get; set; }         // declare string property of the book class called Author
            public int Year { get; set; }         // declare int property of the book class called Year

            // constructor
            public Book(string aTitle, string aAuthor, int aYear)
            {
                Title = aTitle;     // set the title used in the class to be the title we input
                Author = aAuthor;       // set the Author used in the class to be the Author we input
                Year = aYear;     // set the Year used in the class to be the Year we input
            }

            // paramaterless constructor for deserializing
            public Book() { }
        }


        // serialize to Json method
        public static void SerializeToJson(string fileName, Book book)
        {
            // serialize the book
            string serializedObj = JsonSerializer.Serialize(book);

            // test write the book to the screen to see how it outputs
            Console.WriteLine($"Serialized book string: {serializedObj}");

            // new streamwriter for the file name
            StreamWriter writer = new StreamWriter(fileName);

            // write the book info to the file
            writer.WriteLine(serializedObj);

            // close the writer so other processes can use the file
            writer.Close();

            // new streamreader to read file and check info
            StreamReader reader = new StreamReader(fileName);

            // check file info with streamreader
            Console.WriteLine("File read from serialization module: " + reader.ReadToEnd());


            // close the reader so other processes can use the file
            reader.Close();
        }

        // deserialize from Json method, parse Json string into class
        public static Book DeserializeFromJson(string fileName)
        {
            // read all text in the file and store it in a string
            string jsonFile = File.ReadAllText(fileName);
            // does this open a reader I would need to close? I don't have a named stream reader to reader.close, so I think it's fine. ???

            // take the string of information and put it in a book object. This uses the parapmaterless constructor.
            Book deserializedBook = JsonSerializer.Deserialize<Book>(jsonFile);


            // return the new object
            return deserializedBook;
        }        
    }
}
