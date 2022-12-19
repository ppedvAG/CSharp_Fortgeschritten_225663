namespace DelegatesEvents;

internal class Delegates
{
	public delegate void Vorstellungen(string name); //Definition von Delegate, speichert Referenzen auf Methoden, können zur Laufzeit hinzugefügt oder weggenommen werden

	static void Main(string[] args)
	{
		Vorstellungen v = new Vorstellungen(VorstellungDE); //Variablendeklaration + Erstellung mit einer Initialmethode
		v("Max"); //Delegate ausführen

		v += new Vorstellungen(VorstellungEN); //Methode anhängen (lang)
		v += VorstellungEN; //Methode anhängen kurz
		v("Max"); //Methoden werden in der Reihenfolge ausgeführt in der sie angehängt wurden

		v += VorstellungDE;
		v += VorstellungDE;
		v += VorstellungDE; //Methoden können mehrmals angehängt werden
		v("Max");

		v -= VorstellungEN; //Methode abnehmen
		v -= VorstellungEN;
		v -= VorstellungEN;
		v -= VorstellungEN; //Methode die nicht angehängt ist, kann nicht abgenommen werden -> nichts passiert
		v("Max");

		v -= VorstellungDE;
		v -= VorstellungDE;
		v -= VorstellungDE;
		v -= VorstellungDE; //Delegate ist null wenn keine Methode mehr angehängt ist
		
		if (v is not null) //Null-Check
			v("Max");

		v?.Invoke("Max"); //Wenn v nicht null, dann ausführen, sonst nichts

		List<int> test = null; //Funktioniert bei allen Methoden
		test?.Add(2);

		v = null; //Delegate entleeren
	
		foreach (Delegate dg in v.GetInvocationList()) //Delegate anschauen
		{
			Console.WriteLine(dg.Method.Name); //Auf Methode zugreifen
		}
	}

	static void VorstellungDE(string name) => Console.WriteLine($"Hallo mein Name ist {name}");

	static void VorstellungEN(string name) => Console.WriteLine($"Hello my name is {name}");
}