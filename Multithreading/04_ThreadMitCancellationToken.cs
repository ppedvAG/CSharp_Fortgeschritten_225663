namespace Multithreading;

internal class _04_ThreadMitCancellationToken
{
	static void Main(string[] args)
	{
		CancellationTokenSource cts = new(); //Sender
		CancellationToken token = cts.Token; //Empfänger

		ParameterizedThreadStart pt = new(Run);
		Thread t = new Thread(pt);
		t.Start(token); //Hier Token weitergeben

		Thread.Sleep(1000);

		cts.Cancel(); //Canceled alle Token
	}

	static void Run(object o)
	{
		try
		{
			if (o is CancellationToken ct)
			{
				for (int i = 0; i < 10; i++)
				{
					Thread.Sleep(200);
					Console.WriteLine($"Side Thread: {i}");

					if (ct.IsCancellationRequested)
						ct.ThrowIfCancellationRequested(); //OperationCanceledException werfen um Thread zu beenden
				}
			}
		}
		catch (OperationCanceledException e)
		{
			Console.WriteLine("Thread wurde abgebrochen");
		}
	}
}
