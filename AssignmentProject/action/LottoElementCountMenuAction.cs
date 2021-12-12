using System.Collections.Generic;
using System.Linq;
using AssignmentProject.model;

namespace AssignmentProject.action
{
    public class LottoElementCountMenuAction : IMenuAction<LottoResult>
    {
        public IEnumerable<string> Result(LottoResult elements)
        {
            var count = new int[50];
            foreach (var number in elements.Results.SelectMany(element => element.BallotNumbers))
            {
                count[number]++;
            }

            var output = new string[49];
            for (var i = 0; i < count.Length - 1; i++)
            {
                output[i] = $"{i + 1}. {count[i + 1]}";
            }
            return output;
        }
    }
}