// --------------------------------------------------------------------------------------------------------------
// <copyright file="ModifyTests.cs" company="RDKitTools Technologies and contributors.">
// 此源代码的使用受 MIT LICENSE 许可证的约束, 可以在以下链接找到该许可证.
// Use of this source code is governed by the GNU AGPLv3 license that can be found through the following link.
// https://github.com/moe-moe-pupil/RDKitTools/blob/main/LICENSE
// </copyright>
// --------------------------------------------------------------------------------------------------------------
namespace Tests
{
    using RDKitTools.Skill;

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
            string[] rawString = { "2", "3", "=999", "1.1" };
            Assert.That(Calculator.Calc(rawString), Is.EqualTo(1000.1));
            string[] rawString2 = { "2", "3", "-3", "1" };
            Assert.That(Calculator.Calc(rawString2), Is.EqualTo(3.0));
            string[] rawString3 = { "2", "3", "100%", "1" };
            Assert.That(Calculator.Calc(rawString3), Is.EqualTo(12.0));
            string[] rawString4 = { "2", "-3", "100%", "=1" };
            Assert.That(Calculator.Calc(rawString4), Is.EqualTo(2.0));
        }
    }
}