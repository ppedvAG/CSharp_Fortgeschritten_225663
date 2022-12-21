using System.Text;

namespace LinqErweiterungsmethoden;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		//Enumerable.Range: Liste von <Start> mit <Anzahl> Elementen
		//Liste von 1-20
		List<int> ints = Enumerable.Range(1, 20).ToList();

		Console.WriteLine(ints.Average());
		Console.WriteLine(ints.Min());
		Console.WriteLine(ints.Max());
		Console.WriteLine(ints.Sum());

		Console.WriteLine(ints.First()); //Gibt das erste Element, Exception falls kein Element existiert
		Console.WriteLine(ints.FirstOrDefault()); //Gibt das erste Element, null falls kein Element existiert

		Console.WriteLine(ints.Last()); //Gibt das letzte Element, Exception falls kein Element existiert
		Console.WriteLine(ints.LastOrDefault()); //Gibt das letzte Element, null falls kein Element existiert

		//Console.WriteLine(ints.First(e => e % 50 == 0)); //Gib die erste Zahl in der Liste die durch 50 teilbar ist (Exception)
		Console.WriteLine(ints.FirstOrDefault(e => e % 50 == 0)); //Gib die erste Zahl in der Liste die durch 50 teilbar ist (0)
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Vergleich Linq Schreibweisen
		//Alle BMWs finden
		List<Fahrzeug> bmwsForEach = new();
		foreach (Fahrzeug f in fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				bmwsForEach.Add(f);

		//Standard-Linq: SQL-ähnliche Schreibweise (alt)
		List<Fahrzeug> bmwsAlt = (from f in fahrzeuge
								  where f.Marke == FahrzeugMarke.BMW
								  select f).ToList();

		//Methodenkette
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).ToList();
		#endregion

		#region Linq mit Objektliste
		//Alle Fahrzeuge mit MaxV > 200
		fahrzeuge.Where(e => e.MaxV > 200);

		//Alle VWs mit MaxV > 200
		fahrzeuge.Where(e => e.MaxV > 200 && e.Marke == FahrzeugMarke.VW);

		//Autos nach der Marke sortieren
		fahrzeuge.OrderBy(e => e.Marke); //Originale Liste wird nicht verändert
		fahrzeuge.OrderByDescending(e => e.Marke); //Absteigend
		//fahrzeuge = fahrzeuge.OrderBy(e => e.Marke).ToList(); //Ergebnis zuweisen um originale Liste zu sortieren

		//Autos nach Marke und danach nach Geschwindigkeit sortieren
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV);
		fahrzeuge.OrderByDescending(e => e.Marke).ThenByDescending(e => e.MaxV);

		//Alle Marken in der Liste finden
		fahrzeuge.Select(e => e.Marke); //Liste von FahrzeugMarken
		fahrzeuge.Select(e => e.MaxV); //Liste von ints

		//Alle Marken in der Liste finden (aber nur einmal)
		fahrzeuge.Select(e => e.Marke).Distinct();

		//Fahrzeuge einzigartig machen anhand der Marke
		fahrzeuge.DistinctBy(e => e.Marke);

		//Fahren alle Fahrzeuge mindestens 200km/h?
		fahrzeuge.All(e => e.MaxV >= 200);

		//Fährt mindestens ein Fahrzeug schneller als 300km/h?
		fahrzeuge.Any(e => e.MaxV > 300);

		//Ist in der Liste mindestens ein Element vorhanden?
		fahrzeuge.Any(); //fahrzeuge.Count > 0

		//Zähle alle Audis
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.Audi);

		//Wie schnell fahren unsere Autos im Durchschnitt?
		fahrzeuge.Average(e => e.MaxV);
		fahrzeuge.Sum(e => e.MaxV);

		fahrzeuge.Min(e => e.MaxV); //Die kleinste Geschwindigkeit
		fahrzeuge.MinBy(e => e.MaxV); //Das langsamste Fahrzeug

		fahrzeuge.Max(e => e.MaxV);
		fahrzeuge.MaxBy(e => e.MaxV);

		//Fahrzeuge in X große Teile aufteilen (Rest kommt in den letzten Teil)
		fahrzeuge.Chunk(5);

		//Überspringe X Elemente und nimm X Elemente
		fahrzeuge.Skip(2).Take(5);

		//Liste umdrehen
		fahrzeuge.Reverse(); //Hier wird die Liste verändert, da diese Reverse Funktion zu List dazugehört
		fahrzeuge.Reverse<Fahrzeug>(); //Generic angeben um Linq Funktion zu benutzen

		//ID hinzufügen
		fahrzeuge.Zip(Enumerable.Range(0, fahrzeuge.Count));
		Enumerable.Range(0, fahrzeuge.Count).Zip(fahrzeuge);  //Liste von Tupel(int, Fahrzeug) -> unpraktisch
		Enumerable.Range(0, fahrzeuge.Count).Zip(fahrzeuge).ToDictionary(e => e.First, e => e.Second);

		//Äquivalent mit einer normalen foreach
		//Dictionary<int, Fahrzeug> zip = new();
		//IEnumerable<(int First, Fahrzeug Second)> zipped = Enumerable.Range(0, fahrzeuge.Count).Zip(fahrzeuge);
		//foreach ((int First, Fahrzeug Second) z in zipped)
		//	zip.Add(z.First, z.Second);

		//Fahrzeuge nach Marke gruppieren (Audi Gruppe, BMW Gruppe, VW Gruppe)
		fahrzeuge.GroupBy(e => e.Marke);

		//Grouping zu einem Dictionary konvertieren
		Dictionary<FahrzeugMarke, List<Fahrzeug>> grouped = fahrzeuge.GroupBy(e => e.Marke).ToDictionary(e => e.Key, e => e.ToList());

		//grouped[FahrzeugMarke.BMW] //Alle BMWs aus der Gruppierung holen

		//Maximalgeschwindigkeiten aufsummieren
		fahrzeuge.Aggregate(0, (agg, fzg) => agg + fzg.MaxV);

		//Die Liste printen
		Console.WriteLine(fahrzeuge.Aggregate(string.Empty, (agg, fzg) => agg + $"Das Fahrzeug hat die Marke {fzg.Marke} und kann maximal {fzg.MaxV}km/h fahren.\n"));

		//Selbiges wie oben nur mit StringBuilder (wesentlich performanter)
		Console.WriteLine(fahrzeuge.Aggregate(new StringBuilder(), (agg, fzg) => agg.AppendLine($"Das Fahrzeug hat die Marke {fzg.Marke} und kann maximal {fzg.MaxV}km/h fahren.")).ToString());
		#endregion

		#region Erweiterungsmethoden
		int x = 45387;
		x.Quersumme();

		Console.WriteLine(5279.Quersumme());

		fahrzeuge.Shuffle();
		#endregion
	}
}

public record Fahrzeug(int MaxV, FahrzeugMarke Marke);

public enum FahrzeugMarke { Audi, BMW, VW }