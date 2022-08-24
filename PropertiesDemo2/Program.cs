Rectangle r1 = new Rectangle(10.5m, 3.6m);
Console.WriteLine(r1);

// Let's change the Height to a non-positive number.
r1.Height = -5;
Console.WriteLine(r1.Height);

class Rectangle
{
	// Let's keep Length with the easy shortcut -- C# makes the private variable for us
	// Why would we do this? We don't really need to except when we're using databases and APIs.
	public decimal Length { get; set; }

	// Let's do validation with Height: Verify that height is always > 0.
	private decimal pHeight;  // Our own private variable
	public decimal Height
	{ 
		get
		{
			return pHeight;
		} 
		set
		{
			if (value > 0)
			{
				pHeight = value;
			}
			else
			{
				pHeight = 1;
			}
		}
	}
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
