using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace Serialisierung;

internal class Program
{
	static void Main(string[] args)
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Ordner
		string filePath = Path.Combine(folderPath, "Test.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		//SystemJson();

		//NewtonsoftJson();

		//Xml();

		//Binary();
	}

	static void SystemJson()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Ordner
		string filePath = Path.Combine(folderPath, "Test.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		//JsonSerializerOptions options = new(); //Optionen beim Serialisieren/Deserialisieren angeben
		//options.ReferenceHandler = ReferenceHandler.IgnoreCycles; //Zirkelbezug verhindern
		//options.WriteIndented = true; //Json schön schreiben

		//string json = JsonSerializer.Serialize(fahrzeuge, options); //JsonSerializer: Klasse zum Unwandeln von Objekten <-> Json
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//Fahrzeug[] readFzg = JsonSerializer.Deserialize<Fahrzeug[]>(readJson, options); //Deserialisierung kann in einen beliebigen Listentypen passieren

		////////////////////////////////////

		////Json Element für Element durchgehen
		//JsonDocument doc = JsonDocument.Parse(json); //Json string zu einem JsonDocument konvertieren
		//foreach (JsonElement element in doc.RootElement.EnumerateArray()) //Json durchgehen
		//{
		//	Console.WriteLine((FahrzeugMarke) element.GetProperty("Marke").GetInt32()); //Einzelnes Element angreifen

		//	Fahrzeug fzg = element.Deserialize<Fahrzeug>(); //Kann direkt in ein Objekt konvertieren wenn ich das Objekt kenne
		//	Console.WriteLine(fzg.ID);
		//}
	}

	static void NewtonsoftJson()
	{
		//string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		//string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Ordner
		//string filePath = Path.Combine(folderPath, "Test.txt");

		//if (!Directory.Exists(folderPath))
		//	Directory.CreateDirectory(folderPath);

		//List<Fahrzeug> fahrzeuge = new()
		//{
		//	new Fahrzeug(0, 251, FahrzeugMarke.BMW),
		//	new Fahrzeug(1, 274, FahrzeugMarke.BMW),
		//	new Fahrzeug(2, 146, FahrzeugMarke.BMW),
		//	new Fahrzeug(3, 208, FahrzeugMarke.Audi),
		//	new Fahrzeug(4, 189, FahrzeugMarke.Audi),
		//	new Fahrzeug(5, 133, FahrzeugMarke.VW),
		//	new Fahrzeug(6, 253, FahrzeugMarke.VW),
		//	new Fahrzeug(7, 304, FahrzeugMarke.BMW),
		//	new Fahrzeug(8, 151, FahrzeugMarke.VW),
		//	new Fahrzeug(9, 250, FahrzeugMarke.VW),
		//	new Fahrzeug(10, 217, FahrzeugMarke.Audi),
		//	new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		//};

		//JsonSerializerSettings settings = new();
		//settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
		//settings.Formatting = Formatting.Indented;

		//string json = JsonConvert.SerializeObject(fahrzeuge, settings); //JsonConvert == JsonSerializer
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//Fahrzeug[] readFzg = JsonConvert.DeserializeObject<Fahrzeug[]>(readJson, settings);

		/////////////////////////////////////////

		//JToken doc = JToken.Parse(json);
		//foreach (JToken jt in doc)
		//{
		//	Console.WriteLine((FahrzeugMarke) jt["Marke"].Value<int>());

		//	Fahrzeug fzg = JsonConvert.DeserializeObject<Fahrzeug>(jt.ToString());
		//	Console.WriteLine(fzg.MaxV);
		//}
	}

	static void Xml()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Ordner
		string filePath = Path.Combine(folderPath, "Test.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		XmlSerializer xml = new XmlSerializer(fahrzeuge.GetType());
		using (StreamWriter sw = new StreamWriter(filePath))
		{
			xml.Serialize(sw.BaseStream, fahrzeuge); //Von StreamWriter den Stream nehmen
		}

		using (StreamReader sr = new StreamReader(filePath))
		{
			List<Fahrzeug> fzg = xml.Deserialize(sr.BaseStream) as List<Fahrzeug>; //Von StreamReader den Stream nehmen
		}

		XmlDocument doc = new XmlDocument();
		doc.LoadXml(File.ReadAllText(filePath));
		foreach (XmlNode node in doc.ChildNodes[1]) //Header überspringen
		{
			Console.WriteLine(node.ChildNodes.OfType<XmlNode>().First(e => e.Name == "Marke").InnerText);
		}
	}

	static void Binary()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test"); //Pfad zum Ordner
		string filePath = Path.Combine(folderPath, "Test.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		BinaryFormatter formatter = new BinaryFormatter();
		using (StreamWriter sw = new StreamWriter(filePath))
		{
			formatter.Serialize(sw.BaseStream, fahrzeuge); //Von StreamWriter den Stream nehmen
		}

		using (StreamReader sr = new StreamReader(filePath))
		{
			List<Fahrzeug> fzg = formatter.Deserialize(sr.BaseStream) as List<Fahrzeug>; //Von StreamReader den Stream nehmen
		}
	}
}

[Serializable]
public class Fahrzeug
{
	//[JsonIgnore] //Feld ignorieren (beide Frameworks)
	//[JsonPropertyName("Identifier")] //Feld umbenennen (System.Json)
	//[JsonProperty("Identifier")] //Newtonsoft.Json
	public int ID { get; set; }

	[XmlIgnore]
	[XmlElement("Maximalgeschwindigkeit")] //Name ändern
	[XmlAttribute] //Feld zu Attribut machen
	public int MaxV { get; set; }

	[field: NonSerialized] //BinaryIgnore
	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int iD, int maxV, FahrzeugMarke marke)
	{
		ID = iD;
		MaxV = maxV;
		Marke = marke;
	}

	public Fahrzeug()
	{
		//Für XmlSeralizer
	}
}

public enum FahrzeugMarke { Audi, BMW, VW }