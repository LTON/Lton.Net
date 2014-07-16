using Lton.Tests.TestClasses;
using Xunit;

namespace Lton.Tests
{
    public class SerializeStringTests
    {
        private static string Serialize(string value)
        {
            return new LtonSerializer().Serialize(new SingleString {Value = value});
        }

        [Fact]
        public void PlainString()
        {
            var actual = Serialize("Forty two");
            Assert.Equal("\"Value=Forty two\"", actual);
        }

        [Fact]
        public void StringWithQuotes()
        {
            var actual = Serialize("\"Forty two?\" said Arthur.");
            Assert.Equal("\"Value=\\\"Forty two?\\\" said Arthur.\"", actual);
        }

        [Fact]
        public void StringWithBackslash()
        {
            var actual = Serialize("C:\\Windows");
            Assert.Equal("\"Value=C:\\\\Windows\"", actual);
        }

        [Fact]
        public void StringWithNewline()
        {
            var actual = Serialize("Line 1\nLine 2");
            Assert.Equal("\"Value=Line 1\\nLine 2\"", actual);
            
        }

        [Fact]
        public void StringWithCarriageReturnNewline()
        {
            var actual = Serialize("Line 1\r\nLine 2");
            Assert.Equal("\"Value=Line 1\\r\\nLine 2\"", actual);
            
        }
    }
}