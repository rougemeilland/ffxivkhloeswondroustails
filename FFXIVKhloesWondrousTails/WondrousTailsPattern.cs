using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIVKhloesWondrousTails
{
    internal class WondrousTailsPattern
        : IEquatable<WondrousTailsPattern>, IComparable<WondrousTailsPattern>
    {
        #region プライベートフィールド

        // Ａ〇〇Ｂ
        // 〇〇〇〇
        // 〇〇〇〇
        // Ｃ〇〇Ｄ
        // 上記のクロ帳で、Aはbit0、Bはbit3、Cはbit12、Dはbit15とする。

        private int _bit_pattern;

        #endregion

        #region コンストラクタ

        public WondrousTailsPattern(int bit_pattern)
        {
            _bit_pattern = bit_pattern;
        }

        #endregion

        #region パブリックメソッド

        public static IEnumerable<WondrousTailsPattern> EnumeratePattern(int bit_count)
        {
            return (Enumerable.Range(0, 0x10000).Select(bits => new WondrousTailsPattern(bits)).Where(pattern => pattern.GetTotalBitCount() == bit_count));
        }

        public int GetTotalBitCount()
        {
            return (GetBitCount4((_bit_pattern >> 12) & 0b1111) +
                    GetBitCount4((_bit_pattern >> 8) & 0b1111) +
                    GetBitCount4((_bit_pattern >> 4) & 0b1111) +
                    GetBitCount4((_bit_pattern >> 0) & 0b1111));
        }

        public int GetLineCount()
        {
            return ((IsLine(0b0000000000001111) ? 1 : 0) +
                    (IsLine(0b0000000011110000) ? 1 : 0) +
                    (IsLine(0b0000111100000000) ? 1 : 0) +
                    (IsLine(0b1111000000000000) ? 1 : 0) +
                    (IsLine(0b0001000100010001) ? 1 : 0) +
                    (IsLine(0b0010001000100010) ? 1 : 0) +
                    (IsLine(0b0100010001000100) ? 1 : 0) +
                    (IsLine(0b1000100010001000) ? 1 : 0) +
                    (IsLine(0b1000010000100001) ? 1 : 0) +
                    (IsLine(0b0001001001001000) ? 1 : 0));
        }

        public bool IsLine(int mask)
        {
            return ((_bit_pattern & mask) == mask);
        }

        public string GetPresentation()
        {
            return (GetBitPresentation(1 << 0) + GetBitPresentation(1 << 1) + GetBitPresentation(1 << 2) + GetBitPresentation(1 << 3) + "\n" +
                    GetBitPresentation(1 << 4) + GetBitPresentation(1 << 5) + GetBitPresentation(1 << 6) + GetBitPresentation(1 << 7) + "\n" +
                    GetBitPresentation(1 << 8) + GetBitPresentation(1 << 9) + GetBitPresentation(1 << 10) + GetBitPresentation(1 << 11) + "\n" +
                    GetBitPresentation(1 << 12) + GetBitPresentation(1 << 13) + GetBitPresentation(1 << 14) + GetBitPresentation(1 << 15));
        }

        public IEnumerable<WondrousTailsPattern> Put()
        {
            return (Enumerable.Range(0, 16).Select(bit_index => 1 << bit_index).Where(mask => (_bit_pattern & mask) == 0).Select(mask => new WondrousTailsPattern(_bit_pattern | mask)));
        }

        #endregion

        #region プライベートメソッド

        private int GetBitCount4(int bit_pattern_4)
        {
            switch (bit_pattern_4)
            {
                case 0b0000:
                    return (0);
                case 0b0001:
                    return (1);
                case 0b0010:
                    return (1);
                case 0b0011:
                    return (2);
                case 0b0100:
                    return (1);
                case 0b0101:
                    return (2);
                case 0b0110:
                    return (2);
                case 0b0111:
                    return (3);
                case 0b1000:
                    return (1);
                case 0b1001:
                    return (2);
                case 0b1010:
                    return (2);
                case 0b1011:
                    return (3);
                case 0b1100:
                    return (2);
                case 0b1101:
                    return (3);
                case 0b1110:
                    return (3);
                case 0b1111:
                    return (4);
                default:
                    throw new ArgumentException();
            }
        }

        private string GetBitPresentation(int mask)
        {
            return ((_bit_pattern & mask) != 0 ? "●" : "〇");
        }

        #endregion

        #region object から継承されたメンバ

        public override bool Equals(object o)
        {
            if (o == null || GetType() != o.GetType())
                return (false);
            return (Equals((WondrousTailsPattern)o));
        }

        public override int GetHashCode()
        {
            return (_bit_pattern.GetHashCode());
        }

        #endregion

        #region IEquatable<WondrousTailsPattern> のメンバ

        public bool Equals(WondrousTailsPattern o)
        {
            if (!_bit_pattern.Equals(o._bit_pattern))
                return (false);
            return (true);
        }

        #endregion

        #region IComparable<WondrousTailsPattern> のメンバ

        public int CompareTo(WondrousTailsPattern o)
        {
            if (o == null)
                return (1);
            return (_bit_pattern.CompareTo(o._bit_pattern));
        }

        #endregion

    }
}
