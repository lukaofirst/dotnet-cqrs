namespace Domain.Entities
{
    public class Person
    {
        public int Id { get; protected set; }
        public string? Name { get; protected set; }
        public int Age { get; protected set; }

        public Person(int id, string? name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }
}
