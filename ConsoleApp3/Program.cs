using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Animal
    {
        public string Name;
        public int Age;
        public string Species;
        public static bool operator ==(Animal animal1, Animal animal2)
        {
            if (ReferenceEquals(animal1, animal2))
                return true;
            if (ReferenceEquals(animal1, null) || ReferenceEquals(animal2, null))
                return false;
            return animal1.Equals(animal2);
        }
        public static bool operator !=(Animal animal1, Animal animal2)
        {
            return !(animal1 == animal2);
        }
        public override bool Equals(object obj)
        {
            Animal animal = (Animal)obj;
            if(animal.Age == Age && animal.Name == Name && animal.Species == Species)
            {
                return true;
            }
            return false;
        }
    }
    public class Mammal : Animal
    {
        public bool IsCarnivore;
    }
    public class Bird : Animal
    {
        public bool CanFly;
    }
    public class Zoo : Animal
    {
        public List<Animal> animals = new List<Animal>();
        public List<Animal> AddAnimal(Animal animal)
        {
            if (animal.Age != 0 && !string.IsNullOrWhiteSpace(animal.Name) && !string.IsNullOrWhiteSpace(animal.Species))
            {
                animals.Add(animal);
                return animals;
            }
            return null;
        }
        public void RemoveAnimal(Animal animal)
        {
            animals.RemoveAll(i => i == animal);
        }
        public Animal[] GetAnimalSpecies(string species)
        {
            int index = 0;
            Animal[] speciesAnimals = new Animal[animals.Count];
            foreach (var animal in animals)
            {
                if(animal.Species == species)
                {
                    speciesAnimals[index] = animal;
                    index++;
                }
            }
            return speciesAnimals;
        }
        public Animal GetAnimalWithName(string Name)
        {
            foreach (var animal in animals)
            {
                if(animal.Name == Name)
                {
                    return animal;
                }
            }
            return null;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Mammal Lion = new Mammal()
            {
                Name = "Lion",
                Age = 5,
                IsCarnivore = true,
                Species = "Panthera leo",
            };

            Bird Flamingo = new Bird()
            {
                Name = "Flamingo",
                Age = 4,
                CanFly = true,
                Species = "bird",
            };
            Bird eagle = new Bird()
            {
                Name = "eagle",
                Age = 10,
                CanFly = true,
                Species = "bird",
            };
            Zoo zoo = new Zoo();
            zoo.AddAnimal(Lion);
            zoo.AddAnimal(Flamingo);
            zoo.AddAnimal(eagle);
            foreach (var item in zoo.GetAnimalSpecies("bird"))
            {
                if(item != null)
                Console.WriteLine(item.Name + " " + item.Age + " " + item.Species);
            }

            Animal animal = zoo.GetAnimalWithName("Lion");
            Console.WriteLine(animal.Name + " " + animal.Age + " " + animal.Species);

            zoo.RemoveAnimal(Lion);
            foreach (var item in zoo.animals)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
    }
}
