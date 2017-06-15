﻿// Decompiled with JetBrains decompiler
// Type: System.IO.UnmanagedMemoryStreamWrapper
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 2A55D587-43EC-479C-866B-425E85A3236D
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace System.IO
{
  internal sealed class UnmanagedMemoryStreamWrapper : MemoryStream
  {
    private UnmanagedMemoryStream _unmanagedStream;

    public override bool CanRead
    {
      get
      {
        return this._unmanagedStream.CanRead;
      }
    }

    public override bool CanSeek
    {
      get
      {
        return this._unmanagedStream.CanSeek;
      }
    }

    public override bool CanWrite
    {
      get
      {
        return this._unmanagedStream.CanWrite;
      }
    }

    public override int Capacity
    {
      get
      {
        return (int) this._unmanagedStream.Capacity;
      }
      set
      {
        throw new IOException(Environment.GetResourceString("IO.IO_FixedCapacity"));
      }
    }

    public override long Length
    {
      get
      {
        return this._unmanagedStream.Length;
      }
    }

    public override long Position
    {
      get
      {
        return this._unmanagedStream.Position;
      }
      set
      {
        this._unmanagedStream.Position = value;
      }
    }

    internal UnmanagedMemoryStreamWrapper(UnmanagedMemoryStream stream)
    {
      this._unmanagedStream = stream;
    }

    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing)
          return;
        this._unmanagedStream.Close();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    public override void Flush()
    {
      this._unmanagedStream.Flush();
    }

    public override byte[] GetBuffer()
    {
      throw new UnauthorizedAccessException(Environment.GetResourceString("UnauthorizedAccess_MemStreamBuffer"));
    }

    public override bool TryGetBuffer(out ArraySegment<byte> buffer)
    {
      buffer = new ArraySegment<byte>();
      return false;
    }

    public override int Read([In, Out] byte[] buffer, int offset, int count)
    {
      return this._unmanagedStream.Read(buffer, offset, count);
    }

    public override int ReadByte()
    {
      return this._unmanagedStream.ReadByte();
    }

    public override long Seek(long offset, SeekOrigin loc)
    {
      return this._unmanagedStream.Seek(offset, loc);
    }

    [SecuritySafeCritical]
    public override unsafe byte[] ToArray()
    {
      if (!this._unmanagedStream._isOpen)
        __Error.StreamIsClosed();
      if (!this._unmanagedStream.CanRead)
        __Error.ReadNotSupported();
      byte[] dest = new byte[this._unmanagedStream.Length];
      int destIndex = 0;
      byte* pointer = this._unmanagedStream.Pointer;
      int srcIndex = 0;
      int len = (int) this._unmanagedStream.Length;
      Buffer.Memcpy(dest, destIndex, pointer, srcIndex, len);
      return dest;
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      this._unmanagedStream.Write(buffer, offset, count);
    }

    public override void WriteByte(byte value)
    {
      this._unmanagedStream.WriteByte(value);
    }

    public override void WriteTo(Stream stream)
    {
      if (stream == null)
        throw new ArgumentNullException("stream", Environment.GetResourceString("ArgumentNull_Stream"));
      if (!this._unmanagedStream._isOpen)
        __Error.StreamIsClosed();
      if (!this.CanRead)
        __Error.ReadNotSupported();
      byte[] array = this.ToArray();
      stream.Write(array, 0, array.Length);
    }

    public override void SetLength(long value)
    {
      base.SetLength(value);
    }

    public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
    {
      if (destination == null)
        throw new ArgumentNullException("destination");
      if (bufferSize <= 0)
        throw new ArgumentOutOfRangeException("bufferSize", Environment.GetResourceString("ArgumentOutOfRange_NeedPosNum"));
      if (!this.CanRead && !this.CanWrite)
        throw new ObjectDisposedException((string) null, Environment.GetResourceString("ObjectDisposed_StreamClosed"));
      if (!destination.CanRead && !destination.CanWrite)
        throw new ObjectDisposedException("destination", Environment.GetResourceString("ObjectDisposed_StreamClosed"));
      if (!this.CanRead)
        throw new NotSupportedException(Environment.GetResourceString("NotSupported_UnreadableStream"));
      if (!destination.CanWrite)
        throw new NotSupportedException(Environment.GetResourceString("NotSupported_UnwritableStream"));
      return this._unmanagedStream.CopyToAsync(destination, bufferSize, cancellationToken);
    }

    public override Task FlushAsync(CancellationToken cancellationToken)
    {
      return this._unmanagedStream.FlushAsync(cancellationToken);
    }

    public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
      return this._unmanagedStream.ReadAsync(buffer, offset, count, cancellationToken);
    }

    public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
      return this._unmanagedStream.WriteAsync(buffer, offset, count, cancellationToken);
    }
  }
}
