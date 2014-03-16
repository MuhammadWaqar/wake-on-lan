using System.Net.NetworkInformation;
using System.Text;

#if FEATURE_CONTRACTS
using System.Diagnostics.Contracts;
#endif

namespace System.Net
{
    /// <summary>
    /// Enth�lt die R�ckgabewerte der ArpRequest.Send-Funktion.
    /// </summary>
    public class ArpRequestResult
    {
        /// <summary>Falls Fehler bei der Protokollanfrage auftreten, werden diese in dieser Eigenschaft abgelegt. Andernfalls null.</summary>
        public Exception Exception { get; private set; }

        /// <summary>Die aufgel�ste physikalische Adresse.</summary>
        public PhysicalAddress Address { get; private set; }

        /// <summary>Erstellt eine neue ArpRequestResult-Instanz</summary>
        /// <param name="address">Die physikalische Adresse</param>
        public ArpRequestResult(PhysicalAddress address)
        {
#if FEATURE_CONTRACTS
            Contract.Ensures(Exception == null);
            Contract.Ensures(Address == address);
#endif
            Exception = null;
            Address = address;
        }

        /// <summary>Erstellt eine neue ArpRequestResult-Instanz</summary>
        /// <param name="exception">Der aufgetretene Fehler</param>
        public ArpRequestResult(Exception exception)
        {
#if FEATURE_CONTRACTS
            Contract.Ensures(Exception == exception);
            Contract.Ensures(Address == null);
#endif
            Exception = exception;
            Address = null;
        }

        /// <summary>Konvertiert ARP-R�ckgabewerte in eine Zeichenfolge.</summary>
        public override string ToString()
        {
#if FEATURE_CONTRACTS
            Contract.Ensures(Contract.Result<string>() != null);
#endif
            var sb = new StringBuilder();
            if (Address == null)
                sb.Append("no address");
            else
            {
                sb.Append("address: ");
                sb.Append(Address);
            }
            sb.Append(", ");
            if (Exception == null)
                sb.Append("no exception");
            else
            {
                sb.Append("exception: ");
                sb.Append(Exception.Message);
            }
            return sb.ToString();
        }
    }
}
