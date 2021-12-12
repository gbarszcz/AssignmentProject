using System.Collections.Generic;
using System.Linq;
using AssignmentProject.comparer;
using AssignmentProject.model;

namespace AssignmentProject.action
{
    public class LottoBallotsRepeatedMenuAction : IMenuAction<LottoResult>
    {
        public IEnumerable<string> Result(LottoResult elements)
        {
            var countRepetitions = elements.Results
                .Select(x => x.BallotNumbers)
                .GroupBy(x => x, new IntListComparer())
                .Count(x => x.Count() > 1);
            return new[] {countRepetitions > 0 ? "Tak" : "Nie"};
        }
    }
}