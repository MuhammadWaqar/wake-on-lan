﻿namespace System.Net.Topology
{
    /// <summary>Provides options for doing network sibling calculations using a net mask.</summary>
    [Flags]
    public enum SiblingOptions
    {
        /// <summary>Do not include the broadcast or net address neither the addess passed to the method.</summary>
        ExcludeAll = 0,
        /// <summary>Include the addess passed to the method.</summary>
        IncludeSelf = 1,
        /// <summary>Include the addess passed to the method. Compliant to RFC 950 (2^n-2).</summary>
        ExcludeUnusable = IncludeSelf,
        /// <summary>Include the broadcast address.</summary>
        IncludeBroadcast = 2,
        /// <summary>Include the net address.</summary>
        IncludeNetworkIdentifier = 4,
        /// <summary>Include all addresses possible. RFC 1878 (2^n).</summary>
        IncludeAll = IncludeSelf | IncludeBroadcast | IncludeNetworkIdentifier
    }

    internal static class BitHelper
    {
#if NET40
        [Runtime.TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")] // as if NGen will ever compile this assembly ;)
#endif
#if NET45
        [Runtime.CompilerServices.MethodImpl(Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
#endif
        internal static bool IsOptionSet(SiblingOptions value, SiblingOptions testValue)
        {
            return (value & testValue) == testValue;
        }
    }
}
