public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    public bool LikesCoffee { get; set; }
    public List<string> Hobbies { get; set; } = new List<string>();

    public Person(string name, int age, string city, bool likesCoffee, List<string> hobbies)
    {
        Name = name;
        Age = age;
        City = city;
        LikesCoffee = likesCoffee;
        Hobbies = hobbies;
    }
}
