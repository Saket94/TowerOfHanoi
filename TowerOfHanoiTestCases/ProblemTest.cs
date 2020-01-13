using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TowerOfHanoi;

namespace TowerOfHanoiTestCases
{
    [TestClass]
    public class ProblemTest
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
        [DeploymentItem("TowerOfHanoiTestCases\\TestDataFiles\\ProblemTestData.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "|DataDirectory|\\TestDataFiles\\ProblemTestData.xml",
                   "Row",
                    DataAccessMethod.Sequential)]
        public void TestSolve()
        {
            int n=0, k=0, a=0, b=0, c =0;

            if (string.IsNullOrEmpty((string)TestContext.DataRow["n"]) || string.IsNullOrEmpty((string)TestContext.DataRow["k"]) || string.IsNullOrEmpty((string)TestContext.DataRow["a"]) || string.IsNullOrEmpty((string)TestContext.DataRow["b"]) || string.IsNullOrEmpty((string)TestContext.DataRow["c"]))
            {
                return;
            }
            
            bool isNumeric = int.TryParse((string)TestContext.DataRow["n"], out n);

            if(isNumeric)
                isNumeric = int.TryParse((string)TestContext.DataRow["k"], out k);
            if (isNumeric)
                isNumeric = int.TryParse((string)TestContext.DataRow["a"], out a);
            if (isNumeric)
                isNumeric = int.TryParse((string)TestContext.DataRow["b"], out b);
            if (isNumeric)
                isNumeric = int.TryParse((string)TestContext.DataRow["c"], out c);
            if (isNumeric)
            {
                Problem problem = new Problem();
                problem.solve(n, k, a, b, c);

                // Assert
                Assert.IsTrue(problem.getExpectedNumber(2, 5, 1, 3, 5) == 60);
                Assert.IsTrue(problem.getExpectedNumber(3, 20, 4, 9, 17) == 2358);
            }
        }

    }
}
