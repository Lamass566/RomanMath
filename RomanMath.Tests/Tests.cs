using NUnit.Framework;
using RomanMath.Impl;
using System.Data;

namespace RomanMath.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			var result = Service.Evaluate("IV+II-V");
			DataTable dt = new DataTable();
			var v = dt.Compute(result, "");
			Assert.AreEqual(1, v);
		}
	}
}