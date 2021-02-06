using System;

namespace Dirt3TelemetryDisplay
{
    /// <summary>
    /// Lightweight byte data converter which can be created locally with no heap allocations.
    /// </summary>
    public readonly struct DataConverter
    {
        public const int FloatSize = 4;
        public const int Float2Size = 8;
        public const int Float3Size = 12;
        public const int Float4Size = 16;

        private readonly byte[] data;

        public DataConverter(byte[] data) => this.data = data;

        public float ToFloat(int index)
            => BitConverter.ToSingle(new ReadOnlySpan<byte>(data, index, FloatSize));

        public (float X, float Y) ToFloat2(int index)
            => (X: BitConverter.ToSingle(new ReadOnlySpan<byte>(data, index, FloatSize)),
                Y: BitConverter.ToSingle(new ReadOnlySpan<byte>(data, index + FloatSize, FloatSize)));

        public (float X, float Y, float Z) ToFloat3(int index)
            => (X: BitConverter.ToSingle(new ReadOnlySpan<byte>(data, index, FloatSize)),
                Y: BitConverter.ToSingle(new ReadOnlySpan<byte>(data, index + FloatSize, FloatSize)),
                Z: BitConverter.ToSingle(new ReadOnlySpan<byte>(data, index + Float2Size, FloatSize)));

        public (float X, float Y, float Z, float W) ToFloat4(int index)
            => (X: BitConverter.ToSingle(new ReadOnlySpan<byte>(data, index, FloatSize)),
                Y: BitConverter.ToSingle(new ReadOnlySpan<byte>(data, index + FloatSize, FloatSize)),
                Z: BitConverter.ToSingle(new ReadOnlySpan<byte>(data, index + Float2Size, FloatSize)),
                W: BitConverter.ToSingle(new ReadOnlySpan<byte>(data, index + Float3Size, FloatSize)));
    }
}
