// --------------------------------------------------------------------------------------------------------------
// <copyright file="Unit.cs" company="RDKitTools Technologies and contributors.">
// 此源代码的使用受 MIT LICENSE 许可证的约束, 可以在以下链接找到该许可证.
// Use of this source code is governed by the GNU AGPLv3 license that can be found through the following link.
// https://github.com/moe-moe-pupil/RDKitTools/blob/main/LICENSE
// </copyright>
// --------------------------------------------------------------------------------------------------------------

namespace RDKitTools.Unit
{
    using RDKitTools.Skill;

    /// <summary lang='Zh-CN'>
    /// 基础单位类，具有基本的生命、魔法等属性.
    /// </summary>
    public class Unit
    {
        /// <summary lang='zh-CN'>
        ///     基础生命值.
        /// </summary>
        private double _hp;

        /// <summary lang='zh-CN'>
        ///     额外生命值.
        /// </summary>
        private double _extraHp;

        /// <summary lang='zh-CN'>
        ///     造成伤害调整.
        /// </summary>
        private double _damageModify = 1;

        /// <summary lang='zh-CN'>
        ///     遭受伤害调整.
        /// </summary>
        private double _defenseModify = 1;

        /// <summary lang='zh-CN'>
        ///     移动速度.
        /// </summary>
        private double _moveSpeed = 5;

        /// <summary lang='zh-CN'>
        ///     状态抗性调整.
        /// </summary>
        private double _statusModify = 1;

        /// <summary lang='zh-CN'>
        ///     目前持有的技能Id.
        /// </summary>
        private List<string> _skill = new ();

        /// <summary lang='zh-CN'>
        ///     目前身上的buff.
        /// </summary>
        private List<Buff> _buff = new ();

        public void TakeDamage(ref Unit attacker, double value)
        {
            this._hp -= value;
        }
    }
}
