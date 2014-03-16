﻿#if NET35

#if NET45
using System.Threading.Tasks;
#endif
#if FEATURE_CONTRACTS
using System.Diagnostics.Contracts;
#endif

using System.Net.NetworkInformation;

namespace System.Net
{
    /// <summary>Stellt Erweiterungsmethoden für das Senden von Wake-On-LAN-Signalen bereit.</summary>
    public static class IPAddressExtensions
    {
        private const int DefaultWolPort = 7;
        #region Wol

        /// <summary>
        /// Sendet ein Wake-On-LAN-Signal an einen Client.
        /// </summary>
        /// <param name="target">die Ziel-IPAddress</param>
        /// <param name="mac0">Erstes MAC-Adress-Byte.</param>
        /// <param name="mac1">Zweites MAC-Adress-Byte.</param>
        /// <param name="mac2">Drittes MAC-Adress-Byte.</param>
        /// <param name="mac3">Viertes MAC-Adress-Byte.</param>
        /// <param name="mac4">Fünftes MAC-Adress-Byte.</param>
        /// <param name="mac5">Sechstes MAC-Adress-Byte.</param>
        /// <param name="port">der Port, an den das Signal gesendet wird</param>
        /// <exception cref="System.Net.Sockets.SocketException">Fehler beim Zugriff auf den Socket. Weitere Informationen finden Sie im Abschnitt "Hinweise".</exception>
        /// <returns />
        public static void SendWol(this IPAddress target, byte mac0, byte mac1, byte mac2, byte mac3, byte mac4, byte mac5, int port)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(target != null);
            Contract.Requires<ArgumentException>(port >= 0);
            Contract.Requires<ArgumentException>(port < 65535);
#endif
            Net.SendWol.Send(new IPEndPoint(target, port), mac0, mac1, mac2, mac3, mac4, mac5);
        }

        /// <summary>
        /// Sendet ein Wake-On-LAN-Signal an einen Client.
        /// </summary>
        /// <param name="target">die Ziel-IPAddress</param>
        /// <param name="mac0">Erstes MAC-Adress-Byte.</param>
        /// <param name="mac1">Zweites MAC-Adress-Byte.</param>
        /// <param name="mac2">Drittes MAC-Adress-Byte.</param>
        /// <param name="mac3">Viertes MAC-Adress-Byte.</param>
        /// <param name="mac4">Fünftes MAC-Adress-Byte.</param>
        /// <param name="mac5">Sechstes MAC-Adress-Byte.</param>
        /// <exception cref="System.Net.Sockets.SocketException">Fehler beim Zugriff auf den Socket. Weitere Informationen finden Sie im Abschnitt "Hinweise".</exception>
        /// <returns />
        public static void SendWol(this IPAddress target, byte mac0, byte mac1, byte mac2, byte mac3, byte mac4, byte mac5)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(target != null);
            Contract.Requires<ArgumentException>(DefaultWolPort >= 0);
#endif
            Net.SendWol.Send(new IPEndPoint(target, DefaultWolPort), mac0, mac1, mac2, mac3, mac4, mac5);
        }

        /// <summary>
        /// Sendet ein Wake-On-LAN-Signal an einen Client.
        /// </summary>
        /// <param name="target">die Ziel-IPAddress</param>
        /// <param name="macAddress">Die MAC-Adresse des Clients.</param>
        /// <param name="port">der Port, an den das Signal gesendet wird</param>
        /// <exception cref="System.ArgumentException">Die Länge der System.Byte-Array macAddress ist nicht 6.</exception>
        /// <exception cref="System.ArgumentNullException">macAddress ist null.</exception>
        /// <exception cref="System.Net.Sockets.SocketException">Fehler beim Zugriff auf den Socket. Weitere Informationen finden Sie im Abschnitt "Hinweise".</exception>
        /// <returns />
        public static void SendWol(this IPAddress target, byte[] macAddress, int port)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(target != null);
            Contract.Requires<ArgumentNullException>(macAddress != null);
            Contract.Requires<ArgumentException>(macAddress.Length == 6);
            Contract.Requires<ArgumentException>(port >= 0);
            Contract.Requires<ArgumentException>(port < 65535);
