using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Internal;
using LAB4;

namespace LAB4_TEST
{
    [TestFixture]
    public class DataFuncTests
    {
       DataFunc dataFunc = new DataFunc();

        [Test]
        public void TestGetByID1()
        {
            dataFunc = new DataFunc();
            var dtBefore = dataFunc.dt;
            dataFunc.GetByID(1);
            Assert.AreNotEqual(dtBefore, dataFunc.dt);
        }

        [Test]
        public void TestGetByID2()
        {
            dataFunc = new DataFunc();
            var dtBefore = dataFunc.dt;
            dataFunc.GetByID(99999);
            Assert.AreEqual(dtBefore, dataFunc.dt);
        }

        [Test]
        public void TestGetByName1()
        {
            dataFunc = new DataFunc();
            var dtBefore = dataFunc.dt;
            dataFunc.GetByName("kolya");
            Assert.AreNotEqual(dtBefore, dataFunc.dt);
        }

        [Test]
        public void TestGetByName2()
        {
            dataFunc = new DataFunc();
            var dtBefore = dataFunc.dt;
            dataFunc.GetByName("NonExistingName");
            Assert.AreEqual(dtBefore, dataFunc.dt);
        }

        [Test]
        public void TestAdd1()
        {
            dataFunc = new DataFunc();
            var dtBefore = dataFunc.dt;
            dataFunc.Add(1234, "TestName", "TestMessage");
            dataFunc.GetByID(1234);
            Assert.AreNotEqual(dtBefore, dataFunc.dt);
        }

        [Test]
        public void TestAdd2()
        {
            dataFunc = new DataFunc();
            var dtBefore = dataFunc.dt;
            dataFunc.Add(-1234, "TestName", "TestMessage");
            dataFunc.GetByID(-1234);
            Assert.AreEqual(dtBefore, dataFunc.dt);
        }

        [Test]
        public void TestUpdate1()
        {
            dataFunc = new DataFunc();
            dataFunc.Add(12345, "TestName", "OldMessage");
            dataFunc.Update(12345, "NewMessage");
            var row = (dataFunc.dt.Rows[0])["message"];
            Assert.AreEqual("NewMessage", row);
        }

        [Test]
        public void TestUpdate2()
        {
            dataFunc = new DataFunc();
            dataFunc.Add(-12345, "TestName", "OldMessage");
            dataFunc.Update(-12345, "NewMessage");
            var row = (dataFunc.dt.Rows[0])["message"];
            Assert.AreNotEqual("NewMessage", row);
        }

        [Test]
        public void TestDelete1()
        {
            dataFunc = new DataFunc();
            var dtBefore = dataFunc.dt;
            dataFunc.Add(777, "TestName", "TestMessage");
            dataFunc.Delete(777);
            var dtAfter = dataFunc.dt;
            Assert.AreSame(dtBefore, dtAfter);
        }

        [Test]
        public void TestDelete2()
        {
            dataFunc = new DataFunc();
            var dtBefore = dataFunc.dt;
            dataFunc.Add(999, "TestName", "TestMessage");
            dataFunc.Delete(-999);
            var dtAfter = dataFunc.dt;
            Assert.AreNotSame(dtBefore, dtAfter);
        }

    }
}
