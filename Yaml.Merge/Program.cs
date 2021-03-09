using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Yaml.Merge
{
    struct Item
    {
        public int X { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            var filePath = Path.Combine(AppContext.BaseDirectory, "input.yaml");
            using var contents = File.OpenText(filePath);
            var configuration = deserializer.Deserialize<Dictionary<string, Item>>(new MergingParser(new Parser(contents)));
            Console.WriteLine(configuration["item"].X);
        }
    }
}
