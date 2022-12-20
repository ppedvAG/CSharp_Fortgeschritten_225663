namespace Multitasking;

internal class _05_ContinueWith
{
	static void Main(string[] args)
	{
		Task<double> t1 = Task.Run(() => 
		{
			Thread.Sleep(1000);
			return Math.Pow(4, 23);
		});
		t1.ContinueWith(vorherigerTask => Console.WriteLine(vorherigerTask.Result)); //Tasks verketten, Code wird ausgeführt wenn der vorherige Task fertig ist, vorheriger Task in Variable zu finden
		t1.ContinueWith(t => Console.WriteLine(t.Result * 2)); //Dieser Task wird gleichzeitig mit dem originalen Task ausgeführt
		t1.ContinueWith(t => Console.WriteLine(t.Result * 4), TaskContinuationOptions.OnlyOnFaulted); //Über TaskContinuationOptions einen Baum bauen von Verkettungen (nur bei Exception)
		t1.ContinueWith(t => Console.WriteLine(t.Result * 8), TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.NotOnFaulted); //nur wenn der Task fertig ist und keine Exception aufgetreten ist

		Console.ReadKey();
	}
}
