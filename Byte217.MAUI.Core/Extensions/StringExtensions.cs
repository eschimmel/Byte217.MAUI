namespace System
{
    public static class StringExtensions
    {
        public static string TrimLastCharacter(this string str)
        {
            ArgumentNullException.ThrowIfNull(str, nameof(str));

            if (str.Length > 0)
            {
                return str[..^1];
            }

            return str;
        }

        public static bool IsEndOfSentence(this string str)
        {
            ArgumentNullException.ThrowIfNull(str, nameof(str));

            str = str.TrimEnd();
            if (!string.IsNullOrWhiteSpace(str))
            {
                char lastCharacter = str.Last();
                return lastCharacter == '.' || lastCharacter == '?' || lastCharacter == '!';
            }

            return false;
        }

        public static bool IsLastCharacterComma(this string str)
        {
            ArgumentNullException.ThrowIfNull(str, nameof(str));

            str = str.TrimEnd();
            if (!string.IsNullOrWhiteSpace(str))
            {
                char lastCharacter = str.Last();
                return lastCharacter == ',';
            }

            return false;
        }

        public static string FirstCharacterToUpper(this string str)
        {
            ArgumentNullException.ThrowIfNull(str, nameof(str));

            if (!string.IsNullOrWhiteSpace(str))
            {
                if (str.Length == 1)
                {
                    return str.ToUpper();
                }

                return string.Concat(str[0].ToString().ToUpper(), str.AsSpan(1));
            }

            return str;
        }

        public static bool IsPunctuation(this string str)
        {
            ArgumentNullException.ThrowIfNull(str, nameof(str));

            if (!string.IsNullOrWhiteSpace(str))
            {
                return str == "." || str=="," || str == "?" || str == "!";
            }

            return false;
        }
    }
}
