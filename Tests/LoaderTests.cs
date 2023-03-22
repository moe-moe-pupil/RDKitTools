// --------------------------------------------------------------------------------------------------------------
// <copyright file="ModifyTests.cs" company="RDKitTools Technologies and contributors.">
// ��Դ�����ʹ���� MIT LICENSE ���֤��Լ��, ���������������ҵ������֤.
// Use of this source code is governed by the GNU AGPLv3 license that can be found through the following link.
// https://github.com/moe-moe-pupil/RDKitTools/blob/main/LICENSE
// </copyright>
// --------------------------------------------------------------------------------------------------------------
namespace Tests
{
    using RDKitTools.Loader;
    using RDKitTools.Skill;
    using RDKitTools.Unit;

    [TestFixture]
    public class LoaderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LoadBuff()
        {
            var test = new FileInfo("buffs.csv");
            Csv csv = new Csv(test.FullName.Substring(0, test.FullName.IndexOf(@"\bin")) + @"\buffs.csv");
            Unit attacker = new Unit { HP = 100 };
            Unit defender = new Unit { HP = 100 };
            var newMetaData = csv.Buffs[0].BuffMetaData;
            newMetaData.Targets = new() { defender };
            newMetaData.From = attacker;
            csv.Buffs[0].BuffMetaData = newMetaData;
            defender.GiveBuff(csv.Buffs[0]);
            Console.WriteLine(csv.Buffs[0].Name);
            defender.Update(0.02);
            Assert.That(defender.HP, Is.EqualTo(1));
        }
    }
}