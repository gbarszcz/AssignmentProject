using System;
using System.IO;
using System.Linq;
using AssignmentProject.model;

namespace AssignmentProject.parser
{
    public class LottoFileParser : IFileParser<LottoResult>
    {
        public LottoResult Parse(string filePath)
        {
            var lottoResults = File.ReadAllLines(filePath);
            var list = lottoResults.Select(ParseResult).ToList();
            return new LottoResult(list);
        }

        private static Lotto ParseResult(string result)
        {
            var elements = result.Split(' ');
            var date = DateTime.Parse(elements[1]);
            var numbers = elements[2].Split(',').Select(int.Parse).ToList();
            return new Lotto(date, numbers);
        }
    }
}