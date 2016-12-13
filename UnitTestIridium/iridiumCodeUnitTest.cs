using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using IridiumCode;

namespace UnitTestIridium
{
    [TestClass]
    public class iridiumCodeUnitTest
    {
        [TestMethod]
        public void TestEncode()
        {
            bool[] b = new bool[] { false, false, true, false, false, true, true, true,
                                  false, true, false, true, true, true, false, false,
                                  true, false, false,true, true, true, false, true,
                                  false, false, true, true,false, false,false, false };
            BitArray BArray = new BitArray(b);
            byte[] sample= new byte[b.Length/8];

            byte[] result =iridiumCode.Encode("dude");
            BArray.CopyTo(sample, 0);

            CollectionAssert.AreEqual(sample, result);
        }
        [TestMethod]
        public void TestDecode()
        {
            string sample = "dude";

            string result = iridiumCode.Decode(iridiumCode.Encode("dude"));

            Assert.AreEqual(sample, result);
        }
    }
}
