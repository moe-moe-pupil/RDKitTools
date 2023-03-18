// --------------------------------------------------------------------------------------------------------------
// <copyright file="Buff.cs" company="RDKitTools Technologies and contributors.">
// 此源代码的使用受 MIT LICENSE 许可证的约束, 可以在以下链接找到该许可证.
// Use of this source code is governed by the GNU AGPLv3 license that can be found through the following link.
// https://github.com/moe-moe-pupil/RDKitTools/blob/main/LICENSE
// </copyright>
// --------------------------------------------------------------------------------------------------------------

namespace RDKitTools.Skill
{
    /// <summary lang='Zh-CN'>
    /// Buff类，Effect类的聚合，负责分类和触发Effect.
    /// 规则1：_active、_passive分别为技能释放，被动的List<Effect>数组.
    /// </summary>
    public class Buff
    {
        /// <summary lang='Zh-CN'>
        /// 效果类聚合.
        /// </summary>
        private readonly List<Effect> _effects = new ();

        /// <summary lang='Zh-CN'>
        /// 效果类聚合.
        /// </summary>
        public List<Effect> Effects => this._effects;
    }
}
