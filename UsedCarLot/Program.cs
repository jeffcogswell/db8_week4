List<Car> carlot = Init();

while (true)
{
	int choice = Menu(carlot);

	if (choice == carlot.Count + 1)
	{
		// add a car
		AddCar(carlot);
	}
	else if (choice == carlot.Count + 2)
	{
		// Quit
		break;
	}
	else // We could validate if it's outside the correct range
	{
		// Buy
		BuyCar(carlot, choice - 1);
	}
}

Console.WriteLine("Have a great day!");

// Initialize

static List<Car> Init()
{
	List<Car> thelist = new List<Car>();
	thelist.Add(new Car("Chevy", "Trax", 2022, 19000 ));
	thelist.Add(new Car("Honda", "Civic", 2022, 16000));
	thelist.Add(new Car("Honda", "Accord", 2022, 24000));
	thelist.Add(new UsedCar("Chevy", "Equinox", 2016, 14000, 60000));
	thelist.Add(new UsedCar("Toyota", "Camry", 2012, 10000, 80000));
	thelist.Add(new UsedCar("Honda", "Pilot", 2004, 2500, 180000));
	return thelist;
}

// Display the list along with Add and Quit
// Ask the user for their choice
static int Menu(List<Car> thelist)
{
	for (int index = 0; index < thelist.Count; index++)
	{
		Console.WriteLine($"({index + 1}) {thelist[index]}");
	}
	Console.WriteLine($"({thelist.Count + 1}) Add a car");
	Console.WriteLine($"({thelist.Count + 2}) Quit");

	string entry = Console.ReadLine();
	return int.Parse(entry);
}

// Add another car

static void AddCar(List<Car> thelist)
{
	Console.Write("Is this a new or used car? (new/used) ");
	string entry = Console.ReadLine().ToLower();

	// Ask for make, model, year, price
	Console.Write("Make: ");
	string make = Console.ReadLine();
	Console.Write("Model: ");
	string model = Console.ReadLine();
	Console.Write("Year: ");
	int year = int.Parse(Console.ReadLine());
	Console.Write("Price: ");
	decimal price = decimal.Parse(Console.ReadLine());

	if (entry == "new")
	{
		// Add a new car
		thelist.Add(new Car(make, model, year, price));
	}
	else
	{
		// Add a used car
		// Ask for mileage
		Console.Write("Mileage: ");
		double mileage = double.Parse(Console.ReadLine());
		thelist.Add(new UsedCar(make, model, year, price, mileage));
	}
}

// Buy the car

static void BuyCar(List<Car> thelist, int whichcar)
{
	Console.WriteLine(thelist[whichcar]);
	Console.Write("Would you like to buy this car? (y/n) ");
	string yesno = Console.ReadLine().ToLower();
	if (yesno == "y" || yesno == "yes")
	{
		thelist.RemoveAt(whichcar);
		Console.WriteLine("Excellent! Our finance department will be in touch shortly.");
	}
	else
	{
		Console.WriteLine("Thanks anyway!");
	}
}

class Car
{
	public string Make;
	public string Model;
	public int Year;
	public decimal Price;

	public Car(string Make, string Model, int Year, decimal Price)
	{
		this.Make = Make;
		this.Model = Model;
		this.Year = Year;
		this.Price = Price;
	}

	public override string ToString()
	{
		return $"New Car: {Year} {Make} {Model} - ${Price}";
	}
}

class UsedCar : Car
{
	public double Mileage;
	public UsedCar(string Make, string Model, int Year, decimal Price, double Mileage)
		: base(Make, Model, Year, Price)
	{
		this.Mileage = Mileage;
	}
	public override string ToString()
	{
		return $"Used Car: {Year} {Make} {Model}, {Mileage} miles - ${Price}";
	}
}
