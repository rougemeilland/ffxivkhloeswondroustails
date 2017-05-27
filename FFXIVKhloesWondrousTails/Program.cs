using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVKhloesWondrousTails
{
    class Program
    {
        static void Main(string[] args)
        {
            var クロ帳に9マス埋める組み合わせ = WondrousTailsPattern.EnumeratePattern(9).ToArray();
            var クロ帳に9マス埋めた時点で4ライン以上並ぶ組み合わせ = クロ帳に9マス埋める組み合わせ.Where(p => p.GetLineCount() >= 4).ToArray();
            var クロ帳に9マス埋めた時点で3ライン並ぶ組み合わせ = クロ帳に9マス埋める組み合わせ.Where(p => p.GetLineCount() == 3).ToArray();
            var クロ帳に9マス埋めた時点で2ライン並ぶ組み合わせ = クロ帳に9マス埋める組み合わせ.Where(p => p.GetLineCount() == 2).ToArray();
            var クロ帳に9マス埋めた時点で1ライン並ぶ組み合わせ = クロ帳に9マス埋める組み合わせ.Where(p => p.GetLineCount() == 1).ToArray();
            var クロ帳に9マス埋めた時点で0ライン並ぶ組み合わせ = クロ帳に9マス埋める組み合わせ.Where(p => p.GetLineCount() == 0).ToArray();
            Console.WriteLine(string.Format("クロ帳に9マス埋める組み合わせの数＝{0}", クロ帳に9マス埋める組み合わせ.Length));
            Console.WriteLine(string.Format("クロ帳に9マス埋めた時点で4ライン以上並ぶ組み合わせの数＝{0} ({1:P2})", クロ帳に9マス埋めた時点で4ライン以上並ぶ組み合わせ.Length, (double)クロ帳に9マス埋めた時点で4ライン以上並ぶ組み合わせ.Length / クロ帳に9マス埋める組み合わせ.Length));
            Console.WriteLine(string.Format("クロ帳に9マス埋めた時点で3ライン並ぶ組み合わせの数＝{0} ({1:P2})", クロ帳に9マス埋めた時点で3ライン並ぶ組み合わせ.Length, (double)クロ帳に9マス埋めた時点で3ライン並ぶ組み合わせ.Length / クロ帳に9マス埋める組み合わせ.Length));
            Console.WriteLine(string.Format("クロ帳に9マス埋めた時点で2ライン並ぶ組み合わせの数＝{0} ({1:P2})", クロ帳に9マス埋めた時点で2ライン並ぶ組み合わせ.Length, (double)クロ帳に9マス埋めた時点で2ライン並ぶ組み合わせ.Length / クロ帳に9マス埋める組み合わせ.Length));
            Console.WriteLine(string.Format("クロ帳に9マス埋めた時点で1ライン並ぶ組み合わせの数＝{0} ({1:P2})", クロ帳に9マス埋めた時点で1ライン並ぶ組み合わせ.Length, (double)クロ帳に9マス埋めた時点で1ライン並ぶ組み合わせ.Length / クロ帳に9マス埋める組み合わせ.Length));
            Console.WriteLine(string.Format("クロ帳に9マス埋めた時点で1ラインも並ばない組み合わせの数＝{0} ({1:P2})", クロ帳に9マス埋めた時点で0ライン並ぶ組み合わせ.Length, (double)クロ帳に9マス埋めた時点で0ライン並ぶ組み合わせ.Length / クロ帳に9マス埋める組み合わせ.Length));
            Console.WriteLine("9マス埋めた時点で3ライン並ぶ配置=>");
            foreach (var p in クロ帳に9マス埋めた時点で3ライン並ぶ組み合わせ)
            {
                Console.WriteLine(p.GetPresentation());
                Console.WriteLine();
                Console.WriteLine();
            }
            var クロ帳に7マス埋める組み合わせ = WondrousTailsPattern.EnumeratePattern(7).ToArray();
            var クロ帳に7マス埋め更に1マス埋める組み合わせ = クロ帳に7マス埋める組み合わせ.SelectMany(p => p.Put().Select(p2 => new { original_pattern = p, rate = 1.0 / 9, new_pattern = p2 }));
            var クロ帳に7マス埋め更に2マス埋める組み合わせ = クロ帳に7マス埋め更に1マス埋める組み合わせ.SelectMany(item => item.new_pattern.Put().Select(p2 => new { item.original_pattern, rate = item.rate * 1.0 / 8, new_pattern = p2 }));
            var クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ組み合わせ = クロ帳に7マス埋め更に2マス埋める組み合わせ.Where(item => item.new_pattern.GetLineCount() == 3).ToArray();
            var クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ組み合わせとその確率 = クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ組み合わせ.GroupBy(item => item.original_pattern).Select(g => new { pattern = g.Key, rate = g.Sum(item => item.rate) }).ToArray();
            Console.WriteLine(string.Format("クロ帳に7マス埋める組み合わせの数＝{0}", クロ帳に7マス埋める組み合わせ.Length));
            var rate_array = クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ組み合わせとその確率.Select(item => item.rate).Distinct().OrderByDescending(item => item).ToArray();
            System.Diagnostics.Debug.Assert(rate_array.Length == 3);// 以降のコードはrate_arrayのサイズが3であることを仮定する
            var クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ可能性が少しでも存在する組み合わせ = クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ組み合わせとその確率.Where(item => item.rate >= rate_array[2]).OrderBy(item => item.rate).ThenBy(item => item.pattern).ToArray();
            var クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ可能性が中程度以上で存在する組み合わせ = クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ組み合わせとその確率.Where(item => item.rate >= rate_array[1]).OrderBy(item => item.rate).ThenBy(item => item.pattern).ToArray();
            var クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ可能性が比較的高く存在する組み合わせ = クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ組み合わせとその確率.Where(item => item.rate >= rate_array[0]).OrderBy(item => item.rate).ThenBy(item => item.pattern).ToArray();
            Console.WriteLine(string.Format("クロ帳に7マス埋めたうち、更に2マス埋めた結果3ライン並ぶ可能性が少しでも存在する組み合わせ＝{0} ({1:P2}), その場合の3ライン並ぶ平均確率＝{2:P2}",
                                            クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ可能性が少しでも存在する組み合わせ.Length,
                                            (double)クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ可能性が少しでも存在する組み合わせ.Length / クロ帳に7マス埋める組み合わせ.Length,
                                            クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ可能性が少しでも存在する組み合わせ.Average(item => item.rate)));
            Console.WriteLine("例：");
            Console.WriteLine(クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ可能性が少しでも存在する組み合わせ.First().pattern.GetPresentation());
            Console.WriteLine(string.Format("クロ帳に7マス埋めたうち、更に2マス埋めた結果3ライン並ぶ可能性が中程度以上で存在する組み合わせ＝{0} ({1:P2}), その場合の3ライン並ぶ平均確率＝{2:P2}",
                                            クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ可能性が中程度以上で存在する組み合わせ.Length,
                                            (double)クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ可能性が中程度以上で存在する組み合わせ.Length / クロ帳に7マス埋める組み合わせ.Length,
                                            クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ可能性が中程度以上で存在する組み合わせ.Average(item => item.rate)));
            Console.WriteLine("例：");
            Console.WriteLine(クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ可能性が中程度以上で存在する組み合わせ.First().pattern.GetPresentation());
            Console.WriteLine(string.Format("クロ帳に7マス埋めたうち、更に2マス埋めた結果3ライン並ぶ可能性が比較的高確率で存在する組み合わせ＝{0} ({1:P2}), その場合の3ライン並ぶ平均確率＝{2:P2}",
                                            クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ可能性が比較的高く存在する組み合わせ.Length,
                                            (double)クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ可能性が比較的高く存在する組み合わせ.Length / クロ帳に7マス埋める組み合わせ.Length,
                                            クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ可能性が比較的高く存在する組み合わせ.Average(item => item.rate)));
            Console.WriteLine("例：");
            Console.WriteLine(クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ可能性が比較的高く存在する組み合わせ.First().pattern.GetPresentation());
            /*
            foreach (var p in クロ帳に7マス埋め更に2マス埋めた結果3ライン並ぶ組み合わせ)
            {
                Console.WriteLine(string.Format("{0:P2}", p.rate));
                Console.WriteLine(p.pattern.GetPresentation());
                Console.WriteLine();
                Console.WriteLine();
            }
            */
            Console.WriteLine("Ok.");
            Console.ReadLine();
        }
    }
}
