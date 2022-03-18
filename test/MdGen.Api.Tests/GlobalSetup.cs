using NUnit.Framework;
using System.Reflection;
using System.Configuration;

namespace MdGen.Api.Tests;

[SetUpFixture]
public class GlobalSetup
{
    [OneTimeSetUp]
    public void SetupConfigBeforeTests()
    {
        string configFile = $"{Assembly.GetExecutingAssembly().Location}.config";
        string outputConfigFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath;
        File.Copy(configFile, outputConfigFile, true);
    }
}
