﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecords.AutoGenerated
{
    public static class StringHelper
    {

        public static string GetAttributes(this PropertyInfo Property)
        {
            var attributes = Property.GetCustomAttributes(false);
            string finalAttributes = "";
            for (int count=0; count< attributes.Length; count++)
            {
                if (count != 0)
                    finalAttributes += Environment.NewLine +  "         ";
                finalAttributes += GetAttributeAsText(attributes[count]);
                
            }

            return string.IsNullOrEmpty(finalAttributes)? "removeline": finalAttributes;
        }


        public static string RemoveGarbageLinesFromString(this string text,string searchFor= "removeline")
        {

            var lines = text.Split(new string[] { System.Environment.NewLine }, 
                        StringSplitOptions.None)
                        .Where(s=>!s.Contains(searchFor)).ToArray();

            string textCleaned = string.Join(System.Environment.NewLine, lines);

            return textCleaned;
        }

        private static string GetAttributeAsText(object attribute)
        {
            string finalAttributes = "[" + attribute.GetType().Name.Split("Attribute")[0];
            switch (attribute.GetType().Name)
            {
                case "StringLengthAttribute":
                    {
                        var stringLengthAttribute = (StringLengthAttribute)attribute;
                        finalAttributes += "(" + (stringLengthAttribute.MinimumLength!=0? 
                                                  stringLengthAttribute.MinimumLength + "," : string.Empty)+
                                            stringLengthAttribute.MaximumLength +
                                            ")" +
                                           "]";
                        break;
                    }
                case "MaxLengthAttribute":
                    {
                        var stringLengthAttribute = (MaxLengthAttribute)attribute;
                        finalAttributes += "(" +
                                            stringLengthAttribute.Length + ")" +
                                           "]";
                        break;
                    }
                case "MinLengthAttribute":
                    {
                        var stringLengthAttribute = (MinLengthAttribute)attribute;
                        finalAttributes += "[" + attribute.GetType().Name.Split("Attribute")[0] +
                                           "(" + stringLengthAttribute.Length +
                                           ")" +
                                           "]";
                        break;
                    }
                default:
                    {
                        finalAttributes += "]";
                        break;
                    }

            }

            return finalAttributes;
        }

        public static string CSharpTypeName(this Type type)
        {
            var name = ConverteCSharpGeniricTypeToCamelCase(type.Name);
          
            if (!type.IsGenericType) return name;
     

            return ConverteCSharpTypeNameToRightSyntax(name, type);
        }

        private static string ConverteCSharpGeniricTypeToCamelCase(string name)
        {
 
            switch (name)
            {
                case "String":
                    {
                        name = "string";
                        break;
                    }
                case "Decimal":
                    {
                        name = "decimal";
                        break;
                    }
                case "Int32":
                    {
                        name = "int";
                        break;
                    }
                case "Double":
                    {
                        name = "double";
                        break;
                    }

            }
            return name;
        }

        private static string ConverteCSharpTypeNameToRightSyntax(string name, Type type)
        {
            var stringBuilder = new StringBuilder();

            switch (name.Substring(0, name.IndexOf('`')).ToLower())
            {
                case "nullable":
                    {
                        stringBuilder.Append(string.Join(", ", type.GetGenericArguments()
                                                        .Select(t => t.CSharpTypeName())));
                        stringBuilder.Append("?");

                        break;
                    }
                default:
                    {
                        stringBuilder.Append(name.Substring(0, name.IndexOf('`')));
                        stringBuilder.Append("<");
                        stringBuilder.Append(string.Join(", ", type.GetGenericArguments()
                                                        .Select(t => t.CSharpTypeName())));
                        stringBuilder.Append(">");
                        break;
                    }

            }

            return stringBuilder.ToString();
        }
        /// <summary>
        /// Convert snake_case to PascalCase(UpperCamel).
        /// </summary>
        /// <param name="snakeCaseString">snake_case string.</param>
        /// <returns>PascalCase string.</returns>
        public static string ToPascalCase(this string snakeCaseString)
            => string.IsNullOrEmpty(snakeCaseString) ?
                snakeCaseString : ToCamelCaseInner(snakeCaseString.AsSpan(), true);

        /// <summary>
        /// Convert snake_case to camelCase(lowerCamel).
        /// </summary>
        /// <param name="snakeCaseString">snake_case string.</param>
        /// <returns>camelCase string.</returns>
        public static string ToCamelCase(this string snakeCaseString)
            => string.IsNullOrEmpty(snakeCaseString) ?
                snakeCaseString : ToCamelCaseInner(snakeCaseString.AsSpan(), false);

        /// <summary>
        /// Inner Method for <see cref="ToPascalCase(string)"/> and <see cref="ToCamelCase(string)"/>.
        /// </summary>
        /// <param name="source">snake_case chars span.</param>
        /// <param name="isUpper">First Letter is Upper or Lower.</param>
        /// <returns>(Upper|Lower) camelCase string.</returns>
        private static string ToCamelCaseInner(ReadOnlySpan<char> source, bool isUpper)
        {
            // if length is short, use stackalloc to avoid `new`.
            // TODO: use ArrayPool to avoid `new` completely.
            var buffer = source.Length <= 100 ?
                stackalloc char[source.Length] : new char[source.Length];

            int written = 0;
            foreach (char c in source)
            {
                if (c == '_')
                {
                    // (written != 0) means "Is Not First Letter".
                    // if camelCase and first letter, (isUpper | "Is Not First Letter") is false.
                    // if PascalCase and first letter, (isUpper | "Is Not First Letter") is true.
                    // if not first letter, (isUpper | "Is Not First Letter") is true whether isUpper is true or not.
                    isUpper |= (written != 0);
                    continue;
                }

                buffer[written++] = isUpper ? char.ToUpperInvariant(c) : char.ToLowerInvariant(c);
                isUpper = false;
            }
            return (written == 0) ? "" : new string(buffer.Slice(0, written));
        }
    }
}
