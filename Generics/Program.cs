namespace Generics;

internal class Program
{
	static void Main(string[] args)
	{
		List<string> list = new List<string>(); //Generic: T wird nach unten übernommen (hier T = string)
		list.Add("123"); //T wird durch string ersetzt Add(T) -> Add(string)

		List<int> ints = new List<int>(); //T wird durch int ersetzt
		ints.Add(1);

		Dictionary<string, int> dict = new Dictionary<string, int>(); //Klasse mit 2 Generics: TKey -> string, TValue -> int
		dict.Add("123", 1);
	}
}

public class DataStore<T>
	: IProgress<T>, //T bei Vererbung weitergeben
	  IEquatable<int> //Fixer Typ statt T
{
	private T[] data; //T als Typ

	public List<T> Data => data.ToList(); //Generic wird nach unten weitergegeben

	public void Add(int index, T item) //T als Parameter
	{
		data[index] = item;
	}

	public T GetIndex(int i) //T als Rückgabewert
	{
		if (i < 0 || i > data.Length)
			return default(T); //default(T): Standardwert von T (int: 0, string: null, bool: false, ...)
		return data[i];
	}

	public void Report(T value) //T kommt von Interface
	{
		throw new NotImplementedException();
	}

	public bool Equals(int other)
	{
		throw new NotImplementedException();
	}

	public void PrintType<MyType>() //Methode mit Generic, T von oben hier nicht nochmal definieren
	{
		Console.WriteLine(typeof(MyType)); //Typ Objekt des Typs generieren
		Console.WriteLine(nameof(MyType)); //Gibt den Namen des Typs aus ("int", "string", "bool", ...)
		Console.WriteLine(default(MyType)); //default(T): Standardwert von T (int: 0, string: null, bool: false, ...)
		
		//if (MyType is int) { } //Nicht möglich

		if (typeof(MyType) == typeof(int)) //Typvergleich muss so gemacht werden
		{

		}
	}
}

public class DataStore2<T> : DataStore<T> { } //Klassen mit T vererben: braucht wieder T beim Klassennamen