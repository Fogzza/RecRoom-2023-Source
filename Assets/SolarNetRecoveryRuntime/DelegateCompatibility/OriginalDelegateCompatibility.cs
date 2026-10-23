// Explicit recovery compatibility ownership, not an original Rec Room declaration.
// Isolates a proven ignored-input projection from Assembly-CSharp's strict metadata map.
using System;
using System.Collections.Generic;

namespace SolarNet.Recovery
{
    public static class OriginalDelegateCompatibility
    {
        public static Func<TArgument, TResult> IgnoreInput<TArgument, TResult>(Func<TResult> function)
        {
            if (function == null) throw new ArgumentNullException(nameof(function));
            return Cache<TArgument, TResult>.Get(function);
        }

        private static class Cache<TArgument, TResult>
        {
            private static readonly object Gate = new object();
            private static readonly Dictionary<Func<TResult>, Func<TArgument, TResult>> Wrappers =
                new Dictionary<Func<TResult>, Func<TArgument, TResult>>();

            internal static Func<TArgument, TResult> Get(Func<TResult> function)
            {
                lock (Gate)
                {
                    Func<TArgument, TResult> wrapper;
                    if (!Wrappers.TryGetValue(function, out wrapper))
                    {
                        var entry = new Entry(function);
                        wrapper = entry.Invoke;
                        Wrappers.Add(function, wrapper);
                    }
                    return wrapper;
                }
            }

            private sealed class Entry
            {
                private readonly Func<TResult> function;
                internal Entry(Func<TResult> function) { this.function = function; }
                internal TResult Invoke(TArgument ignored) { return function(); }
            }
        }
    }
}
