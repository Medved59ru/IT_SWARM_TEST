using CSVParserCore.Dtos;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParserCore
{
    internal static class FileParser
    {
        public static List<Dto> GetFieldsBy(string path, string fileName, string comments)
        {
            List<Dto> list = new List<Dto>();

            using (TextFieldParser textFieldParser = new TextFieldParser(path))
            {
                textFieldParser.TextFieldType = FieldType.Delimited;
                textFieldParser.SetDelimiters(";");

                while (!textFieldParser.EndOfData)
                {
                    string[] fields = textFieldParser.ReadFields();

                    Dto localDto = new Dto()
                    {
                        Number = CheckPhone(fields[0]),
                        LastName = fields[1],
                        FirstName = fields[2],
                        MidName = fields[3],
                        Category = fields[4], // привинтить перечисление
                        Sex = CheckSex (fields[5]), // привинтить перечисление
                        City = TrimTheCity (fields[6]), // проверку города доделать
                        BirthDay = fields[7],
                        CreationDay = DateTime.Today,
                        SourceName = fileName,
                        Comments = comments
                    };// можно реализовать через конструктор

                    if (localDto.Number.Length == 11)
                    {
                        list.Add(localDto);
                    }

                }
            }
            return list;
        }

        private static string CheckPhone(string phone)
        {
            char[] chars = phone.ToCharArray();
            var sb = new StringBuilder();
            foreach (char c in chars)
            {
                if (char.IsDigit(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        private static string TrimTheCity(string city)
        {
            string cityName = city.Trim();
            char[] chars = cityName.ToCharArray();
            var sb = new StringBuilder();

            foreach (char c in chars)// возможно регулярные выражения
            {
                if (char.IsDigit(c) || char.IsLetter(c))
                {
                    sb.Append(c);
                }
            }

            cityName = sb.ToString();

            if (cityName.Length < 1)
            {
                cityName = "не определен";
            }

            return cityName;
        }

        private static string? CheckSex(string? sex)
        {
            if (String.IsNullOrWhiteSpace(sex))
            {
                sex = null;
            }
            return sex;
        }

    }
}
