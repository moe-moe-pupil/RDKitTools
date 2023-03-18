// --------------------------------------------------------------------------------------------------------------
// <copyright file="SEffect.cs" company="RDKitTools Technologies and contributors.">
// 此源代码的使用受 MIT LICENSE 许可证的约束, 可以在以下链接找到该许可证.
// Use of this source code is governed by the GNU AGPLv3 license that can be found through the following link.
// https://github.com/moe-moe-pupil/RDKitTools/blob/main/LICENSE
// </copyright>
// --------------------------------------------------------------------------------------------------------------

namespace RDKitTools.Struct
{
    using RDKitTools.Enum;
    using RDKitTools.Unit;

    public ref struct SEffect
    {
        /// <summary>
        /// buff from which unit.
        /// </summary>
        public ref Unit From;

        /// <summary>
        /// effect's type which inherited from buff.
        /// </summary>
        public EBuffType Type;

        /// <summary>
        /// just trigger value.
        /// </summary>
        public double Value;

        public void Deconstruct(ref Unit from, out EBuffType type, out double value)
        {
            from = From;
            type = Type;
            value = Value;
        }
    }
}
