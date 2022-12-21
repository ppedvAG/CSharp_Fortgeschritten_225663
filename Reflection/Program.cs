using System.Reflection;

namespace Reflection;

internal class Program
{
	static void Main(string[] args)
	{
		Program p = new Program();
		Type pt = p.GetType(); //Typ holen mit GetType() über Objekt
		Type t = typeof(Program); //Typ holen durch typeof(<Klassenname>)

		object o = Activator.CreateInstance(pt); //Objekt über Typ erstellen

		pt.GetMethods(); //Alle Methoden anschauen
		pt.GetMethod("Test").Invoke(o, null); //Methode über Reflection aufrufen
		pt.GetMethod("Test2").Invoke(o, new[] { "Zwei Text" }); //Methode über Reflection aufrufen

		pt.GetField("EineZahl").SetValue(o, 5); //Feld über Reflection setzen
		Console.WriteLine(pt.GetField("EineZahl").GetValue(o));

		object o2 = Activator.CreateInstance("Reflection", "Reflection.Program"); //Objekt nur über strings erstellen

		Assembly assembly = Assembly.GetExecutingAssembly(); //Informationen über das derzeitige Projekt erhalten

		List<TypeInfo> types = assembly.DefinedTypes.ToList(); //Alle Typen aus einem Assembly holen

		List<Type> defTypes = types.Select(t => t.AsType()).ToList(); //TypeInfo -> Type durch Select

		string path = @"C:\Users\lk3\source\repos\CSharp_Fortgeschritten_2022_12_19\DelegatesEvents\bin\Debug\net6.0\DelegatesEvents.dll";

		Assembly loaded = Assembly.LoadFrom(path); //DLL laden

		Type compType = loaded.GetType("DelegatesEvents.Component"); //Typ der Komponente finden

		object comp = Activator.CreateInstance(compType);
		compType.GetEvent("ProcessCompleted").AddEventHandler(comp, () => Console.WriteLine("Reflection fertig"));
		compType.GetEvent("Progress").AddEventHandler(comp, (int i) => Console.WriteLine($"Reflection Fortschritt: {i}"));
		compType.GetMethod("StartProcess").Invoke(comp, null);
	}

	public int EineZahl;

	public void Test() => Console.WriteLine("Ein Test");

	public void Test2(string s) => Console.WriteLine(s);
}