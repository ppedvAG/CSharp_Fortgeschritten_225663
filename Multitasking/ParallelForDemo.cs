﻿using System.Diagnostics;

namespace Multitasking;

internal class ParallelForDemo
{
	static void Main(string[] args)
	{
		int[] durchgänge = { 1000, 10000, 50000, 100000, 250000, 500000, 1000000, 5000000, 10000000, 100000000 };

		foreach (int i in durchgänge)
		{
			Stopwatch sw = Stopwatch.StartNew();
			RegularFor(i);
			sw.Stop();
			Console.WriteLine($"For Durchgänge {i}: {sw.ElapsedMilliseconds}");

			Stopwatch sw2 = Stopwatch.StartNew();
			ParallelFor(i);
			sw2.Stop();
			Console.WriteLine($"Parallel For Durchgänge {i}: {sw2.ElapsedMilliseconds}");
		}

		/*
			For Durchgänge 1000: 2
			Parallel For Durchgänge 1000: 99
			For Durchgänge 10000: 4
			Parallel For Durchgänge 10000: 16
			For Durchgänge 50000: 29
			Parallel For Durchgänge 50000: 39
			For Durchgänge 100000: 44
			Parallel For Durchgänge 100000: 75
			For Durchgänge 250000: 125
			Parallel For Durchgänge 250000: 115
			For Durchgänge 500000: 189
			Parallel For Durchgänge 500000: 81
			For Durchgänge 1000000: 547
			Parallel For Durchgänge 1000000: 227
			For Durchgänge 5000000: 3451
			Parallel For Durchgänge 5000000: 559
			For Durchgänge 10000000: 4400
			Parallel For Durchgänge 10000000: 1261
			For Durchgänge 100000000: 29205
			Parallel For Durchgänge 100000000: 13400
		*/
	}

	static void RegularFor(int iterations)
	{
		double[] erg = new double[iterations];
		for (int i = 0; i < iterations; i++)
			erg[i] = (Math.Pow(i, 0.333333333333) * Math.Sin(i + 2) / Math.Exp(i) + Math.Log(i + 1)) * Math.Sqrt(i + 100);
	}

	static void ParallelFor(int iterations)
	{
		double[] erg = new double[iterations];
		//int i = 0; i < iterations; i++
		Parallel.For(0, iterations, i => erg[i] = (Math.Pow(i, 0.333333333333) * Math.Sin(i + 2) / Math.Exp(i) + Math.Log(i + 1)) * Math.Sqrt(i + 100));
	}
}
