using System.Collections.Generic;

namespace AssignmentProject.model
{
    public class LottoResult
    {
        public List<Lotto> Results { get; }
        
        public LottoResult(List<Lotto> results)
        {
            Results = results;
        }

    }
}