// ***********************************************************************
// Copyright (c) 2014 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

#if !PORTABLE && !NETSTANDARD1_6
using System;
using System.Threading;
using UnityCompatNUnit.Framework.Internal;

namespace UnityCompatNUnit.Framework
{
    /// <summary>
    /// Marks a test that must run in a particular threading apartment state, causing it
    /// to run in a separate thread if necessary.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = false, Inherited = true)]
    public class ApartmentAttribute : PropertyAttribute
    {
        /// <summary>
        /// Construct an ApartmentAttribute
        /// </summary>
        /// <param name="apartmentState">The apartment state that this test must be run under. You must pass in a valid apartment state.</param>
        public ApartmentAttribute(ApartmentState apartmentState)
        {
            Guard.ArgumentValid(apartmentState != ApartmentState.Unknown, "must be STA or MTA", "apartmentState");
            Properties.Add(PropertyNames.ApartmentState, apartmentState);
        }
    }
}
#endif
