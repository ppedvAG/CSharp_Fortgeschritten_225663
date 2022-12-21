using PluginBase;
using System.Reflection;

namespace PluginClient;

internal class Program
{
	static void Main(string[] args)
	{
		string path = @"C:\Users\lk3\source\repos\CSharp_Fortgeschritten_2022_12_19\Plugin\bin\Debug\net6.0\Plugin.dll";
		Assembly loaded = Assembly.LoadFrom(path);
		Type t = loaded.DefinedTypes.First(e => e.GetInterface("IPlugin") != null);
		IPlugin plugin = Activator.CreateInstance(t) as IPlugin;

		Console.WriteLine($"Name: {plugin.Name}");
		Console.WriteLine($"Beschreibung: {plugin.Description}");
		Console.WriteLine($"Autor: {plugin.Author}");
		Console.WriteLine($"Version: {plugin.Version}");
		Console.WriteLine();
		Console.WriteLine("Wähle eine Methode aus: ");
		for (int i = 0; i < t.GetMethods().Length; i++)
		{
			Console.WriteLine($"{i + 1}: {t.GetMethods()[i]}");
		}

		int auswahl = int.Parse(Console.ReadLine());
		Console.WriteLine(t.GetMethods()[auswahl - 1].Invoke(plugin, new object[] {5.5, 2.2 }));
	}
}