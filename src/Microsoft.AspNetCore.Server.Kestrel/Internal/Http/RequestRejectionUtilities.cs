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

        public static void RejectRequest(RequestRejectionReason reason, string detail)
        {
            throw BadHttpRequestException.GetException(reason, detail);
        }

        // Do not move GetException() code into this method.
        // From https://github.com/aspnet/KestrelHttpServer/pull/1469#issuecomment-285161010:
        // Best exception pattern is call void method that only throws; and does no other work
        // (other than calling another function); unless it's a fairly simple 'new Exception'.
        // The Jit does 3 things with this when called:
        // - Decides never to inline it
        // - Moves call out of line to end of function as it is an exception
        // - Notes the function will never return so skips emitting post function prep(popping the stack back etc)
        public static void RejectRequest(RequestRejectionReason reason, Span<byte> detail, bool logDetail, int maxDetailChars)
        {
            throw GetException(reason, detail, logDetail, maxDetailChars);
        }

        private static BadHttpRequestException GetException(RequestRejectionReason reason, Span<byte> detail, bool logDetail, int maxDetailChars)
        {
            return BadHttpRequestException.GetException(reason, logDetail ? detail.GetAsciiStringEscaped(maxDetailChars) : string.Empty);
        }
    }
}
