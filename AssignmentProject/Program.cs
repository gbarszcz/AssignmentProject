using System;
using System.Collections.Generic;
using AssignmentProject.action;
using AssignmentProject.drawers;
using AssignmentProject.drawers.inputs;
using AssignmentProject.model;
using AssignmentProject.parser;

namespace AssignmentProject
{
    internal static class Program
    {
        private static readonly List<MenuElement<LottoResult>> MenuElements = new List<MenuElement<LottoResult>>
        {
            new MenuElement<LottoResult>("Ilość wystąpień każdej z liczb", new LottoElementCountMenuAction()),
            new MenuElement<LottoResult>("Która liczba została wylosowana najwięcej razy?", new LottoMaxOccurrencesMenuAction(1)),
            new MenuElement<LottoResult>("Sześć liczb, które zostały wylosowane najmniej razy?", new LottoMinOccurrencesMenuAction(6)),
            new MenuElement<LottoResult>("Czy kiedykolwiek nastąpiło powtórzenie?", new LottoBallotsRepeatedMenuAction())
        };
        
        public static void Main(string[] args)
        {
            var lottoResults = new LottoFileParser().Parse("dl.txt");
            var lottoMenuInputHandler = new LottoMenuInputHandler(MenuElements.Count, () => Environment.Exit(0));
            var menu = new Menu<LottoResult>(MenuElements, lottoResults, lottoMenuInputHandler);
            while (true)
            {
                menu.Draw();
                var keyInfo = Console.ReadKey();
                menu.HandleInput(keyInfo);
            }
        }
    }
}