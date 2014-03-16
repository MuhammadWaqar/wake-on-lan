#if FEATURE_CONTRACTS
using System.Diagnostics.Contracts;
#endif

namespace System.Net
{
    /// <summary>
    /// Stellt ein SecureOn-Passwort bereit.
    /// </summary>
    [Serializable]
    public sealed class SecureOnPassword
    {
        private readonly byte[] _password;

        /// <summary>
        /// Initialisiert eine neue Instanz der System.Net.SecureOnPassword-Klasse mit dem angegebenen Passwort.
        /// </summary>
        /// <param name="password">Das Passwort als System.Byte-Array.</param>
        /// <exception cref="System.ArgumentNullException">password ist null.</exception>
        /// <exception cref="System.ArgumentException">Das System.Byte-Array password hat eine Länge ungleich 6.</exception>
        public SecureOnPassword(byte[] password)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(password != null);
            Contract.Requires<ArgumentException>(password.Length == 6, Localization.ArgumentExceptionInvalidPasswordLength);
            Contract.Ensures(_password == password);
            Contract.Ensures(_password.Length == 6);
#else
            if (password == null)
                throw new ArgumentNullException("password");
            if (password.Length != 6)
                throw new ArgumentException(Localization.ArgumentExceptionInvalidPasswordLength);
#endif
            _password = password;
        }

        /// <summary>Ruft die Passwortdaten des SecureOn-Passworts ab.</summary>
        public byte[] GetPasswordBytes()
        {
#if FEATURE_CONTRACTS
            Contract.Ensures(Contract.Result<byte[]>() != null);
            Contract.Ensures(Contract.Result<byte[]>().Length == _password.Length || Contract.Result<byte[]>().Length == 0);
#endif
            if (_password == null)
                return new byte[0];
            var buffer = new byte[_password.Length];
            Array.Copy(_password, buffer, 0);
            return buffer;
        }

        /// <summary>
        /// Initialisiert eine neue Instanz der System.Net.SecureOnPassword-Klasse mit dem angegebenen Passwort.
        /// </summary>
        /// <param name="password">Das Passwort als Zeichenfolge.</param>
        /// <remarks >Verwendet System.Text.Encoding.Default als Kodierung.</remarks>
        public SecureOnPassword(string password)
            : this(password, Text.Encoding.Default)
        { }


        /// <summary>
        /// Initialisiert eine neue Instanz der System.Net.SecureOnPassword-Klasse mit dem angegebenen Passwort.
        /// </summary>
        /// <param name="password">Das Passwort als Zeichenfolge.</param>
        /// <param name="encoding">Die System.Text.Encoding-Instanz für das Passwort.</param>
        /// <exception cref="System.ArgumentNullException">encoding ist null.</exception>
        /// <exception cref="System.ArgumentException">Das System.Byte-Array, welches aus dem Passwort resultiert, hat eine Länge größer 6.</exception>
        public SecureOnPassword(string password, Text.Encoding encoding)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(encoding != null);
            Contract.Requires<ArgumentNullException>(password != null);
#else
            if (encoding == null)
                throw new ArgumentNullException("encoding");
            if (password == null)
                throw new ArgumentNullException("password");
#endif

            if (string.IsNullOrEmpty(password))
                _password = new byte[6];

            var bytes = encoding.GetBytes(password);
            if (bytes.Length > 6)
                throw new ArgumentException(Localization.ArgumentExceptionInvalidPasswordLength);

            _password = new byte[6];
            for (int i = 0; i < bytes.Length; i++)
                _password[i] = bytes[i];
#if FEATURE_CONTRACTS
            Contract.Assume(_password.Length == 6);
#endif
            if (bytes.Length < 6)
            {
                for (int i = bytes.Length - 1; i < 6; i++)
                    _password[i] = 0x00;
            }
        }

        /// <summary>Konvertiert SecureOn-Passwörter in die Strichnotation.</summary>
        /// <returns>Eine Zeichenfolge mit einem SecureOn-Passwort in Strichnotation.</returns>
        public override string ToString()
        {
            return ToString("X2");
        }

        /// <summary>Konvertiert SecureOn-Passwörter in die Strichnotation.</summary>
        /// <returns>Eine Zeichenfolge mit einem SecureOn-Passwort in Strichnotation.</returns>
        private string ToString(string format)
        {
#if FEATURE_CONTRACTS
            Contract.Ensures(Contract.Result<string>() != null);
#endif
            var f = new string[6];
            for (int i = 0; i < f.Length; i++)
                f[i] = _password[i].ToString(format);
            return string.Join("-", f);
        }

        /// <summary>Konvertiert SecureOn-Passwörter in die Strichnotation.</summary>
        /// <returns>Eine Zeichenfolge mit einem SecureOn-Passwort in Strichnotation.</returns>
        public string ToString(IFormatProvider format)
        {
            var f = new string[6];
            for (int i = 0; i < f.Length; i++)
                f[i] = _password[i].ToString(format);
            return string.Join("-", f);
        }

    }
}
