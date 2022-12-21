using PluginBase;

namespace Plugin;

public class CalculatorPlugin : IPlugin
{
	public string Name => "Calculator Plugin";

	public string Description => "Ein einfacher Rechner";

	public string Version => "1.0";

	public string Author => "Lukas Kern";

	public double Addiere(double x, double y) => x + y;
}