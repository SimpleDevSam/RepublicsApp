using System;
using System.Linq;
using System.Reflection;

public static class GenericMapper
{
    public static void MapNonNullProperties<TSource, TDestination>(TSource source, TDestination destination)
    {
        if (source == null || destination == null)
            throw new ArgumentNullException(source == null ? nameof(source) : nameof(destination));

        var sourceProperties = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var destinationProperties = typeof(TDestination).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var sourceProp in sourceProperties)
        {
            if (!sourceProp.CanRead)
                continue;

            var sourceValue = sourceProp.GetValue(source);
            if (sourceValue == null)
                continue;

            var destProp = destinationProperties.FirstOrDefault(dp =>
                dp.Name == sourceProp.Name &&
                dp.CanWrite &&
                dp.PropertyType.IsAssignableFrom(sourceProp.PropertyType));

            if (destProp != null)
            {
                if ((sourceProp.PropertyType == typeof(Guid) || sourceProp.PropertyType == typeof(Guid?)) &&
                    sourceValue is Guid guidValue && guidValue == Guid.Empty &&
                    destProp.PropertyType == typeof(Guid?))
                {
                    destProp.SetValue(destination, null);
                    continue;
                }

                var destType = destProp.PropertyType;
                if (destType.IsEnum || (Nullable.GetUnderlyingType(destType)?.IsEnum ?? false))
                {
                    var enumType = Nullable.GetUnderlyingType(destType) ?? destType;
                    object enumValue = null;
                    if (sourceValue is string s)
                    {
                        enumValue = Enum.Parse(enumType, s, true);
                    }
                    else if (sourceValue.GetType().IsEnum)
                    {
                        enumValue = sourceValue.GetType() == enumType
                            ? sourceValue
                            : Enum.Parse(enumType, sourceValue.ToString(), true);
                    }
                    else
                    {
                        try
                        {
                            var numericValue = Convert.ChangeType(sourceValue, Enum.GetUnderlyingType(enumType));
                            enumValue = Enum.ToObject(enumType, numericValue);
                        }
                        catch
                        {
                            enumValue = Enum.Parse(enumType, sourceValue.ToString(), true);
                        }
                    }
                    destProp.SetValue(destination, enumValue);
                    continue;
                }

                destProp.SetValue(destination, sourceValue);
            }
        }
    }
}