#endif
            Net.SendWol.Send(new IPEndPoint(target, port), macAddress);
        }

        /// <summary>
        /// Sendet ein Wake-On-LAN-Signal an einen Client.
        /// </summary>
        /// <param name="target">die Ziel-IPAddress</param>
        /// <param name="macAddress">Die MAC-Adresse des Clients.</param>
        /// <param name="port">der Port, an den das Signal gesendet wird</param>
        /// <param name="password">Das SecureOn-Passwort des Clients.</param>
        /// <exception cref="System.ArgumentException">Die Länge der System.Byte-Array macAddress ist nicht 6.</exception>
        /// <exception cref="System.ArgumentNullException">macAddress ist null.</exception>
        /// <exception cref="System.ArgumentNullException">password ist null.</exception>
        /// <exception cref="System.Net.Sockets.SocketException">Fehler beim Zugriff auf den Socket. Weitere Informationen finden Sie im Abschnitt "Hinweise".</exception>
        /// <returns />
        public static void SendWol(this IPAddress target, byte[] macAddress, int port, SecureOnPassword password)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(target != null);
            Contract.Requires<ArgumentNullException>(macAddress != null);
            Contract.Requires<ArgumentException>(macAddress.Length == 6);
            Contract.Requires<ArgumentException>(port >= 0);
            Contract.Requires<ArgumentException>(port < 65535);
            Contract.Requires<ArgumentNullException>(password != null);
#endif
            Net.SendWol.Send(new IPEndPoint(target, port), macAddress, password);
        }

        /// <summary>
        /// Sendet ein Wake-On-LAN-Signal an einen Client.
        /// </summary>
        /// <param name="target">die Ziel-IPAddress</param>
        /// <param name="macAddress">Die MAC-Adresse des Clients.</param>
        ///<exception cref="System.ArgumentException">Die Länge der System.Byte-Array macAddress ist nicht 6.</exception>
        /// <exception cref="System.ArgumentNullException">macAddress ist null.</exception>
        /// <exception cref="System.Net.Sockets.SocketException">Fehler beim Zugriff auf den Socket. Weitere Informationen finden Sie im Abschnitt "Hinweise".</exception>
        /// <returns />
        public static void SendWol(this IPAddress target, byte[] macAddress)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(target != null);
            Contract.Requires<ArgumentNullException>(macAddress != null);
            Contract.Requires<ArgumentException>(macAddress.Length == 6);
#endif
            Net.SendWol.Send(new IPEndPoint(target, DefaultWolPort), macAddress);
        }

        /// <summary>
        /// Sendet ein Wake-On-LAN-Signal an einen Client.
        /// </summary>
        /// <param name="target">die Ziel-IPAddress</param>
        /// <param name="macAddress">Die MAC-Adresse des Clients.</param>
        /// <param name="password">Das SecureOn-Passwort des Clients.</param>
        /// <exception cref="System.ArgumentException">Die Länge der System.Byte-Array macAddress ist nicht 6.</exception>
        /// <exception cref="System.ArgumentNullException">macAddress ist null.</exception>
        /// <exception cref="System.ArgumentNullException">password ist null.</exception>
        /// <exception cref="System.Net.Sockets.SocketException">Fehler beim Zugriff auf den Socket. Weitere Informationen finden Sie im Abschnitt "Hinweise".</exception>
        /// <returns />
        public static void SendWol(this IPAddress target, byte[] macAddress, SecureOnPassword password)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(target != null);
            Contract.Requires<ArgumentNullException>(macAddress != null);
            Contract.Requires<ArgumentException>(macAddress.Length == 6);
            Contract.Requires<ArgumentNullException>(password != null);
