using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void TestMethod1()
        //{
        //    readJSON.Program.ExtractFile("");
        //}

        [TestMethod]
        public void TestMethod2()
        {
            //pass the filename
            // to get the location the assembly is executing from
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //to get the directory path of the JSON file:
            var directory = System.IO.Path.GetDirectoryName(path);
            //build the complete JSON file path
            string fileName = directory + "\\menu.json";

            readJSON.Program.ExtractFile(fileName);
        }
    }
}
