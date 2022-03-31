using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace WordSearchApp;

public class WordFinder
{
    public const int ELEMENTS_TO_RETURN = 10;

    private IEnumerable<string> _matrix;
    private List<string> _reverseMatrix = new List<string>();

    public WordFinder(IEnumerable<string> matrix)
    {
        _matrix = matrix;

        for (int i = 0; i < _matrix.Count(); i++)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var line in matrix)
            {
                builder.Append(line[i]);
            }
            _reverseMatrix.Add(builder.ToString());
        }
    }

    public IEnumerable<string> Find(IEnumerable<string> wordStream)
    {
        wordStream = CleanEntryData(wordStream);

        Dictionary<string, int> resultWordsFounded = FindOcurrences(wordStream);

        return resultWordsFounded
            .OrderByDescending(x => x.Value)
            .Select(x => x.Key)
            .Take(ELEMENTS_TO_RETURN);
    }

    public Dictionary<string, int> FindOcurrences(IEnumerable<string> wordStream)
    {
        Dictionary<string, int> resultWordsFounded = new Dictionary<string, int>();

        //To find horizontally
        FindOcurrences(_matrix, wordStream, ref resultWordsFounded);
        //To find vertically
        FindOcurrences(_reverseMatrix, wordStream, ref resultWordsFounded);

        return resultWordsFounded;
    }

    #region Private methods
    private void FindOcurrences(IEnumerable<string> matrix, IEnumerable<string> wordStream, ref Dictionary<string, int> resultWordsFounded)
    {
        foreach (var line in matrix)
        {
            foreach (string wordToAnalize in wordStream)
            {
                //I've analyzed the possibility to iterate every item (character) from matrix and compare with entered wordstream, but this approach in a 64x64 matrix
                //it would iterate 4096 times against 128 times (twice 64 lines iterate).
                //Also I'm using IndexOf method from .Net framework that is optimized to find a substring in a string.
                int startIndex = 0;
                while (line.IndexOf(wordToAnalize, startIndex) != -1)
                {
                    startIndex = line.IndexOf(wordToAnalize, startIndex) + wordToAnalize.Length;

                    if (resultWordsFounded.ContainsKey(wordToAnalize))
                    {
                        resultWordsFounded[wordToAnalize] += 1;
                    }
                    else
                    {
                        resultWordsFounded.Add(wordToAnalize, 1);
                    }
                }
            }
        }
    }

    private static IEnumerable<string> CleanEntryData(IEnumerable<string> wordStream)
    {
        return wordStream
            .Distinct()
            .ToList();
    }
    #endregion Private methods
}
