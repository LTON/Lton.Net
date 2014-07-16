namespace Lton
{
    public static class LtonString
    {
        public static string Escape(object input)
        {
            return input == null ? "" : Escape((string) input);
        }
        public static string Escape(string input)
        {
            return input.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "\\r").Replace("\n", "\\n");
        }

        public static string Escape(char input)
        {
            switch (input)
            {
                case '\n':
                    return "\\n";
                case '\r':
                    return "\\r";
                default:
                    return new string(input, 1);
            }
        }
    }
}