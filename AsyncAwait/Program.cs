using System.Diagnostics;

namespace AsyncAwait;

internal class Program
{
	static async Task Main(string[] args)
	{
		//Stopwatch sw = Stopwatch.StartNew(); //Sequentiell, ineffizient
		//Toast();
		//Geschirr();
		//Kaffee();
		//sw.Stop();
		//Console.WriteLine(sw.ElapsedMilliseconds); //7s

		//Stopwatch sw2 = Stopwatch.StartNew();
		//Task.Run(Toast);
		//Task.Run(Geschirr);
		//Task.Run(Kaffee);
		//sw2.Stop();
		//Console.WriteLine(sw2.ElapsedMilliseconds); //24ms, Main Thread läuft weiter
		//Console.ReadKey();

		//Stopwatch sw3 = Stopwatch.StartNew();
		//ToastTaskAsync(); //Methoden werden als Tasks ausgeführt weil sie async sind
		//GeschirrTaskAsync();
		//KaffeeTaskAsync();
		//sw3.Stop();
		//Console.WriteLine(sw3.ElapsedMilliseconds); //23ms, Main Thread läuft weiter

		Stopwatch sw4 = Stopwatch.StartNew();
		Task<Toast> toastTask = ToastAsync();
		Task<Tasse> tasseTask = GeschirrAsync();
		Tasse tasse = await tasseTask; //Alternative zu t.Result (die nicht blockiert)
		Task<Kaffee> kaffeeTask = KaffeeAsync(tasse);
		Kaffee k = await kaffeeTask; //Warte hier bis der Kaffee fertig ist (alles läuft im Hintergrund weiter)
		Toast t = await toastTask;
		sw4.Stop();
		Console.WriteLine(sw4.ElapsedMilliseconds); //4s

		//Kurzform
		Tasse t3 = await GeschirrAsync();
		Kaffee k2 = await KaffeeAsync(t3);
		Toast t2 = await ToastAsync();
	}

	static void Toast()
	{
		Thread.Sleep(4000);
		Console.WriteLine("Toast fertig");
	}

	static void Geschirr()
	{
		Thread.Sleep(1500);
		Console.WriteLine("Geschirr hergerrichtet");
	}

	static void Kaffee()
	{
		Thread.Sleep(1500);
		Console.WriteLine("Kaffee fertig");
	}

	static async void ToastTaskAsync()
	{
		await Task.Delay(4000);
		Console.WriteLine("Toast fertig");
	}

	static async void GeschirrTaskAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Geschirr hergerrichtet");
	}

	static async void KaffeeTaskAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Kaffee fertig");
	}

	static async Task<Toast> ToastAsync()
	{
		await Task.Delay(4000);
		Console.WriteLine("Toast fertig");
		return new Toast();
	}

	static async Task<Tasse> GeschirrAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Geschirr hergerrichtet");
		return new Tasse();
	}

	static async Task<Kaffee> KaffeeAsync(Tasse t)
	{
		await Task.Delay(1500);
		Console.WriteLine("Kaffee fertig");
		return new Kaffee();
	}
}

public class Toast { }

public class Tasse { }

public class Kaffee { }