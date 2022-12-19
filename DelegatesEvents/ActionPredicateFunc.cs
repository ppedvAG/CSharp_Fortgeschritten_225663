namespace DelegatesEvents;

internal class ActionPredicateFunc
{
	static void Main(string[] args)
	{
		Action<int, int> action = Addiere; //Action: Methode mit void als Rückgabewert und bis zu 16 Parametern
		action += Subtrahiere; //Methode anhängen wie bei Delegate
		action(6, 2); //Ausführen wie bei Delegate
		action?.Invoke(4, 5); //Ausführen mit Null-Check

		DoAction(4, 7, Addiere); //Das Verhalten der Methode anpassen über den Action Parameter
		DoAction(4, 7, Subtrahiere);
		DoAction(4, 7, action);

		Predicate<int> pred = CheckForZero; //Predicate: Methode mit bool als Rückgabewert und genau einem Parameter
		pred += CheckForOne;
		bool b = pred(3); //Ergebnis der letzten Methode kommt aus Predicate heraus
		bool? b2 = pred?.Invoke(0); //Drei mögliche Ergebnisse: true, false oder null (wenn das Predicate null ist)
		bool b3 = pred?.Invoke(0) == true; //false oder null -> false, sonst true

		DoPredicate(4, CheckForZero);
		DoPredicate(4, CheckForOne);
		DoPredicate(4, pred);

		Func<int, int, double> func = Multipliziere; //Func: Methode mit Rückgabewert (letztes Generic ist der Rückgabetyp), bis zu 16 Parameter
		func += Dividiere;
		double d = func(5, 9); //Das letzte Ergebnis
		double? d2 = func?.Invoke(4, 9);

		DoFunc(5, 9, Multipliziere);
		DoFunc(5, 9, Dividiere);
		DoFunc(4, 8, func);

		func += delegate (int x, int y) { return x + y; }; //Anonyme Methode

		func += (int x, int y) => { return x + y; }; //Kürzere Form

		func += (x, y) => { return x - y; };

		func += (x, y) => (double) x / y; //Kürzeste, häufigste Form

		DoAction(4, 7, (x, y) => Console.WriteLine(x % y)); //Hier kein Rückgabewert möglich -> cw hat keinen Rückgabewert
		DoPredicate(3, x => x % 2 == 0); //Ist einer gerade als Bedingung (Lambda Expression muss einen bool zurückgeben)
		DoFunc(3, 6, (x, y) => (double) x % y); //Anonyme Methode bei Func mit double als Ergebnis
	}

	#region Action
	static void Addiere(int z1, int z2) => Console.WriteLine(z1 + z2);

	static void Subtrahiere(int z1, int z2) => Console.WriteLine(z1 - z2);

	static void DoAction(int z1, int z2, Action<int, int> action) => action?.Invoke(z1, z2);
	#endregion

	#region Predicate
	private static bool CheckForZero(int obj) => obj == 0;

	private static bool CheckForOne(int obj) => obj == 1;

	private static bool DoPredicate(int x, Predicate<int> predicate) => predicate?.Invoke(x) == true;
	#endregion

	#region Func
	private static double Multipliziere(int arg1, int arg2) => arg1 * arg2;

	private static double Dividiere(int arg1, int arg2) => (double) arg1 / arg2;

	private static double DoFunc(int x, int y, Func<int, int, double> func) => func(x, y);
	#endregion
}
