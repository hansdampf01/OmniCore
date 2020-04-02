﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Nito.AsyncEx;
using OmniCore.Model.Interfaces.Common;
using OmniCore.Model.Interfaces.Services;
using OmniCore.Model.Interfaces.Services.Internal;

namespace OmniCore.Services
{
    public class CoreRepositoryService : CoreServiceBase, ICoreRepositoryService
    {
        private readonly ICoreContainer<IServerResolvable> ServerContainer;
        private readonly ICoreApplicationFunctions CoreApplicationFunctions;
        private readonly AsyncReaderWriterLock ContextLock;

        public CoreRepositoryService(ICoreContainer<IServerResolvable> serverContainer,
            ICoreApplicationFunctions coreApplicationFunctions)
        {
            ServerContainer = serverContainer;
            CoreApplicationFunctions = coreApplicationFunctions;
            ContextLock = new AsyncReaderWriterLock();
        }

        protected override async Task OnStart(CancellationToken cancellationToken)
        {
            using var context = await GetWriterContext(cancellationToken);
            #if DEBUG
            await context.InitializeDatabase(cancellationToken, true);
            #else
            await context.InitializeDatabase(cancellationToken, false);
            #endif
        }

        protected override Task OnStop(CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            return Task.CompletedTask;
        }

        protected override Task OnPause(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected override Task OnResume(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task Import(string importPath, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Restore(string backupPath, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Backup(string backupPath, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IRepositoryContext> GetReaderContext(CancellationToken cancellationToken)
        {
            var rwLock = await ContextLock.ReaderLockAsync(cancellationToken);
            var context = ServerContainer.Get<IRepositoryContext>();
            context.SetLock(rwLock, true);
            return context;
        }

        public async Task<IRepositoryContextWriteable> GetWriterContext(CancellationToken cancellationToken)
        {
            var rwLock = await ContextLock.WriterLockAsync(cancellationToken);
            var context = ServerContainer.Get<IRepositoryContext>();
            context.SetLock(rwLock, false);
            return (IRepositoryContextWriteable)context;
        }
    }
}