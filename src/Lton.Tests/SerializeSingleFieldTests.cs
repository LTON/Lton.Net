using System;
using Lton.Tests.TestClasses;
using Xunit;

namespace Lton.Tests
{
    public class SerializeSingleFieldTests
    {
        private static string Serialize<T>(T value)
        {
            return new LtonSerializer().Serialize(new SingleValue<T>{Value = value});
        }

        private static string SerializeNullable<T>(T value) where T : struct
        {
            return new LtonSerializer().Serialize(new SingleValue<T?>{Value = value});
            
        }

        [Fact]
        public void Byte()
        {
            var actual = Serialize((byte) 42);
            Assert.Equal("#Value=42B#", actual);
        }

        [Fact]
        public void SByte()
        {
            var actual = Serialize((sbyte) 42);
            Assert.Equal("#Value=42SB#", actual);
        }

        [Fact]
        public void Int16()
        {
            var actual = Serialize((short) 42);
            Assert.Equal("#Value=42S#", actual);
        }

        [Fact]
        public void UInt16()
        {
            var actual = Serialize((ushort) 42);
            Assert.Equal("#Value=42US#", actual);
        }

        [Fact]
        public void Int32()
        {
            var actual = Serialize(42);
            Assert.Equal("#Value=42#", actual);
        }

        [Fact]
        public void UInt32()
        {
            var actual = Serialize(42U);
            Assert.Equal("#Value=42U#", actual);
        }

        [Fact]
        public void Int64()
        {
            var actual = Serialize(42L);
            Assert.Equal("#Value=42L#", actual);
        }

        [Fact]
        public void UInt64()
        {
            var actual = Serialize(42UL);
            Assert.Equal("#Value=42UL#", actual);
        }

        [Fact]
        public void Float()
        {
            var actual = Serialize(42F);
            Assert.Equal("#Value=42F#", actual);
        }

        [Fact]
        public void Double()
        {
            var actual = Serialize(42D);
            Assert.Equal("#Value=42D#", actual);
        }

        [Fact]
        public void DateTime()
        {
            var date = new DateTime(1969, 10, 29, 22, 30, 0);
            var actual = Serialize(date);
            var expected = "/Value=" + date.ToString("O") + "/";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DateTimeOffset()
        {
            var date = new DateTimeOffset(new DateTime(1969, 10, 29, 22, 30, 0), TimeSpan.Zero);
            var actual = Serialize(date);
            var expected = "/Value=" + date.ToString("O") + "/";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NullableByte()
        {
            var actual = SerializeNullable((byte) 42);
            Assert.Equal("#Value=42B#", actual);
        }

        [Fact]
        public void NullableSByte()
        {
            var actual = SerializeNullable((sbyte) 42);
            Assert.Equal("#Value=42SB#", actual);
        }

        [Fact]
        public void NullableInt16()
        {
            var actual = SerializeNullable((short) 42);
            Assert.Equal("#Value=42S#", actual);
        }

        [Fact]
        public void NullableUInt16()
        {
            var actual = SerializeNullable((ushort) 42);
            Assert.Equal("#Value=42US#", actual);
        }

        [Fact]
        public void NullableInt32()
        {
            var actual = SerializeNullable(42);
            Assert.Equal("#Value=42#", actual);
        }

        [Fact]
        public void NullableUInt32()
        {
            var actual = SerializeNullable(42U);
            Assert.Equal("#Value=42U#", actual);
        }

        [Fact]
        public void NullableInt64()
        {
            var actual = SerializeNullable(42L);
            Assert.Equal("#Value=42L#", actual);
        }

        [Fact]
        public void NullableUInt64()
        {
            var actual = SerializeNullable(42UL);
            Assert.Equal("#Value=42UL#", actual);
        }

        [Fact]
        public void NullableFloat()
        {
            var actual = SerializeNullable(42F);
            Assert.Equal("#Value=42F#", actual);
        }

        [Fact]
        public void NullableDouble()
        {
            var actual = SerializeNullable(42D);
            Assert.Equal("#Value=42D#", actual);
        }

        [Fact]
        public void NullableDateTime()
        {
            var date = new DateTime(1969, 10, 29, 22, 30, 0);
            var actual = SerializeNullable(date);
            var expected = "/Value=" + date.ToString("O") + "/";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NullableDateTimeOffset()
        {
            var date = new DateTimeOffset(new DateTime(1969, 10, 29, 22, 30, 0), TimeSpan.Zero);
            var actual = SerializeNullable(date);
            var expected = "/Value=" + date.ToString("O") + "/";
            Assert.Equal(expected, actual);
        }

    }
}
