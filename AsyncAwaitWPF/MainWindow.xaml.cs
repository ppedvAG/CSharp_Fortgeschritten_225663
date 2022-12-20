using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncAwaitWPF;

public partial class MainWindow : Window
{
	public MainWindow() => InitializeComponent();

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Progress.Value = 0;
		for (int i = 0; i < 100; i++)
		{
			Thread.Sleep(25);
			Progress.Value++;
		} //Thread.Sleep blockiert den UI Thread
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		Task.Run(() => //UI Updates von Side Tasks sind nicht erlaubt
		{
			Dispatcher.Invoke(() => Progress.Value = 0); //Dispatcher.Invoke um UI Updates auf dem Main Thread auszuführen
			for (int i = 0; i < 100; i++)
			{
				Thread.Sleep(25);
				Dispatcher.Invoke(() => Progress.Value++);
			}
		});
	}

	private async void Button_Click_2(object sender, RoutedEventArgs e)
	{
		Progress.Value = 0;
		for (int i = 0; i < 100; i++)
		{
			await Task.Delay(25);
			Progress.Value++;
		}
	}

	private async void Button_Click_3(object sender, RoutedEventArgs e)
	{
		Progress.Value = 0;
		Progress.Maximum = 2;

		using HttpClient client = new();
		Task<HttpResponseMessage> respTask = client.GetAsync("http://www.gutenberg.org/files/54700/54700-0.txt");
		//UI Update: Text lädt...
		Text.Text = "Text lädt...";
		HttpResponseMessage resp = await respTask;

		Task<string> readTask = resp.Content.ReadAsStringAsync();
		//UI Update: Text wird ausgelesen...
		Progress.Value++;
		Text.Text = "Text wird ausgelesen";
		await Task.Delay(1000);
		string s = await readTask;

		Progress.Value++;
		Text.Text = s;
	}

	private async void Button_Click_4(object sender, RoutedEventArgs e)
	{
		List<int> ints = Enumerable.Range(0, 100).ToList();
		await Parallel.ForEachAsync(ints, (item, ct) => 
		{
			Console.WriteLine(item * 10);
			return ValueTask.CompletedTask;
		});

		IAsyncEnumerable<int> liste = null;
		await foreach (int i in liste)
		{

		}
	}
}
