using System;

namespace DotNetPrimes {
	public class BigBinary {
		private int _size;
		private ushort[] _data;
		public BigBinary(int size) {
			//array should be of size = size / 16 + 1, or size>>4 + 1
			_size = size>>3 + 1;
			_data = new ushort[_size];
		}

		public ushort[] BinaryData {get { return _data; }}
		public int Size {get { return _size; }}

		public static BigBinary operator |(BigBinary b1, BigBinary b2) {
			var result = new BigBinary(Math.Max(b1.Size, b2.Size));
			for(int offset=1;offset<=result.Size; offset++) {
				ushort us1 = (b1.Size < offset) ? (ushort)0 : b1.BinaryData[b1.Size - offset];
				ushort us2 = (b2.Size < offset) ? (ushort)0 : b2.BinaryData[b2.Size - offset];
				result.BinaryData[result.Size - offset] = (ushort)(us1 | us2);
			}
			return result;
		}

		public static BigBinary operator &(BigBinary b1, BigBinary b2) {
			var result = new BigBinary(Math.Max(b1.Size, b2.Size));
			for(int offset=1;offset<=result.Size; offset++) {
				ushort us1 = (b1.Size < offset) ? (ushort)0 : b1.BinaryData[b1.Size - offset];
				ushort us2 = (b2.Size < offset) ? (ushort)0 : b2.BinaryData[b2.Size - offset];
				result.BinaryData[result.Size - offset] = (ushort)(us1 & us2);
			}
			return result;
		}

		public static BigBinary operator ^(BigBinary b1, BigBinary b2) {
			var result = new BigBinary(Math.Max(b1.Size, b2.Size));
			for(int offset=1;offset<=result.Size; offset++) {
				ushort us1 = (b1.Size < offset) ? (ushort)0 : b1.BinaryData[b1.Size - offset];
				ushort us2 = (b2.Size < offset) ? (ushort)0 : b2.BinaryData[b2.Size - offset];
				result.BinaryData[result.Size - offset] = (ushort)(us1 ^ us2);
			}
			return result;
		}

		public static BigBinary operator <<(BigBinary b1, int shift) {
			throw new NotImplementedException();
			var result = new BigBinary(b1.Size + shift / 4 + 1);
			for(int offset=1;offset<=result.Size; offset++) {
				ushort us1 = (b1.Size < offset) ? (ushort)0 : b1.BinaryData[b1.Size - offset];
			}
			return result;
		}
	}
}