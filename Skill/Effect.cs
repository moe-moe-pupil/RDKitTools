// --------------------------------------------------------------------------------------------------------------
// <copyright file="Effect.cs" company="RDKitTools Technologies and contributors.">
// 此源代码的使用受 MIT LICENSE 许可证的约束, 可以在以下链接找到该许可证.
// Use of this source code is governed by the GNU AGPLv3 license that can be found through the following link.
// https://github.com/moe-moe-pupil/RDKitTools/blob/main/LICENSE
// </copyright>
// --------------------------------------------------------------------------------------------------------------

namespace RDKitTools.Skill
{
    using RDKitTools.Enum;
    using RDKitTools.Struct;
    using RDKitTools.Unit;
    using RDKitTools.Utils;

    /// <summary lang='Zh-CN'>
    /// 基础Effect类，技能效果的最小单元.
    /// </summary>
    public abstract class Effect : SmartEnum<Effect>
    {
        /// <summary lang='Zh-CN'>
        /// 伤害效果.
        /// </summary>
        public static readonly Effect Damage = new DamageEffect();

        /// <summary lang='Zh-CN'>
        /// 治疗效果.
        /// </summary>
        public static readonly Effect Heal = new HealEffect();

        private Effect(int value, string name)
            : base(value, name)
        {
        }

        /// <summary lang>
        /// trigger effect.
        /// </summary>
        public abstract void Trigger(SEffect effectData, int index);

        private sealed class DamageEffect : Effect
        {
            public DamageEffect()
                : base(1, nameof(Damage))
            {
            }

            public override void Trigger(SEffect effectData, int index)
            {
                (Unit from, List<Unit> targets, EBuffType type, List<double> values) = effectData;
                targets.ForEach(target =>
                {
                    target.TakeDamage(ref from, type, values[index] * from.GetDamageModify(type));
                });
            }
        }

        private sealed class HealEffect : Effect
        {
            public HealEffect()
                : base(2, nameof(Heal))
            {
            }

            public override void Trigger(SEffect effectData, int index)
            {
                (Unit from, List<Unit> targets, EBuffType type, List<double> values) = effectData;
                targets.ForEach(target =>
                {
                    target.TakeHeal(ref from, type, values[index] * from.GetDamageModify(type));
                });
            }
        }
    }
}