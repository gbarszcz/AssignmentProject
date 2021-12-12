using System.Collections.Generic;
using System.Linq;
using AssignmentProject.model;

namespace AssignmentProject.action
{
    public class LottoMaxOccurrencesMenuAction : IMenuAction<LottoResult>
    {
        private readonly int _occurrencesCount;

        public LottoMaxOccurrencesMenuAction(int occurrencesCount)
        {
            _occurrencesCount = occurrencesCount;
        }

        public IEnumerable<string> Result(LottoResult elements)
        {
            var countBallotNumbersOccurrences = new int[Lotto.MaxBallotNumber];
            foreach (var number in elements.Results.SelectMany(element => element.BallotNumbers))
            {
                countBallotNumbersOccurrences[number]++;
            }

            var sortedBallotOccurrences = countBallotNumbersOccurrences
                .Skip(1)
                .Select((n, i) => new {index = i + 1, value = n})
                .OrderByDescending(item => item.value)
                .Take(_occurrencesCount)
                .Select(n  => n.index + ". " + n.value);
            
            return sortedBallotOccurrences;
        }
    }
}