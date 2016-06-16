// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Http;
using Microsoft.AspNetCore.Server.Kestrel.Infrastructure;

namespace Microsoft.AspNetCore.Server.Kestrel
{
    public class ServiceContext
    {
        public ServiceContext()
        {
        }

        public ServiceContext(ServiceContext context)
        {
            AppLifetime = context.AppLifetime;
            Log = context.Log;
            ThreadPool = context.ThreadPool;
            Memory = context.Memory;
            FrameFactory = context.FrameFactory;
            StartConnectionAsync = context.StartConnectionAsync;
            DateHeaderValueManager = context.DateHeaderValueManager;
            ServerOptions = context.ServerOptions;
        }

        public IApplicationLifetime AppLifetime { get; set; }

        public IKestrelTrace Log { get; set; }

        public IThreadPool ThreadPool { get; set; }

        public MemoryPool Memory { get; set; }

        public Func<IConnectionInformation, ServiceContext, Frame> FrameFactory { get; set; }

        public Func<IConnectionInformation, ServiceContext, Task<IConnectionContext>> StartConnectionAsync { get; set; }

        public DateHeaderValueManager DateHeaderValueManager { get; set; }

        public KestrelServerOptions ServerOptions { get; set; }
    }
}
