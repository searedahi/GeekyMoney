using GeekyMoney.Model;
using System;
using System.Collections.Generic;

namespace GeekyMoney.Tools
{
    public class PercentOfOptionBuilder<T>
    {
        private readonly HashSet<Type> NumericTypes = new HashSet<Type>
        {
            typeof(int), typeof(double), typeof(decimal),
            typeof(long), typeof(short), typeof(sbyte),
            typeof(byte), typeof(ulong), typeof(ushort),
            typeof(uint), typeof(float)
        };

        private bool IsNumeric(Type myType)
        {
            return NumericTypes.Contains(Nullable.GetUnderlyingType(myType) ?? myType);
        }

        public IEnumerable<PercentOfOption> GetPercentOfOptions(T genericObject)
        {
            var optList = new List<PercentOfOption>();

            var i = 1;

            foreach (var prop in genericObject.GetType().GetProperties())
            {
                if (IsNumeric(prop.PropertyType))
                {
                    var val = Convert.ToDecimal(prop.GetValue(genericObject, null));
                    optList.Add(new PercentOfOption(i, val, prop.Name, $"{prop.Name} - {val}"));
                    i++;
                }
                else if (prop.PropertyType == typeof(IEnumerable<Fee>))
                {
                    List<Fee> propFees = prop.GetValue(genericObject, null) as List<Fee>;

                    foreach (var fe in propFees)
                    {
                        optList.Add(new PercentOfOption(i, fe.MonthlyTotal, fe.Name, $"{fe.Name} - {fe.MonthlyTotal}"));
                        i++;
                    }
                }
            }

            return optList;
        }


    }
}
