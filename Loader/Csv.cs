﻿// --------------------------------------------------------------------------------------------------------------
// <copyright file="Csv.cs" company="RDKitTools Technologies and contributors.">
// 此源代码的使用受 MIT LICENSE 许可证的约束, 可以在以下链接找到该许可证.
// Use of this source code is governed by the GNU AGPLv3 license that can be found through the following link.
// https://github.com/moe-moe-pupil/RDKitTools/blob/main/LICENSE
// </copyright>
// --------------------------------------------------------------------------------------------------------------

namespace RDKitTools.Loader
{
    using System.Globalization;
    using CsvHelper;
    using RDKitTools.Skill;

    /// <summary>
    /// csv loader.
    /// </summary>
    public class Csv
    {
        public Csv(string path)
        {
            using (var streamReader = new StreamReader(path))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {

                    var records = csvReader.GetRecords<Buff>().ToList();
                }
            }
        }
    }
}
