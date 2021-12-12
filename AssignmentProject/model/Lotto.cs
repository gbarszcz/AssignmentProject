using System;
using System.Collections.Generic;

namespace AssignmentProject.model
{
    public class Lotto
    {
        public const int MaxBallotNumber = 50;
        private DateTime DateTime { get; }
        public List<int> BallotNumbers { get; }

        public Lotto(DateTime dateTime, List<int> ballotNumbers)
        {
            DateTime = dateTime;
            BallotNumbers = ballotNumbers;
        }

    }
}