using System;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Windows.Forms;

namespace CustomFramework.WebApiCodeGenerator
{
    public static class Helper
    {
        public static string ToLowerFirstLetter(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            var letters = source.ToCharArray();
            letters[0] = char.ToLower(letters[0]);
            return new string(letters);
        }

        public static string ToPlural(this string source)
        {
            var cultureInfo = new CultureInfo("en-us");
            var pluralizationService = PluralizationService.CreateService(cultureInfo);
            return pluralizationService.Pluralize(source);
        }

        public static Field ToField(this ListViewItem item)
        {
            return new Field(
                fieldName: item.SubItems[0].Text,
                fieldDataType: item.SubItems[1].Text,
                fieldDataLength: item.SubItems[2].Text,
                notNull: Convert.ToBoolean(item.SubItems[3].Text),
                addToRequest: Convert.ToBoolean(item.SubItems[4].Text),
                addToResponse: Convert.ToBoolean(item.SubItems[5].Text),
                hasGetMethod: Convert.ToBoolean(item.SubItems[6].Text),
                isUnique: Convert.ToBoolean(item.SubItems[7].Text)
            );
        }

        public static Reference ToReference(this ListViewItem item)
        {
            return new Reference(
                fieldName: item.SubItems[0].Text,
                fieldDataType: item.SubItems[1].Text,
                relation: (Relations)Enum.Parse(typeof(Relations), item.SubItems[2].Text, true),
                notNull: Convert.ToBoolean(item.SubItems[3].Text),
                addToRequest: Convert.ToBoolean(item.SubItems[4].Text),
                addToResponse: Convert.ToBoolean(item.SubItems[5].Text),
                hasGetMethod: Convert.ToBoolean(item.SubItems[6].Text),
                isUnique: Convert.ToBoolean(item.SubItems[7].Text),
                referenceClassName: item.SubItems[8].Text
            );
        }
    }
}
