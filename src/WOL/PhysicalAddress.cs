#if SILVERLIGHT

// Other Frameworks have a System.Net.Networkinformation.PhysicalAddress
// No PhysicalAddress class in Silverlight, so we have to make our own.

namespace System.Net
{
    public class PhysicalAddress
    {
        public static readonly byte[] None = new byte[0];

        private byte[] _address;

        public PhysicalAddress(byte[] address)
        {
            if (address == null)
                _address = new byte[0];
            _address = address;
        }

        public byte[] GetAddressBytes()
        {
            byte[] arr = new byte[_address.Length];
            Buffer.BlockCopy(_address, 0, arr, 0, _address.Length);
            return arr;
        }

        public override bool Equals(object other)
        {
            var pa = other as PhysicalAddress;
            if (pa == null)
                return false;

            if (_address.Length != pa._address.Length)
                return false;

            for (int i = 0; i < _address.Length; i++)
                if (_address[i] != pa._address[i])
                    return false;
            return true;
        }
    }
}

#endif
