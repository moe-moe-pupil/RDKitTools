// --------------------------------------------------------------------------------------------------------------
// <copyright file="LoaderTests.cs" company="RDKitTools Technologies and contributors.">
// ��Դ�����ʹ���� MIT LICENSE ���֤��Լ��, ���������������ҵ������֤.
// Use of this source code is governed by the GNU AGPLv3 license that can be found through the following link.
// https://github.com/moe-moe-pupil/RDKitTools/blob/main/LICENSE
// </copyright>
// --------------------------------------------------------------------------------------------------------------
namespace Tests
{
    using RDKitTools.Loader;
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
            Unit attacker = new Unit { HP = 100, MaxHP = 100 };
            Unit defender = new Unit { HP = 100, MaxHP = 100 };
            for (var i = 0; i < csv.Buffs.Count; i++)
            {
                var newMetaData = csv.Buffs[i].BuffMetaData;
                newMetaData.Targets = new() { defender };
                newMetaData.From = attacker;
                csv.Buffs[i].BuffMetaData = newMetaData;
                defender.GiveBuff(csv.Buffs[i]);
            }

            defender.Update(0.02);
            Assert.That(defender.HP, Is.EqualTo(1));
            defender.Update(1);
            Assert.That(defender.HP, Is.EqualTo(100));
            defender.Update(1);
            Assert.That(defender.HP, Is.EqualTo(70));
        }
    }
}