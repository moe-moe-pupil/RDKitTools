// --------------------------------------------------------------------------------------------------------------
// <copyright file="Buff.cs" company="RDKitTools Technologies and contributors.">
// 此源代码的使用受 MIT LICENSE 许可证的约束, 可以在以下链接找到该许可证.
// Use of this source code is governed by the MIT license that can be found through the following link.
// https://github.com/moe-moe-pupil/RDKitTools/blob/main/LICENSE
// </copyright>
// --------------------------------------------------------------------------------------------------------------

namespace RDKitTools.Skill
{
    using RDKitTools.Enum;
    using RDKitTools.Struct;
    using RDKitTools.Unit;

    /// <summary lang='Zh-CN'>
    /// Buff类，Effect类的聚合，负责分类和触发Effect.
    /// 规则1：_active、_passive分别为技能释放，被动的List<Effect>数组.
    /// </summary>
    public class Buff
    {
        private double _delay;

        private int _triggerTime = 1;

        private double _lifeTime;

        /// <summary lang='Zh-CN'>
        /// 效果类聚合.
        /// </summary>
        required public List<Effect> Effects { get; init; }

        required public string Name { get; init; }

        required public string Desc { get; init; }

        required public SEffect BuffMetaData { get; set; } = new()
        {
            From = null,
            Targets = null,
            Type = EBuffType.Magic,
            Values = new() { 0 },
        };

        required public double Delay
        {
            get => _delay;
            set => _delay = value;
        }

        required public double LifeTime
        {
            get => _lifeTime;
            set => _lifeTime = value;
        }

        required public int TriggerTime
        {
            get => _triggerTime;
            set => _triggerTime = value;
        }

        public void Update(double delta)
        {
            (Unit from, List<Unit> targets, EBuffType type, List<double> values) = BuffMetaData;
            if (Delay - delta > 0)
            {
                Delay -= delta;
            }
            else if (TriggerTime > 0)
            {
                foreach (var item in Effects.Select((effect, index) => (effect, index)))
                {
                    item.effect.Trigger(
                    new SEffect
                    {
                        From = from,
                        Targets = targets,
                        Type = type,
                        Values = values,
                    },
                    item.index);
                    TriggerTime -= 1;
                }

                LifeTime -= delta;
            }
        }
    }
}
