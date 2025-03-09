namespace DiscountContext.Shared.Extensions;
public static class StringExtensions
{
    public static TEnum? ToEnum<TEnum>(this string value) where TEnum : struct, Enum
    {
        if (Enum.TryParse<TEnum>(value, true, out TEnum result))
            return result;

        return null;
    }

    public static bool TryToEnum<TEnum>(this string value, out TEnum result) where TEnum : struct, Enum
    {
        return Enum.TryParse(value, true, out result);
    }
}

