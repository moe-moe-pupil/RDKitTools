// --------------------------------------------------------------------------------------------------------------
// <copyright file="EffectTests.cs" company="RDKitTools Technologies and contributors.">
// 此源代码的使用受 MIT LICENSE 许可证的约束, 可以在以下链接找到该许可证.
// Use of this source code is governed by the MIT license that can be found through the following link.
// https://github.com/moe-moe-pupil/RDKitTools/blob/main/LICENSE
// </copyright>
// --------------------------------------------------------------------------------------------------------------
namespace Tests
{
    using RDKitTools.Enum;
    using RDKitTools.Skill;
    using RDKitTools.Struct;
    using RDKitTools.Unit;

    [TestFixture]
    public class EffectTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BasicEffect()
        {
            Unit attacker = new Unit { HP = 100 };
            Unit defender = new Unit { HP = 100 };
            List<Effect> effects = new ();
            effects.Add(Effect.Damage);
            defender.GiveBuff(new Buff
            {
                BuffMetaData = new SEffect
                {
                    From = attacker,
                    Targets = new() { defender },
                    Type = EBuffType.Magic,
                    Values = new() { 1 },
                },
                Effects = effects,
                Delay = 0,
                LifeTime = 0,
                TriggerTime = 1,
                Name = "instant damage 1",
                Desc = "just 1 damage",
            });
            defender.GiveBuff(new Buff
            {
                BuffMetaData = new SEffect
                {
                    From = attacker,
                    Targets = new() { defender },
                    Type = EBuffType.Magic,
                    Values = new() { 1 },
                },
                Effects = effects,
                Delay = 1,
                LifeTime = 0,
                TriggerTime = 1,
                Name = "delay 1 damage 1",
                Desc = "just 1 delay damage",
            });
            defender.Update(0.02);
            Assert.That(defender.HP, Is.EqualTo(99));
            Assert.That(defender.Buffs.Count, Is.EqualTo(1));
            defender.Update(0.5);
            Assert.That(defender.HP, Is.EqualTo(99));
            Assert.That(defender.Buffs.Count, Is.EqualTo(1));
            defender.Update(1);
            Assert.That(defender.Buffs.Count, Is.EqualTo(0));
            Assert.That(defender.HP, Is.EqualTo(98));
        }
    }
}