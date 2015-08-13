﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kecaknoah.Type
{
    /// <summary>
    /// Kecaknoahでの整数を定義します。
    /// </summary>
    public sealed class KecaknoahInteger : KecaknoahObject
    {
        /// <summary>
        /// 実際の値を取得・設定します。
        /// </summary>
        public long Value { get; set; } = 0;

        /// <summary>
        /// 最大値のインスタンスを取得します。
        /// </summary>
        public static KecaknoahInteger MaxValue = new KecaknoahInteger { Value = long.MaxValue };

        /// <summary>
        /// 最小値のインスタンスを取得します。
        /// </summary>
        public static KecaknoahInteger MinValue = new KecaknoahInteger { Value = long.MaxValue };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override KecaknoahObject GetMember(string name)
        {
            switch (name)
            {
                case "MAX_VALUE":
                    return long.MaxValue.AsKecaknoahInteger();
                case "MIN_VALUE":
                    return long.MinValue.AsKecaknoahInteger();
            }
            return base.GetMember(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="op"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public override KecaknoahObject ExpressionOperation(KecaknoahILCodeType op, KecaknoahObject target)
        {
            var ot = target.AsRawObject<long>();
            if (ot == null) return KecaknoahNil.Instance;
            var t = (long)ot;
            switch (op)
            {
                case KecaknoahILCodeType.Plus:
                    return (Value + t).AsKecaknoahInteger();
                case KecaknoahILCodeType.Minus:
                    return (Value - t).AsKecaknoahInteger();
                case KecaknoahILCodeType.Multiply:
                    return (Value * t).AsKecaknoahInteger();
                case KecaknoahILCodeType.Divide:
                    return (Value / t).AsKecaknoahInteger();
                case KecaknoahILCodeType.And:
                    return (Value & t).AsKecaknoahInteger();
                case KecaknoahILCodeType.Or:
                    return (Value | t).AsKecaknoahInteger();
                case KecaknoahILCodeType.Xor:
                    return (Value ^ t).AsKecaknoahInteger();
                case KecaknoahILCodeType.Modular:
                    return (Value % t).AsKecaknoahInteger();
                case KecaknoahILCodeType.LeftBitShift:
                    return (Value << (int)t).AsKecaknoahInteger();
                case KecaknoahILCodeType.RightBitShift:
                    return (Value >> (int)t).AsKecaknoahInteger();
                case KecaknoahILCodeType.Equal:
                    return (Value == t).AsKecaknoahBoolean();
                case KecaknoahILCodeType.NotEqual:
                    return (Value != t).AsKecaknoahBoolean();
                case KecaknoahILCodeType.Greater:
                    return (Value > t).AsKecaknoahBoolean();
                case KecaknoahILCodeType.Lesser:
                    return (Value < t).AsKecaknoahBoolean();
                case KecaknoahILCodeType.GreaterEqual:
                    return (Value >= t).AsKecaknoahBoolean();
                case KecaknoahILCodeType.LesserEqual:
                    return (Value <= t).AsKecaknoahBoolean();
                default:
                    return KecaknoahNil.Instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override object AsRawObject<T>()
        {
            var to = typeof(T);
            switch (to.Name)
            {
                case nameof(Byte):
                    return Convert.ToByte(Value);
                case nameof(SByte):
                    return Convert.ToSByte(Value);
                case nameof(Int16):
                    return Convert.ToInt16(Value);
                case nameof(UInt16):
                    return Convert.ToUInt16(Value);
                case nameof(Int32):
                    return Convert.ToInt32(Value);
                case nameof(UInt32):
                    return Convert.ToUInt32(Value);
                case nameof(Int64):
                    return Value;
                case nameof(UInt64):
                    return Convert.ToUInt64(Value);
                case nameof(Single):
                    return Convert.ToSingle(Value);
                case nameof(Double):
                    return Convert.ToDouble(Value);
                case nameof(Decimal):
                    return Convert.ToDecimal(Value);
            }
            return null;
        }

        /// <summary>
        /// 現在の以下略。
        /// </summary>
        /// <returns>知るか</returns>
        public override string ToString() => Value.ToString();
    }
}