namespace Sprachfeatures;

internal class Program
{
	static void Main(string[] args)
	{
		string name = "lukas";
		string nameFix = char.ToUpper(name[0]) + name[1..].ToLower();

		Program p = null;

		Dictionary<string, int> dict = new();

		Person person = new(0, "Test", null);

		//if ({ person.Vorgesetzter.Vorgesetzter.Vorgesetzter.Name: ""})
		//{

		//}
	}
}

public record Person(int ID, string Name, Person Vorgesetzter)
{
	public void Test()
	{

	}
}