// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure;

namespace Microsoft.AspNetCore.Server.Kestrel.Internal.Http
{
    public static class RequestRejectionUtilities
    {
        public static void RejectRequest(RequestRejectionReason reason)
        {
            throw BadHttpRequestException.GetException(reason);
        }

        public static void RejectRequest(RequestRejectionReason reason, string value)
        {
            throw BadHttpRequestException.GetException(reason, value);
        }

        public static void RejectRequest(RequestRejectionReason reason, Span<byte> detail, bool logDetail, int maxDetailLength)
        {
            throw BadHttpRequestException.GetException(reason, logDetail ? detail.GetAsciiStringEscaped(maxDetailLength) : string.Empty);
        }
    }
}
