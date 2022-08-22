Dictionary<string, Rectangle> rects = new Dictionary<string, Rectangle>();

rects["first"] = new Rectangle("Fred", 3.5, 4.6);
rects["second"] = new Rectangle("Sally", 5.5, 6.6);
rects["third"] = new Rectangle("Sam", 10.0, 11.5);

// This gets too messy

rects["first"].Length = 10;

foreach (var pair in rects)
{
	Console.WriteLine($"Key: {pair.Key}  Value: {pair.Value}");
}


class Rectangle
{
	public string Name;
	public double Length;
	public double Height;

	public Rectangle(string _Name, double _Length, double _Height)
	{
		Name = _Name;
		Length = _Length;
		Height = _Height;
	}

	public override string ToString()
	{
		return $"{Name}:{Length}x{Height}";
	}
}