#endif
            Net.SendWol.Send(new IPEndPoint(target, DefaultWolPort), macAddress, password);
        }

        /// <summary>
        /// Sendet ein Wake-On-LAN-Signal an einen Client.
        /// </summary>
        /// <param name="target">die Ziel-IPAddress</param>
        /// <param name="macAddress">Die MAC-Adresse des Clients.</param>
        ///<exception cref="System.ArgumentException">Die Länge der System.Byte-Array macAddress ist nicht 6.</exception>
        /// <exception cref="System.ArgumentNullException">macAddress ist null.</exception>
        /// <exception cref="System.Net.Sockets.SocketException">Fehler beim Zugriff auf den Socket. Weitere Informationen finden Sie im Abschnitt "Hinweise".</exception>
        /// <returns />
        public static void SendWol(this IPAddress target, PhysicalAddress macAddress)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(target != null);
            Contract.Requires<ArgumentNullException>(macAddress != null);
#endif
            Net.SendWol.Send(new IPEndPoint(target, DefaultWolPort), macAddress);
        }

        /// <summary>
        /// Sendet ein Wake-On-LAN-Signal an einen Client.
        /// </summary>
        /// <param name="target">die Ziel-IPAddress</param>
        /// <param name="macAddress">Die MAC-Adresse des Clients.</param>
        /// <param name="password">Das SecureOn-Passwort des Clients.</param>
        /// <exception cref="System.ArgumentException">Die Länge der System.Byte-Array macAddress ist nicht 6.</exception>
        /// <exception cref="System.ArgumentNullException">macAddress ist null.</exception>
        /// <exception cref="System.ArgumentNullException">password ist null.</exception>
        /// <exception cref="System.Net.Sockets.SocketException">Fehler beim Zugriff auf den Socket. Weitere Informationen finden Sie im Abschnitt "Hinweise".</exception>
        /// <returns />
        public static void SendWol(this IPAddress target, PhysicalAddress macAddress, SecureOnPassword password)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(target != null);
            Contract.Requires<ArgumentNullException>(macAddress != null);
            Contract.Requires<ArgumentNullException>(password != null);
#endif
            Net.SendWol.Send(new IPEndPoint(target, DefaultWolPort), macAddress, password);
        }

        #endregion
        #region ARP

        /// <summary>
        /// Sendet eine Anfrage über das ARP-Protokoll, um eine IP-Adresse in die Physikalische Adresse aufzulösen. Falls sich die physikalische Adresse bereits im Cache des Hosts befindet, wird diese zurückgegeben.
        /// </summary>
        /// <param name="destination">Die Ziel-IPAdress</param>
        /// <returns>Eine <see cref="T:System.Net.ArpRequestResult">ArpRequestResult</see>-Instanz, welche die Ergebnisse der Anfrage enthält.</returns>
        public static ArpRequestResult SendArpRequest(this IPAddress destination)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(destination != null);
#endif
            return ArpRequest.Send(destination);
        }

        #endregion
        #region TAP

#if NET45
        #region Wol

        /// <summary>
        /// Sendet ein Wake-On-LAN-Signal an einen Client.
        /// </summary>
        /// <param name="target">die Ziel-IPAddress</param>
        /// <param name="mac0">Erstes MAC-Adress-Byte.</param>
        /// <param name="mac1">Zweites MAC-Adress-Byte.</param>
        /// <param name="mac2">Drittes MAC-Adress-Byte.</param>
        /// <param name="mac3">Viertes MAC-Adress-Byte.</param>
        /// <param name="mac4">Fünftes MAC-Adress-Byte.</param>
        /// <param name="mac5">Sechstes MAC-Adress-Byte.</param>
        /// <param name="port">der Port, an den das Signal gesendet wird</param>
        /// <returns>Ein asynchroner Task, welcher ein Wake-On-LAN-Signal an einen Client sendet.</returns>
        public static Task SendWolAsync(this IPAddress target, byte mac0, byte mac1, byte mac2, byte mac3, byte mac4, byte mac5, int port)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(target != null);
            Contract.Requires<ArgumentException>(port >= 0);
            Contract.Requires<ArgumentException>(port < 65535);
