DateTime time1 = new DateTime(2022, 7, 31);
Console.WriteLine(time1.ToString("yyyy-MM-dd"));

DateTime time2 = DateTime.Now;
Console.WriteLine(time2);

DateTime time3 = DateTime.Parse("07/09/22 11:30am");
Console.WriteLine(time3.ToShortDateString());