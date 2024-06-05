using System;

// need a way to store each item with the id
// im thinking maybe a python like dictionary where the id is the key and the item is the value
// use the dictionary class https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.containskey?view=net-8.0
public class ItemInfo
{
	private string name;
	private double price;

	public ItemInfo(string name, double price)
	{
		this.name = name;
		this.price = price;
	}

	public string getName() { return  name; }
	public double getPrice() { return price; }

	public int generateId()
	{
		// format should look like 5252024 (current day of coding) 000000 (6 zeros) then a number incremented by 1 per item
		// we get the day infor using datetime and convert them to strings
		string day = System.DateTime.Now.Day.ToString();
		string month = System.DateTime.Now.Month.ToString();
		string  year = System.DateTime.Now.Year.ToString();
		
		//one big format 
		string idFormat = day + month + year.Substring(2) + "000";

		int id = Convert.ToInt32(idFormat); //converting the big format into the necessary bullshit 

        return id;
	}

	public string toString() { return name + " " + price; }
}
