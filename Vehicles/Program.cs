Sedan mycar = new Sedan(4, "Blue", true, 4);
mycar.Drive();

RaceCar myracecar = new RaceCar(4, "Red", 400);
myracecar.Drive();

RaceCar secondracer = new RaceCar(3, "Yellow", 1000);

List<Vehicle> cars = new List<Vehicle>();
cars.Add(mycar);
cars.Add(myracecar);
cars.Add(secondracer);

Console.WriteLine();
Console.WriteLine("Everybody drive!");

foreach (Vehicle car in cars)
{
	car.Drive();
}

// This commented code demonstrates polymorphism
//Vehicle something;
//something = mycar;
//something.Drive(); // It will call the correct version

//something = myracecar;
//something.Drive(); // Again, correct version

// Calling the correct version is known as "polymorphism".

class Vehicle
{
	public int WheelCount;
	public string Color;
	public Vehicle(int _WheelCount, string _Color)
	{
		WheelCount = _WheelCount;
		Color = _Color;
	}
	public virtual void Drive()
	{
		Console.WriteLine($"I am driving a {Color} car with {WheelCount} wheels.");
	}
}

class Sedan : Vehicle  // Ignore the error about construtor parameters. We'll get there!
{
	public bool HasHatchBack;
	public int DoorCount;
	public Sedan(int _SedanWheelCount, string _SedanColor, bool _HasHatchBack, int _DoorCount) 
		: base(_SedanWheelCount, _SedanColor)
	{
		WheelCount = _SedanWheelCount;
		Color = _SedanColor;
		HasHatchBack = _HasHatchBack;
		DoorCount = _DoorCount;
	}
	public override void Drive()
	{
		Console.WriteLine($"I am driving speed limit in my {Color} {DoorCount}-door car!");
	}
}

class RaceCar : Vehicle
{
	public int EngineSize;
	public RaceCar(int _WheelCount, string _Color, int _EngineSize)
		: base(_WheelCount, _Color)
	{
		EngineSize = _EngineSize;
	}

	public override void Drive()
	{
		Console.WriteLine($"I am driving really fast with my {EngineSize} engine! The car is {Color}.");
	}
}