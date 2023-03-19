// --------------------------------------------------------------------------------------------------------------
// <copyright file="ModifyTests.cs" company="RDKitTools Technologies and contributors.">
// 此源代码的使用受 MIT LICENSE 许可证的约束, 可以在以下链接找到该许可证.
// Use of this source code is governed by the GNU AGPLv3 license that can be found through the following link.
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
            Unit attacker = new Unit(100);
            Unit defender = new Unit(100);
            List<Effect> effects = new ();
            effects.Add(Effect.Damage);
            attacker.GiveBuff(new Buff(new SEffect() { From = attacker, Target = defender, Type = EBuffType.Magic, Value = 1 }, effects));
            attacker.Update();
            Assert.That(defender.GetHP(), Is.EqualTo(99));
        }
    }
}