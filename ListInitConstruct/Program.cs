
TestClass inst = new TestClass("abc", "def", "ghi");
inst.AddTwo("jkl", "mno");

foreach (string name in inst.names)
{
	Console.WriteLine(name);
}


class TestClass
{
	public List<string> names;

	public TestClass(string name1, string name2, string name3)
	{
		names = new List<string>();
		names.Add(name1);
		names.Add(name2);
		names.Add(name3);
	}

	public void AddTwo(string name4, string name5)
	{
		names.Add(name4);
		names.Add(name5);
	}
}
