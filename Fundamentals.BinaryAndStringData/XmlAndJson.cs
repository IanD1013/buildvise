using System.Text.Json;
using System.Xml;

public sealed class XmlAndJson
{
    public void RunExample()
    {
        // there are two very popular file formats that we often
        // work with as programmers:
        // - XML
        // - JSON

        // XML is a markup language that is designed to store and transport data.

        // let's make an example XML to work with!
        string rawXml =
            """
    <people>
        <person>
            <name>John Doe</name>
            <age>42</age>
        </person>
        <person>
            <name>Jane Doe</name>
            <age>39</age>
        </person>
    </people>
    """;
        File.WriteAllText("people.xml", rawXml);

        // we can use the XmlDocument class to read and write XML files
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load("people.xml");

        // how might the XmlDocument class understand
        // how to go between the binary data of the file
        // and the text representation of the XML?

        // we can use the SelectNodes method to select nodes in the XML
        // the parameter that we pass in for being able to select
        // different data is called "XPath"
        XmlNodeList? people = xmlDocument.SelectNodes("/people/person");
        if (people == null)
        {
            Console.WriteLine("No people found!");
        }
        else
        {
            foreach (XmlNode person in people)
            {
                Console.WriteLine(person["name"].InnerText);
                Console.WriteLine(person["age"].InnerText);

                // let's change all the names to uppercase!
                //person.InnerText = person.InnerText.ToUpper();
                person["name"].InnerText = person["name"].InnerText.ToUpper();
                person["age"].InnerText = person["age"].InnerText.ToUpper();
            }
        }

        xmlDocument.Save("people2.xml");

        Console.WriteLine("Contents of People2:");
        Console.WriteLine(File.ReadAllText("people2.xml"));

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // but what about JSON?
        // it's lighter-weight but accomplishes a similar goal

        // let's make an example JSON to work with!
        // but this time, let's "deserialize" the JSON into a C# object!

        PeopleCollection peopleCollection = new PeopleCollection(new[]
        {
            new Person("John Doe", 42),
            new Person("Jane Doe", 39)
        });

        Console.WriteLine("Serializing people to JSON...");
        var rawJson = JsonSerializer.Serialize(peopleCollection);
        Console.WriteLine(rawJson);

        File.WriteAllText("people.json", rawJson);

        Console.WriteLine("Deserializing people from JSON using Stream...");
        using var peopleJsonStream = File.OpenRead("people.json");
        var deserializedPeopleFromStream = JsonSerializer.Deserialize<PeopleCollection>(peopleJsonStream);

        foreach (var person in deserializedPeopleFromStream.People)
        {
            Console.WriteLine($"{person.Name}: {person.Age}");
        }

        Console.WriteLine("Deserializing people from JSON using String...");
        var deserializedPeopleFromString = JsonSerializer.Deserialize<PeopleCollection>(File.ReadAllText("people.json"));

        foreach (var person in deserializedPeopleFromString.People)
        {
            Console.WriteLine($"{person.Name}: {person.Age}");
        }
    }

    public record Person(string Name, int Age);
    public record PeopleCollection(Person[] People);
}