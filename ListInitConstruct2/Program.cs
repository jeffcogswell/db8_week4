// Requirements:
//    Can add additional edges
//    Can change the length of an edge. For example change edge "b" from 4 to 5.

Polygon poly1 = new Polygon("Fred", new Edge("a", 5), new Edge("b", 4), new Edge("c", 3));
Console.WriteLine(poly1);

poly1.AddEdge(new Edge("b", 6));
Console.WriteLine(poly1);

poly1.ChangeEdge("b", 5);
Console.WriteLine(poly1);

Console.WriteLine();
Console.Write("Which edge would you like to change? ");
string edge = Console.ReadLine();
Console.Write("What size do you want to change it to? ");
string entry = Console.ReadLine();
double length = double.Parse(entry);

poly1.ChangeEdge(edge, length);
Console.WriteLine(poly1);

class Edge
{
	public string Name;
	public double Length;
	public Edge(string _Name, double _Length)
	{
		Name = _Name;
		Length = _Length;
	}
}

class Polygon
{
	public string Name;
	public List<Edge> Edges;
	public Polygon(string _Name, Edge edge1, Edge edge2, Edge edge3)
	{
		Name = _Name;
		Edges = new List<Edge>();
		Edges.Add(edge1);
		Edges.Add(edge2);
		Edges.Add(edge3);
	}

	public void AddEdge(Edge another)
	{
		Edges.Add(another);
	}

	public void ChangeEdge(string which, double newLength)
	{
		//foreach (Edge ed in Edges)
		//{
		//	if (ed.Name == which)
		//	{
		//		ed.Length = newLength;
		//		return;
		//	}
		//}

		Edge found = null;
		foreach (Edge ed in Edges)
		{
			if (ed.Name == which)
			{
				found = ed;
				break;
			}
		}
		if (found != null)
		{
			found.Length = newLength;
		}
	}

	public override string ToString()
	{
		string result = "";
		string comma = "";
		foreach (Edge ed in Edges)
		{
			result = result + $"{comma}{ed.Name}:{ed.Length}";
			comma = ",";
		}
		return $"{Name} = {result}";
	}
}

