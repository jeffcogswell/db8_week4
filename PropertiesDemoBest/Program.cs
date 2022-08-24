Rectangle r1 = new Rectangle(10.5m, 3.6m);
Console.WriteLine(r1);

class Rectangle
{
	// Instead of regular member variables like this:
	// public decimal Length;
	// public decimal Height;
	// Add on the { get; set; } to each
	// and just like that, like magic, they are now properties.

	public decimal Length { get; set; }
	public decimal Height { get; set; }
	public Rectangle(decimal _Length, decimal _Height)
	{
		Length = _Length;
		Height = _Height;
	}
	public override string ToString()
	{
		return $"{Length} {Height} Area: {Length * Height}";
	}
}

