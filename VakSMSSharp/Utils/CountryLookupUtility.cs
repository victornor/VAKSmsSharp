using VakSMSSharp.Enums;

namespace VakSMSSharp.Utils;

public static class CountryLookupUtility
{
    private static readonly Dictionary<PhoneCountry, string> CountryAPICode = new Dictionary<PhoneCountry, string>()
    {
        { PhoneCountry.ARGENTTINA, "ar" },
        { PhoneCountry.AUSTRIA, "at" },
        { PhoneCountry.AZERBAIJAN, "az" },
        { PhoneCountry.BANGALDESH, "bd" },
        { PhoneCountry.BULGARIA, "bg" },
        { PhoneCountry.CROATIA, "hr" },
        { PhoneCountry.CZECH_REPUBLIC, "cz" },
        { PhoneCountry.DENMARK, "dk" },
        { PhoneCountry.ESTONIA, "ee" },
        { PhoneCountry.FINLAND, "fi" },
        { PhoneCountry.FRANCE, "fr" },
        { PhoneCountry.GEORGIA, "ge" },
        { PhoneCountry.GERMANY, "de" },
        { PhoneCountry.GREECE, "gr" },
        { PhoneCountry.HONG_KONG, "hk" },
        { PhoneCountry.INDOENSIA, "id" },
        { PhoneCountry.ISRAEL, "il" },
        { PhoneCountry.KAZAKHSTAN, "kz" },
        { PhoneCountry.KENYA, "ke" },
        { PhoneCountry.KYRGYZSTAN, "kg" },
        { PhoneCountry.LAOS, "la" },
        { PhoneCountry.LATVIA, "lv" },
        { PhoneCountry.LITHUANIA, "lt" },
        { PhoneCountry.MALAYSIA, "my" },
        { PhoneCountry.MEXICO, "mx" },
        { PhoneCountry.UNITED_REPUBLICS, "md" },
        { PhoneCountry.MOROCCO, "ma" },
        { PhoneCountry.NETHERLANDS, "nl" },
        { PhoneCountry.PAKISTAN, "pk" },
        { PhoneCountry.PHILLIPINES, "ph" },
        { PhoneCountry.POLAND, "pl" },
        { PhoneCountry.PORTUGAL, "pt" },
        { PhoneCountry.ROMANIA, "ro" },
        { PhoneCountry.RUSSIA, "ru" },
        { PhoneCountry.SOUTH_AFRICA, "za" },
        { PhoneCountry.SPAIN, "es" },
        { PhoneCountry.SWEDEN, "se" },
        { PhoneCountry.TALJIKISTAN, "tj" },
        { PhoneCountry.TANZANIA, "tz" },
        { PhoneCountry.THAILAND, "th" },
        { PhoneCountry.UKRAINE, "ua" },
        { PhoneCountry.UNITED_KINGDOM, "gb"},
        { PhoneCountry.UNITED_STATES, "us" },
        { PhoneCountry.UZBEKISTAN, "uz" },
        { PhoneCountry.VIETNAM, "vn" },
        { PhoneCountry.ZIMBABWE, "zw" }
    };
    
    public static string GetCountryAPICode(PhoneCountry country)
        => CountryAPICode[country];
}