using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task3.Tests
{
    [TestFixture]
    public class WordFrequencyCounterTest
    {
        [Test]
        public void WordCounter()
        {
            using (var fs = new FileStream("test.txt", FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(fs))
            {
                writer.WriteLine("Our, word frequency counter allows you to count the frequency usage of each word in your text.");
                writer.WriteLine("Paste or type in your text below, and click submit.");
            }
            var actualResult = WordFrequencyCounter.Counter("test.txt");
            Assert.AreEqual(22, actualResult.Count);
        }
    }
}
