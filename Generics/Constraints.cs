﻿namespace Generics;

internal class Constraints
{
	public Constraints(int x) { } //Parameterloser Konstruktor wird überschrieben

	public Constraints() { }

	static void Main(string[] args)
	{
		DataStore4<Constraints> d;
		DataStore5<DayOfWeek> d1;
	}

	public class DataStore1<T> where T : class { } //T muss ein Referenztyp sein

	public class DataStore2<T> where T : struct { } //T muss ein Wertetyp sein

	public class DataStore3<T> where T : Program { } //T muss die Klasse selber oder eine Unterklasse sein

	public class DataStore4<T> where T : new() { } //T muss einen Standardkonstruktor

	public class DataStore5<T> where T : Enum { } //Nur Enums (keine Enumwerte)

	public class DataStore6<T> where T : Delegate { } //Nur Delegates (Action, Func, eigenes Delegate, ...)

	public class DataStore7<T> where T : unmanaged { } //Nur Basisdatentypen und ein paar weitere Typen
	//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/unmanaged-types

	public class DataStore8<T> where T : class, new() { } //Mehrere Constraints auf ein Generic

	public class DataStore9<T1, T2> //Mehrere Constraints auf mehrere Generics
		where T1 : class
		where T2 : struct
	{ }

	public class DataStore10<T1, T2, T3, T4, T5, T6> { } //Beliebig viele Generics möglich

	public void Test<T>() where T : unmanaged //Constrains bei Methode hinzufügen
	{

	}
}