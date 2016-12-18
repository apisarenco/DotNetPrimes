namespace DotNetPrimes {
	class Primes {
		private byte[] primes;

		public void SetNotPrime(int number) {
			var byteIndex = number >> 3;
			var setByte = primes[byteIndex];
			var bitIndex = (byteIndex << 3) ^ number;
			var bitShift = 8 - bitIndex - 1;
			primes[byteIndex] = (byte)(primes[byteIndex] & (0xFF ^ (1 << bitShift)));
		}

		public bool IsPrime(int number) {
			var byteIndex = number >> 3;
			if(byteIndex>=primes.Length) {
				return true;
			}
			var checkByte = primes[byteIndex];
			var bitIndex = (byteIndex << 3) ^ number;
			var bitShift = 8 - bitIndex - 1;
			var result = ((checkByte >> bitShift) & 1) == 1;
			return result;
		}

		public Primes(int maxPrime) {
			var totalBytes = (maxPrime >> 3) + 1;
			primes = new byte[totalBytes];
			for(int i=0; i<totalBytes; i++) {
				primes[i]=0xFF;
			}
			SetNotPrime(0);
			SetNotPrime(1);
			for(int i=2; i<=maxPrime; i++) {
				if(IsPrime(i)) {
					for(int j=i+i; j<=maxPrime; j+=i) {
						SetNotPrime(j);
					}
				}
			}
		}
	}
}