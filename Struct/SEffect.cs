// --------------------------------------------------------------------------------------------------------------
// <copyright file="SEffect.cs" company="RDKitTools Technologies and contributors.">
// 此源代码的使用受 MIT LICENSE 许可证的约束, 可以在以下链接找到该许可证.
// Use of this source code is governed by the MIT license that can be found through the following link.
// https://github.com/moe-moe-pupil/RDKitTools/blob/main/LICENSE
// </copyright>
// --------------------------------------------------------------------------------------------------------------

namespace RDKitTools.Struct
{
    using System.Diagnostics.CodeAnalysis;
    using RDKitTools.Enum;
    using RDKitTools.Skill;
    using RDKitTools.Unit;

    public struct SEffect
    {
        /// <summary>
        /// buff from which unit.
        /// </summary>
        [AllowNull]
        required public Unit From { get; set; }

        /// <summary>
        /// buff's target units.
        /// sometimes it's not the current one buff belongs to.
        /// it's just the effect targets.
        /// </summary>
        [AllowNull]
        required public List<Unit> Targets { get; set; }

        /// <summary>
        /// effect's type which inherited from buff.
        /// </summary>
        required public EBuffType Type { get; set; }

        /// <summary>
        /// just trigger value.
        /// </summary>
        required public List<double> Values { get; set; }

        public void Deconstruct(out Unit from, out List<Unit> targets, out EBuffType type, out List<double> values)
        {
            from = From;
            type = Type;
            targets = Targets;
            values = Values;
        }
    }
}
