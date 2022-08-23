//
// Rental Store
// Always start by building your classes. "Model First".
//    (Make an instance of each as you go to test it out)
// Then make lists (or whatever) for your app.
// Populate the list with initial data
// 
// We broke the main app into individual tasks, which we put in their own methods.
// In this case:
//     Initialize -- populates the list with initial data
//     PrintMenu -- prints out a menu and asks for user's choice
//     Buy -- buys whatever the user chose (i.e. removes from list)
//     Add -- allows the user to add a new item to the list
//
// Data operations:
//     Added to it   (Create)
//     Printed it all out  (Read)
//     Edit (we skipped this part)   (Update)
//     Removed from it    (Delete)
//     "CRUD"
//
// Get the app working for one time around
// And finally add the "Would you like to go again" stuff.
//

// Main app
List<Media> allmedia = new List<Media>();
Init(allmedia);
while (true)
{
	string choice = PrintMenu(allmedia).ToLower();
	if (choice == "a")
	{
		AddNew(allmedia);
	}
	else if (choice == "q")
	{
		break;
	}
	else
	{
		int index = int.Parse(choice) - 1;
		Buy(allmedia, index);
	}
}

// Sample polymorphism
//static void DoSomething(Media item)
//{
//	item.Play(); // Even though the type passed in is "Media" we will manage to call the correct version of Play
//}

// Create data (into the database)
static void Init(List<Media> thelist)
{
	// Initialize the data
	// (In a "real" app, this would come from the database
	Video video1 = new Video("The Shining", "Horror", "Kubrick", "R");
	thelist.Add(video1);

	Digital dig1 = new Digital("The Wall", "Rock", "Pink Floyd", 80, "iTunes");
	thelist.Add(dig1);

	Vinyl vin1 = new Vinyl("The White Album", "Rock", "The Beatles", 45, 1000);
	thelist.Add(vin1);

	dig1 = new Digital("Invisible Touch", "Rock", "Genesis", 50, "iTunes");
	thelist.Add(dig1);
}

// Delete data from the database
static void Buy(List<Media> thelist, int index)
{
	// Ask the user which item
	// Print out the item and verify it's what they really want
	// Delete from the list

	//Console.WriteLine($"Buying something index {index}"); This was just to test out the function
	Console.WriteLine("Is this the item you want to buy?");
	Console.WriteLine(thelist[index]);  // THINK THIS THROUGH: We're grabbing the media instance and calling its ToString()
	Console.Write("y/n: ");
	string yesno = Console.ReadLine().ToLower();
	if (yesno == "y" || yesno == "yes")
	{
		thelist.RemoveAt(index);
		Console.WriteLine("Item purchased!");
	}
	else
	{
		Console.WriteLine("Thanks anyway!");
	}
}

// Create data (into the database)
static void AddNew(List<Media> thelist)
{
	// Ask what type they want to add
	// Get all the info
	// Add it to the list

	Console.Write("What would you like to add (video/digital/vinyl): ");
	string type = Console.ReadLine().ToLower();
	// Ask for title and genre before media-specific questions
	Console.Write("Title: ");
	string title = Console.ReadLine();

	Console.Write("Genre: ");
	string genre = Console.ReadLine();

	if (type == "video")
	{
		Console.Write("Director: ");
		string director = Console.ReadLine();

		Console.Write("Rating: ");
		string rating = Console.ReadLine();

		thelist.Add(new Video(title, genre, director, rating));
	}
	else if (type == "digital")
	{
		Console.Write("Artist: ");
		string artist = Console.ReadLine();

		Console.Write("Duration: ");
		string duration = Console.ReadLine();

		Console.Write("Platform: ");
		string platform = Console.ReadLine();

		thelist.Add(new Digital(title, genre, artist, int.Parse(duration), platform));

	}
	else if (type == "vinyl")
	{
		Console.Write("Artist: ");
		string artist = Console.ReadLine();

		Console.Write("Duration: ");
		string duration = Console.ReadLine();

		Console.Write("Count: ");
		string count = Console.ReadLine();

		thelist.Add(new Vinyl(title, genre, artist, int.Parse(duration), int.Parse(count)));
	}

}

// Read from the database
static string PrintMenu(List<Media> thelist)
{
	// Just two little tasks:
	//  Print out the menu
	//  Get the user's choice, and return the choice
	Console.WriteLine("Choose a media or other option:");
	for (int index = 0; index < thelist.Count; index++)
	{
		Media med = thelist[index];
		Console.WriteLine($"{index + 1}: {med}");
	}
	Console.WriteLine("(A)dd new media");
	Console.WriteLine("(Q)uit");
	Console.Write("Your choice: ");
	string entry = Console.ReadLine();
	return entry;
}

class Media
{
	public string Title;
	public string Genre;
	public Media(string _Title, string _Genre)
	{
		Title = _Title;
		Genre = _Genre;
	}
	public virtual void Play()
	{
		Console.WriteLine("The media is playing.");
	}
}

class Video : Media
{
	public string Director;
	public string Rating;
	public Video(string _Title, string _Genre, string _Director, string _Rating)
		: base(_Title, _Genre)
	{
		Director = _Director;
		Rating = _Rating;
	}
	public override void Play()
	{
		Console.WriteLine(ToString());
	}
	public override string ToString()
	{
		return $"Video {Title} ({Genre}) Directed by {Director} Rated {Rating}";
	}
}

class Music : Media
{
	public string Artist;
	public int Duration;
	public Music(string _Title, string _Genre, string _Artist, int _Duration)
		: base(_Title, _Genre)
	{
		Artist = _Artist;
		Duration = _Duration;
	}
	public override void Play()
	{
		Console.WriteLine("Music");
	}
}

class Digital : Music
{
	public string Platform;
	public Digital(string _Title, string _Genre, string _Artist, int _Duration, string _Platform)
		: base(_Title, _Genre, _Artist, _Duration)
	{
		Platform = _Platform;
	}
	public override void Play()
	{
		Console.WriteLine(ToString());
	}
	public override string ToString()
	{
		return $"Digital {Title} ({Genre}) by {Artist}, {Duration} minutes on {Platform}";
	}
}

class Vinyl : Music
{
	public int Count;   // How many records were printed
	public Vinyl(string _Title, string _Genre, string _Artist, int _Duration, int _Count)
		: base(_Title, _Genre, _Artist, _Duration)
	{
		Count = _Count;
	}
	public override void Play()
	{
		//base.Play();
		Console.WriteLine(ToString());
	}
	public override string ToString()
	{
		return $"Vinyl {Title} ({Genre}) by {Artist}, {Duration} minutes. {Count} limited copies.";
	}
}
