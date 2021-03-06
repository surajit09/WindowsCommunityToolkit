// ******************************************************************
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THE CODE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE CODE OR THE USE OR OTHER DEALINGS IN THE CODE.
// ******************************************************************

using System;
using System.Collections.Generic;

namespace Microsoft.Toolkit.Win32.UI.Controls.Test.WebView.Shared
{
    internal class UriHostEqualityComparer : IEqualityComparer<Uri>
    {
        private UriHostEqualityComparer()
        {
        }

        internal static UriHostEqualityComparer Default => Nested.Instance;

        public bool Equals(Uri x, Uri y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;

            return Uri.Compare(x, y, UriComponents.Host, UriFormat.SafeUnescaped, StringComparison.OrdinalIgnoreCase) ==
                   0;
        }

        public int GetHashCode(Uri obj)
        {
            return obj.GetHashCode();
        }

        private class Nested
        {
            internal static readonly UriHostEqualityComparer Instance = new UriHostEqualityComparer();

            // Explict static ctor to tell compiler not to mark type as beforefieldinit
            static Nested() { }
        }
    }
}