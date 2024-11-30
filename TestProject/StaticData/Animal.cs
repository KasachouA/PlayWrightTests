using System.Reflection;

namespace CoreTestProject.StaticData
{
    public class Animal
    {
        public string Name { get; init; }
        public string Sound { get; init; }

        private Animal(string name, string sound)
        {
            Name = name;
            Sound = sound;
        }

        public static List<Animal> GetAllConstants()
        {
            return typeof(Animal).GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(x => (Animal)x.GetValue(typeof(Animal))).ToList();
        }

        public static Animal Cat = new Animal("Cat", "Meow!");
        public static Animal Dog = new Animal("Dog", "Woof!");
        public static Animal Pig = new Animal("Pig", "Oink!");
        public static Animal Cow = new Animal("Cow", "Moo!");
    }
}
