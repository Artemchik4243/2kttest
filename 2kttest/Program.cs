using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Formats.Asn1;
using System.Xml;

public class Member
{
    public string name { get; set; }
    public int age { get; set; }
    public string secretIdentity { get; set; }
    public List<string> powers { get; set; }
}

public class Squad
{
    public string squadName { get; set; }
    public string homeTown { get; set; }
    public int formed { get; set; }
    public string secretBase { get; set; }
    public bool active { get; set; }
    public List<Member> members { get; set; }
}

class Program
{
    static void Main()
    {
        string jsonFilePath = "E:\\test\\2\\2\\SuperHero.json";
        string jsonContent = File.ReadAllText(jsonFilePath);

        Squad squad = JsonConvert.DeserializeObject<Squad>(jsonContent);

        Member newMember1 = new Member
        {
            name = "Patrick",
            age = 20,
            secretIdentity = "Психопат",
            powers = new List<string> { "axe", "music" }
        };

        Member newMember2 = new Member
        {
            name = "batmen",
            age = 30,
            secretIdentity = "Брюс уэйн",
            powers = new List<string> { "money", "Robin" }
        };


        squad.members.Add(newMember1);
        squad.members.Add(newMember2);

        squad.members = squad.members.OrderByDescending(m => m.age).ToList(); squad.members = squad.members.OrderByDescending(m => m.age).ToList();
        string updatedJson = JsonConvert.SerializeObject(squad, Formatting.Indented);

        string UpdJsonFilePath = "E:\\test\\2\\2\\SuperHero.json";

        File.WriteAllText(UpdJsonFilePath, updatedJson);

        Console.WriteLine("JSON файл успешно обновлен.");
    }
}
