// --------------------------------------------------------------------------------------------------------------
// <copyright file="Csv.cs" company="RDKitTools Technologies and contributors.">
// 此源代码的使用受 MIT LICENSE 许可证的约束, 可以在以下链接找到该许可证.
// Use of this source code is governed by the MIT license that can be found through the following link.
// https://github.com/moe-moe-pupil/RDKitTools/blob/main/LICENSE
// </copyright>
// --------------------------------------------------------------------------------------------------------------

namespace RDKitTools.Loader
{
    using System.Globalization;
    using System.Text;
    using System;
    using CsvHelper;
    using CsvHelper.Configuration;
    using RDKitTools.Enum;
    using RDKitTools.Skill;
    using RDKitTools.Struct;

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
                    csvReader.Context.RegisterClassMap<BuffClassMap>();
                    var records = csvReader.GetRecords<Buff>().ToList();
                    Buffs = records;
                }
            }
        }

        public List<Buff> Buffs { get; set; }

        public class BuffClassMap : ClassMap<Buff>
        {
            public BuffClassMap()
            {
                Map(m => m.Name).Name("name");
                Map(m => m.Desc).Name("desc");
                Map(m => m.Delay).Name("delay");
                Map(m => m.LifeTime).Name("life_time");
                Map(m => m.TriggerTime).Name("trigger_times");
                Map(m => m.BuffMetaData).Name("type").Convert(args =>
                {
                    var type = (args.Row as IReaderRow).GetField<string>("type");
                    var values = (args.Row as IReaderRow).GetField<string>("values");

                    SEffect buffMetaData = new ()
                    {
                        Targets = null,
                        From = null,
                        Values = new (),
                        Type = EBuffType.Magic,
                    };
                    if (values != null)
                    {
                        values.Split(',').ToList().ForEach(value =>
                        {
                            buffMetaData.Values.Add(Convert.ToDouble(value));
                        });
                    }
                    else
                    {
                        // Todo: handle no params
                    }

                    if (type != null)
                    {
                        buffMetaData.Type = (EBuffType)Enum.Parse(typeof(EBuffType), type);
                    }
                    else
                    {
                        // Todo: handle no params
                    }

                    return buffMetaData;
                });
                Map(m => m.Effects).Name("effects").Convert(args =>
                {
                    var values = (args.Row as IReaderRow).GetField<string>("effects");
                    var effects = new List<Effect>();
                    if (values != null)
                    {
                        values.Split(',').ToList().ForEach(value =>
                        {
                            effects.Add(Effect.FromName(value));
                        });
                    }
                    else
                    {
                        // Todo: handle no params
                    }

                    return effects;
                });
            }
        }
    }
}
