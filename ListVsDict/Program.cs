using System;
using System.Collections.Generic;
using BenchmarkDotNet.Running;

namespace ListVsDict
{
	class Program
	{
		static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<ListVsDict>();

			//var s = new ListVsDict();
			//s.Setup();
			//s.FillAndSeekDict();

			//var dict = new Dictionary<int, KindaComplexObject>(3);
			//var dict2 = new HashSet<KindaComplexObject>(3);
			//var data = new KindaComplexObject[3];
			//
			//for (var i = 0; i < 3; i++)
			//	data[i] = KindaComplexObject.Create(i);
			//
			//for (int i = 0; i < 3; i++)
			//	dict.Add(i, data[i]);
			//
			//for (int i = 0; i < 3; i++)
			//	dict2.Add(data[i]);
		}
	}
}
