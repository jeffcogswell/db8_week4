
Dog first = new Dog() { Name = "Fido", HairColor = "Black", BarkVolume = 8, LegCount = 4 };
//Console.WriteLine(first);
Dog second = new Dog() { Name = "Nellie", HairColor = "Yellow", BarkVolume = 5, LegCount = 4 };
Orangutan third = new Orangutan() { Name = "Fred", HairColor = "Orange", LegCount = 2, ThumbLength = 3 };
//Console.WriteLine(third);

List<Mammal> pets = new List<Mammal>();
pets.Add(first);  // Added the dog Fido to the list
pets.Add(second); // Added the dog Nellie to the list
pets.Add(third);  // Added the orangutan Fred to the list

foreach (Mammal pet in pets)
{
	string info = pet.ToString();  // C# will call the correct ToString for the object
	Console.WriteLine(info);
}

//Console.WriteLine();
//Console.WriteLine("Test method!");
//Test(third);

//static void Test(Mammal pet)
//{
//	string data = pet.ToString();
//	Console.WriteLine(data);
//}

class Mammal
{
	public string Name;
	public string HairColor;  // What color its hair is
	public int LegCount;      // How many legs it walks on

	public void Walk()
	{
		Console.WriteLine("I am walking.");
	}

	// We are overriding what's called a "virtual" function.
	// i.e. A "virtual" function is one that you can override.
	public override string ToString()
	{
		return "This is a mammal";
	}
}

class Dog : Mammal
{
	public int BarkVolume;   // How loud the dog's bark is
	public override string ToString()
	{
		return $"Dog named {Name}, hair {HairColor}, {LegCount} legs, barks at volume {BarkVolume}";
	}
}

class Orangutan : Mammal
{
	public int ThumbLength;  // How long the thumb is
	public override string ToString()
	{
		return $"Orangutan named {Name}, hair {HairColor}, {LegCount} legs, thumb is {ThumbLength} inches.";
	}
}

