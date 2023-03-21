// --------------------------------------------------------------------------------------------------------------
// <copyright file="SEffect.cs" company="RDKitTools Technologies and contributors.">
// 此源代码的使用受 MIT LICENSE 许可证的约束, 可以在以下链接找到该许可证.
// Use of this source code is governed by the GNU AGPLv3 license that can be found through the following link.
// https://github.com/moe-moe-pupil/RDKitTools/blob/main/LICENSE
// </copyright>
// --------------------------------------------------------------------------------------------------------------

namespace RDKitTools.Struct
{
    using System.Diagnostics.CodeAnalysis;
    using RDKitTools.Enum;
    using RDKitTools.Unit;

    public struct SEffect
    {
        /// <summary>
        /// buff from which unit.
        /// </summary>
        [AllowNull]
        required public Unit From { get; set; }

        /// <summary>
        /// buff's target unit.
        /// </summary>
        [AllowNull]
        required public Unit Target { get; set; }

        /// <summary>
        /// effect's type which inherited from buff.
        /// </summary>
        required public EBuffType Type { get; set; }

        /// <summary>
        /// just trigger value.
        /// </summary>
        required public double Value { get; set; }

        public void Deconstruct(out Unit from, out Unit target, out EBuffType type, out double value)
        {
            from = From;
            type = Type;
            target = Target;
            value = Value;
        }
    }
}