#endif
            return Net.SendWol.SendAsync(new IPEndPoint(target, port), mac0, mac1, mac2, mac3, mac4, mac5);
        }

        /// <summary>
        /// Sendet ein Wake-On-LAN-Signal an einen Client.
        /// </summary>
        /// <param name="target">die Ziel-IPAddress</param>
        /// <param name="mac0">Erstes MAC-Adress-Byte.</param>
        /// <param name="mac1">Zweites MAC-Adress-Byte.</param>
        /// <param name="mac2">Drittes MAC-Adress-Byte.</param>
        /// <param name="mac3">Viertes MAC-Adress-Byte.</param>
        /// <param name="mac4">Fünftes MAC-Adress-Byte.</param>
        /// <param name="mac5">Sechstes MAC-Adress-Byte.</param>
        /// <returns>Ein asynchroner Task, welcher ein Wake-On-LAN-Signal an einen Client sendet.</returns>
        public static Task SendWolAsync(this IPAddress target, byte mac0, byte mac1, byte mac2, byte mac3, byte mac4, byte mac5)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(target != null);
            Contract.Requires<ArgumentException>(DefaultWolPort >= 0);
            Contract.Requires<ArgumentException>(DefaultWolPort < 65535);
#endif
            return Net.SendWol.SendAsync(new IPEndPoint(target, DefaultWolPort), mac0, mac1, mac2, mac3, mac4, mac5);
        }

        /// <summary>
        /// Sendet ein Wake-On-LAN-Signal an einen Client.
        /// </summary>
        /// <param name="target">der Hostname des Zielclients</param>
        /// <param name="macAddress">Die MAC-Adresse des Clients.</param>
        /// <param name="port">der Port, an den das Signal gesendet wird</param>
        ///<exception cref="System.ArgumentException">Die Länge der System.Byte-Array macAddress ist nicht 6.</exception>
        /// <exception cref="System.ArgumentNullException">macAddress ist null.</exception>
        /// <returns>Ein asynchroner Task, welcher ein Wake-On-LAN-Signal an einen Client sendet.</returns>
        public static Task SendWolAsync(this IPAddress target, byte[] macAddress, int port)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(target != null);
            Contract.Requires<ArgumentNullException>(macAddress != null);
            Contract.Requires<ArgumentException>(macAddress.Length == 6);
            Contract.Requires<ArgumentException>(port >= 0);
            Contract.Requires<ArgumentException>(port < 65535);
#endif
            return Net.SendWol.SendAsync(new IPEndPoint(target, port), macAddress);
        }

        /// <summary>
        /// Sendet ein Wake-On-LAN-Signal an einen Client.
        /// </summary>
        /// <param name="target">der Hostname des Zielclients</param>
        /// <param name="macAddress">Die MAC-Adresse des Clients.</param>
        /// <param name="port">der Port, an den das Signal gesendet wird</param>
        /// <param name="password">Das SecureOn-Passwort des Clients.</param>
        ///<exception cref="System.ArgumentException">Die Länge der System.Byte-Array macAddress ist nicht 6.</exception>
        /// <exception cref="System.ArgumentNullException">macAddress ist null.</exception>
        /// <exception cref="System.ArgumentNullException">password ist null.</exception>
        /// <returns>Ein asynchroner Task, welcher ein Wake-On-LAN-Signal an einen Client sendet.</returns>
        public static Task SendWolAsync(this IPAddress target, byte[] macAddress, int port, SecureOnPassword password)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(target != null);
            Contract.Requires<ArgumentNullException>(macAddress != null);
            Contract.Requires<ArgumentException>(macAddress.Length == 6);
            Contract.Requires<ArgumentNullException>(password != null);
#endif
            return Net.SendWol.SendAsync(new IPEndPoint(target, port), macAddress, password);
        }

        /// <summary>
        /// Sendet ein Wake-On-LAN-Signal an einen Client.
        /// </summary>
        /// <param name="target">der Hostname des Zielclients</param>
        /// <param name="macAddress">Die MAC-Adresse des Clients.</param>
        ///<exception cref="System.ArgumentException">Die Länge der System.Byte-Array macAddress ist nicht 6.</exception>
        /// <exception cref="System.ArgumentNullException">macAddress ist null.</exception>
        /// <returns>Ein asynchroner Task, welcher ein Wake-On-LAN-Signal an einen Client sendet.</returns>
        public static Task SendWolAsync(this IPAddress target, byte[] macAddress)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(target != null);
            Contract.Requires<ArgumentNullException>(macAddress != null);
            Contract.Requires<ArgumentException>(macAddress.Length == 6);
