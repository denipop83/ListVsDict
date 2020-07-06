using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace ListVsDict
{
	[RPlotExporter]
	public class ListVsDict
	{
		[Params(50, 100)]
		public int N;

		private KindaComplexObject[] data;
		List<KindaComplexObject> list1;
		Dictionary<int, KindaComplexObject> dict1;


		[GlobalSetup]
		public void Setup()
		{
			data = new KindaComplexObject[N];
			list1 = new List<KindaComplexObject>(N);
			dict1 = new Dictionary<int, KindaComplexObject>(N);

			for (var i = 0; i < N; i++)
			{
				var kindaComplexObject = KindaComplexObject.Create(i);	
				data[i] = kindaComplexObject;
			}
		}

		[Benchmark]
		public void FillAndSeekList()
		{
			for (var i = 0; i < N; i++)
				list1.Add(data[i]);

			foreach (var obj in data)
			{
				var seek = list1.FirstOrDefault(i => i.Id == obj.Id);
			}
		}

		[Benchmark]
		public void FillAndSeekDict()
		{
			dict1 = data.ToDictionary(d => d.Id);

			foreach (var obj in data)
			{
				var seek = dict1[obj.Id];
			}
		}


		[Benchmark]
		public void FillKnownSizeList()
		{
			var list = new List<KindaComplexObject>(N);
		
			foreach (var kindaComplexObject in data)
				list.Add(kindaComplexObject);
		}
		
		[Benchmark]
		public void FillKnownSizeDict()
		{
			var hashset = new HashSet<KindaComplexObject>(N);
			foreach (var kindaComplexObject in data)
				hashset.Add(kindaComplexObject);
		}
	}

	public class KindaComplexObject
	{
		public int Id { get; private set; }
		public int Rating { get; private set; }
		public string Description { get; private set; }
		public InternalInfo Info { get; private set; }

		public class InternalInfo
		{
			public string MoreDescription { get; internal set; }
			public int InternalId { get; internal set; }
		}

		private KindaComplexObject(){}

		public static KindaComplexObject Create(int id) =>
			new KindaComplexObject()
			{
				Description = $"desc_{id}",
				Id = id,
				Rating = id,
				Info = new InternalInfo()
				{
					InternalId = id,
					MoreDescription = $"more_{id}"
				}
			};

		public override int GetHashCode() => Id;
	}
}
