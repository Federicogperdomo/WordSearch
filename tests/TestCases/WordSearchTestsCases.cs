using NUnit.Framework;
using System.Collections.Generic;

namespace WordSearch.Application.Test.TestCases;

public static class WordSearchTestsCases
{
    public static IEnumerable<TestCaseData> FindOcurrences_TestCases()
    {
        return new List<TestCaseData>
        {
            new TestCaseData
            (
                InitializeMatrix6x6(),
                new List<string>() { "COLD", "WIND" },
                new Dictionary<string, int>() { { "COLD", 2 }}
            ),

            new TestCaseData
            (
                InitializeMatrix6x6(),
                new List<string>() { "COLD", "SNOW", "WIND" },
                new Dictionary<string, int>() { { "COLD", 2 }, { "SNOW", 1 } }
            ),

            new TestCaseData
            (
                InitializeMatrix6x6(),
                new List<string>() { "RAIN", "SNOW", "WIND" },
                new Dictionary<string, int>() { { "SNOW", 1 } }
            ),

            new TestCaseData
            (
                InitializeMatrix6x6(),
                new List<string>() { "RAIN", "THUNDER", "WIND" },
                new Dictionary<string, int>() {  }
            ),

            new TestCaseData
            (
                InitializeMatrix10x10(),
                new List<string>() { "COLD", "SNOW", "WIND" },
                new Dictionary<string, int>(){ { "COLD", 3 }, { "SNOW", 2 } }
            ),
        };
    }

    public static IEnumerable<TestCaseData> Find_TestCases()
    {
        return new List<TestCaseData>
        {
            new TestCaseData
            (
                InitializeMatrix6x6(),
                new List<string>() { "COLD", "WIND" },
                new List<string>() { "COLD"}
            ),

            new TestCaseData
            (
                InitializeMatrix6x6(),
                new List<string>() { "COLD", "SNOW", "WIND" },
                new List<string>() { "COLD", "SNOW" }
            ),

            new TestCaseData
            (
                InitializeMatrix6x6(),
                new List<string>() { "RAIN", "SNOW", "WIND" },
                new List<string>() { "SNOW" }
            ),

            new TestCaseData
            (
                InitializeMatrix6x6(),
                new List<string>() { "RAIN", "THUNDER", "WIND" },
                new List<string>() {  }
            ),

            new TestCaseData
            (
                InitializeMatrix6x6(),
                new List<string>() { "COLD", "SNOW", "SNOW", "SNOW", "SNOW", "WIND" },
                new List<string>() { "COLD", "SNOW" }
            ),

            new TestCaseData
            (
                InitializeMatrix10x10(),
                new List<string>() { "COLD", "SNOW", "WIND" },
                new List<string>(){ "COLD", "SNOW" }
            ),
        };
    }

    #region Private methods
    private static IEnumerable<string> InitializeMatrix6x6()
    {
        //COLD=2. SNOW=1
        return new List<string>() {
            "ABCDET",
            "SCOLDD",
            "NXXXXX",
            "OCCOLD",
            "WXXXXX",
            "ZZZZZZ"
        };
    }

    private static IEnumerable<string> InitializeMatrix10x10()
    {
        //COLD=3. SNOW=2
        return new List<string>() {
            "ABCDETAAAA",
            "SCOLDDAAAA",
            "NXXXXXAAAA",
            "OCCOLDAAAA",
            "WXOXXSNOWA",
            "ZZLZZZAAAA",
            "ZZDZZZAAAA",
            "ZZZZZZAAAA",
            "ZZZZZZAAAA",
            "ZZZZZZAAAA"
        };
    }
    #endregion Private methods

    //probar casos donde encuentre 11 palabras de la lista y devuelva solo 10
    //aca hago solo que pasen.. ver si conviene hacer q no pasen test tmb..de falla. Creo que no.
    //C para encontrar dos colds.. horiz y ver si encuentra ambos





}
