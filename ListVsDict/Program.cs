using System;
using System.Collections.Generic;
using BenchmarkDotNet.Running;

namespace ListVsDict
{
	class Program
	{
		static void Main(string[] args)
		{
			//you MUST run it under release build
			var summary = BenchmarkRunner.Run<ListVsDict>();
		}
	}
}
