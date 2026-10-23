// This assembly is compiled against the existing projected SDK contract only.
// The isolated player receives the retained raw SDK instead, byte for byte.
using System;
using System.Runtime.CompilerServices;
using UnityEngine;
namespace Recovery.ProjectedGenericBinding
{
    public static class Consumer
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Type BaselineType() { return typeof(GameObject); }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Type ProjectedClosedType() { return typeof(HHOBPMOCKMJ<GameObject>); }
    }
}
