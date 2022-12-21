using System.Collections;

Wagon w1 = new();
Wagon w2 = new();

Console.WriteLine(w1 == w2);

Zug z = new();
z++;
z++;
z++;
z++;

z += w1;
z += w2;

foreach (Wagon w in z)
{

}

//z[3] = w2;
//Console.WriteLine(z["Rot"]);

var x = z.wagons.Select(e => new { e.AnzSitze, HC = e.GetHashCode() });
Console.WriteLine(x.First().HC);

System.Timers.Timer timer = new();
timer.Interval = 1000;
timer.Elapsed += (sender, e) => Console.WriteLine("Intervall vergangen");
timer.Start();

Console.ReadKey();


public class Zug : IEnumerable
{
	public List<Wagon> wagons = new();

	public Wagon this[int index]
	{
		get => wagons[index];
		set => wagons[index] = value;
	}

	public Wagon this[string farbe]
	{
		get => wagons.First(e => e.Farbe == farbe);
	}

	public static Zug operator ++(Zug w)
	{
		w.wagons.Add(new Wagon());
		return w;
	}

	public static Zug operator +(Zug z, Wagon w)
	{
		z.wagons.Add(w);
		return z;
	}

	public IEnumerator GetEnumerator()
	{
		return wagons.GetEnumerator();
	}
}

public class Wagon
{
	public int AnzSitze { get; set; }

	public string Farbe { get; set; }

	public static bool operator ==(Wagon a, Wagon b)
	{
		return a.AnzSitze == b.AnzSitze && a.Farbe == b.Farbe;
	}

	public static bool operator !=(Wagon a, Wagon b)
	{
		return !(a == b);
	}
}