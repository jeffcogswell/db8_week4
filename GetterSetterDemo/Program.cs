RAM mod1 = new RAM("Intel", "DDR3", 32);
Console.WriteLine(mod1.GetBrand());
// mod1.Brand = "AMD";  Can't do this!
mod1.SetType("DDR2");
Console.WriteLine(mod1.GetType());
mod1.SetType("Hello");
Console.WriteLine(mod1.GetType());
mod1.SetGB(100);
Console.WriteLine(mod1.GetGB());

// Compare:
//mod1.Type = "Hello";     -- Programmers want to do this
//mod1.SetType("Hello");   --    ...with this *actually* happening behind the scenes

class RAM
{
	// Common technique ("pattern") -- make all our member variables private
	// This is generally true for most programming languages, not just C#
	private string Brand;
	private string Type;  // DDR, DDR2, DDR3, DDR4
	private int GB;       // any number between 1 and 32 inclusive

	public RAM(string _Brand, string _Type, int _GB)
	{
		Brand = _Brand;
		if (_Type == "DDR" || _Type == "DDR2" || _Type == "DDR3" || _Type == "DDR4")
		{
			Type = _Type;
		}
		else
		{
			Type = "DDR";
		}
		if (_GB >= 1 && _GB <= 32)
		{
			GB = _GB;
		}
		else
		{
			GB = 4;
		}
	}

	// Let's set up this protection:
	//    1. The user cannot change the brand but can
	//       look at it (Read-Only)
	//    2. The user can set the type and look at it,
	//       but is limited to available types
	//       (Read/Write but with validation)
	//    3. The user can set the GB and look at it,
	//       but is limited the range 1 - 32.
	//       (Read/Write but with validation)

	// Methods called getters/setters

	public string GetBrand()
	{
		return Brand;
	}

	public string GetType()
	{
		return Type;
	}

	public void SetType(string _Type)
	{
		// Valid options:
		// DDR, DDR2, DDR3, DDR4
		if (_Type == "DDR" || _Type == "DDR2" || _Type == "DDR3" || _Type == "DDR4")
		{
			Type = _Type;
		}
		else
		{
			// Normally we would write something to a system log file for developers to read
		}

	}

	public int GetGB()
	{
		return GB;
	}

	public void SetGB(int value)  // Often for setters people just use the param name "value"
	{
		if (value >= 1 && value <= 32)
		{
			GB = value;
		}
	}
}

