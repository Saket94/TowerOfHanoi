using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TowerOfHanoi;

namespace TowerOfHanoiTestCases
{
    [TestClass]
    public class LoggerTest
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
        [DeploymentItem("TowerOfHanoiTestCases\\TestDataFiles\\LogTestData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "|DataDirectory|\\TestDataFiles\\LogTestData.xml",
                   "Row",
                    DataAccessMethod.Sequential)]
        public void TestCreateLog()
        {
            Logger logger = new Logger();
            string errMsg = ((string)TestContext.DataRow["Message"]);
            string errType =((string)TestContext.DataRow["Type"]);
            string errTrace =((string)TestContext.DataRow["operation"]);
            Assert.IsTrue(logger.CreateLog(errMsg, errType, errTrace) == true);
        }
    }
}
