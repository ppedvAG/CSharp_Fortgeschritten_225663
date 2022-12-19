namespace DelegatesEvents;

internal class Events
{
	//event: Statischer Punkt an den Methoden angehängt werden können
	static event EventHandler TestEvent;

	//EventHandler: Delegate das sender und args vorgibt (hauptsächlich in WPF, ASP und Xamarin zu finden)
	static event EventHandler<TestEventArgs> ArgsEvent;

	static void Main(string[] args)
	{
		TestEvent += Events_TestEvent; //Methode anhängen ohne new, Event kann nicht erstellt werden
		TestEvent(null, EventArgs.Empty);

		ArgsEvent += Events_ArgsEvent;
		ArgsEvent(null, new TestEventArgs() { Status = "Event aufgerufen" });
	}

	private static void Events_TestEvent(object sender, EventArgs e) => Console.WriteLine("TestEvent");

	private static void Events_ArgsEvent(object sender, TestEventArgs e)
	{
		Console.WriteLine(e.Status);
		e.Test();
	}
}

internal class TestEventArgs : EventArgs
{
	public string Status { get; set; }

	public void Test()
	{
		Console.WriteLine(Status);
	}
}