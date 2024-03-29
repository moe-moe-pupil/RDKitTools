﻿// --------------------------------------------------------------------------------------------------------------
// <copyright file="Unit.cs" company="RDKitTools Technologies and contributors.">
// 此源代码的使用受 MIT LICENSE 许可证的约束, 可以在以下链接找到该许可证.
// Use of this source code is governed by the MIT license that can be found through the following link.
// https://github.com/moe-moe-pupil/RDKitTools/blob/main/LICENSE
// </copyright>
// --------------------------------------------------------------------------------------------------------------

namespace RDKitTools.Unit
{
    using System;
    using RDKitTools.Enum;
    using RDKitTools.Skill;
    using RDKitTools.Struct;

    /// <summary lang='Zh-CN'>
    /// 基础单位类，具有基本的生命、魔法等属性.
    /// </summary>
    public class Unit
    {
        /// <summary lang='zh-CN'>
        ///     基础生命值.
        /// </summary>
        public double HP { get; set; } = 100;

        /// <summary lang='zh-CN'>
        ///     最大生命值.
        /// </summary>
        public double MaxHP { get; set; } = 100;

        /// <summary lang='zh-CN'>
        ///     额外生命值.
        /// </summary>
        private double _extraHP;

        /// <summary lang='zh-CN'>
        ///     造成伤害调整.
        /// </summary>
        private List<double> _damageModify = new (Enumerable.Repeat<double>(1, Enum.GetNames(typeof(EBuffType)).Length));

        /// <summary lang='zh-CN'>
        ///     遭受伤害调整.
        /// </summary>
        private List<double> _takeDamageModify = new (Enumerable.Repeat<double>(1, Enum.GetNames(typeof(EBuffType)).Length));

        /// <summary lang='zh-CN'>
        ///     遭受治疗调整.
        /// </summary>
        private List<double> _takeHealModify = new (Enumerable.Repeat<double>(1, Enum.GetNames(typeof(EBuffType)).Length));

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
        private List<Buff> _buffs = new();

        public List<Buff> Buffs
        {
            get => _buffs;
            private set => _buffs = value;
        }

        public double GetDamageModify(EBuffType type)
        {
            return _damageModify[(int)type];
        }

        public void TakeDamage(ref Unit attacker, EBuffType type, double value)
        {
            HP -= value * _takeDamageModify[(int)type];
            HP = Math.Max(HP, 0);
        }

        public void TakeHeal(ref Unit healer, EBuffType type, double value)
        {
            HP += value * _takeHealModify[(int)type];
            HP = Math.Min(HP, MaxHP);
        }

        /// <summary>
        /// update unit's status.should use in every tick.
        /// </summary>
        /// <param name="delta">delta tick.</param>
        public void Update(double delta)
        {
            foreach (var item in Buffs.Select((buff, index) => (buff, index)))
            {
                item.buff.Update(delta);
            }

            RemoveAllDeadBuff();
        }

        public void GiveBuff(Buff buff)
        {
            Buffs.Add(buff);
        }

        public void RemoveAllDeadBuff()
        {
            Buffs.RemoveAll(buff => buff.LifeTime < 0);
        }
    }
}