#endif
            return Net.SendWol.SendAsync(new IPEndPoint(target, DefaultWolPort), macAddress);
        }

        /// <summary>
        /// Sendet ein Wake-On-LAN-Signal an einen Client.
        /// </summary>
        /// <param name="target">der Hostname des Zielclients</param>
        /// <param name="macAddress">Die MAC-Adresse des Clients.</param>
        /// <param name="password">Das SecureOn-Passwort des Clients.</param>
        /// <exception cref="System.ArgumentException">Die Länge der System.Byte-Array macAddress ist nicht 6.</exception>
        /// <exception cref="System.ArgumentNullException">macAddress ist null.</exception>
        /// <exception cref="System.ArgumentNullException">password ist null.</exception>
        /// <returns>Ein asynchroner Task, welcher ein Wake-On-LAN-Signal an einen Client sendet.</returns>
        public static Task SendWolAsync(this IPAddress target, byte[] macAddress, SecureOnPassword password)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(target != null);
            Contract.Requires<ArgumentNullException>(macAddress != null);
            Contract.Requires<ArgumentException>(macAddress.Length == 6);
            Contract.Requires<ArgumentNullException>(password != null);
#endif
            return Net.SendWol.SendAsync(new IPEndPoint(target, DefaultWolPort), macAddress, password);
        }

        /// <summary>
        /// Sendet ein Wake-On-LAN-Signal an einen Client.
        /// </summary>
        /// <param name="target">der Hostname des Zielclients</param>
        /// <param name="macAddress">Die MAC-Adresse des Clients.</param>
        ///<exception cref="System.ArgumentException">Die Länge der System.Byte-Array macAddress ist nicht 6.</exception>
        /// <exception cref="System.ArgumentNullException">macAddress ist null.</exception>
        /// <returns>Ein asynchroner Task, welcher ein Wake-On-LAN-Signal an einen Client sendet.</returns>
        public static Task SendWolAsync(this IPAddress target, PhysicalAddress macAddress)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(target != null);
            Contract.Requires<ArgumentNullException>(macAddress != null);
#endif
            return Net.SendWol.SendAsync(new IPEndPoint(target, DefaultWolPort), macAddress);
        }

        /// <summary>
        /// Sendet ein Wake-On-LAN-Signal an einen Client.
        /// </summary>
        /// <param name="target">der Hostname des Zielclients</param>
        /// <param name="macAddress">Die MAC-Adresse des Clients.</param>
        /// <param name="password">Das SecureOn-Passwort des Clients.</param>
        /// <exception cref="System.ArgumentException">Die Länge der System.Byte-Array macAddress ist nicht 6.</exception>
        /// <exception cref="System.ArgumentNullException">macAddress ist null.</exception>
        /// <exception cref="System.ArgumentNullException">password ist null.</exception>
        /// <returns>Ein asynchroner Task, welcher ein Wake-On-LAN-Signal an einen Client sendet.</returns>
        public static Task SendWolAsync(this IPAddress target, PhysicalAddress macAddress, SecureOnPassword password)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(target != null);
            Contract.Requires<ArgumentNullException>(macAddress != null);
            Contract.Requires<ArgumentNullException>(password != null);
#endif
            return Net.SendWol.SendAsync(new IPEndPoint(target, DefaultWolPort), macAddress, password);
        }

        #endregion

        #region ARP

        /// <summary>
        /// Sendet eine Anfrage über das ARP-Protokoll, um eine IP-Adresse in die Physikalische Adresse aufzulösen. Falls sich die physikalische Adresse bereits im Cache des Hosts befindet, wird diese zurückgegeben.
        /// </summary>
        /// <param name="destination">Die Ziel-IPAdress</param>
        /// <returns>Ein asynchroner Task, welcher einen ARP-Request sendet.</returns>
        public static Task<ArpRequestResult> SendArpRequestAsync(this IPAddress destination)
        {
#if FEATURE_CONTRACTS
            Contract.Requires<ArgumentNullException>(destination != null);
#endif
            return ArpRequest.SendAsync(destination);
        }

        #endregion

#endif
        #endregion
    }
}
#endif
