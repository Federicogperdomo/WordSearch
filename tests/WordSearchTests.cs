using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using WordSearch.Application.Test.TestCases;
using WordSearchApp;
using Moq.AutoMock;
using NUnit.Framework;
using System.Collections.Generic;

namespace WordSearch.Application.Test;

[TestFixture]
public class WordSearchTests
{
    //private AutoMocker _autoMocker;

    [SetUp]
    public void SetUp()
    {
        //_autoMocker = new AutoMocker();
    }

    [TestCaseSource(typeof(WordSearchTestsCases), nameof(WordSearchTestsCases.FindOcurrences_TestCases))]
    public async Task FindOcurrencesTest(IEnumerable<string> matrix, IEnumerable<string> wordStream, Dictionary<string, int> wordsFounded)
    {
        //Arrange

        //Act
        Dictionary<string, int> result = new WordFinder(matrix).FindOcurrences(wordStream);

        //Assert
        result.Should().BeEquivalentTo(wordsFounded);
    }

    [TestCaseSource(typeof(WordSearchTestsCases), nameof(WordSearchTestsCases.Find_TestCases))]
    public async Task FindTest(IEnumerable<string> matrix, IEnumerable<string> wordStream, IEnumerable<string> wordsFounded)
    {
        //Arrange

        //Act
        IEnumerable<string> result = new WordFinder(matrix).Find(wordStream);

        //Assert
        result.Should().BeEquivalentTo(wordsFounded);
    }

}