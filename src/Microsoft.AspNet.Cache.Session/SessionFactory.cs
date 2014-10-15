﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNet.HttpFeature;

namespace Microsoft.AspNet.Cache.Session
{
    public class SessionFactory : ISessionFactory
    {
        private readonly string _sessionKey;
        private readonly ISessionStore _store;
        private readonly TimeSpan _idleTimeout;
        private readonly Func<bool> _tryEstablishSession;

        public SessionFactory([NotNull] string sessionKey, [NotNull] ISessionStore store, TimeSpan idleTimeout, [NotNull] Func<bool> tryEstablishSession)
        {
            _sessionKey = sessionKey;
            _store = store;
            _idleTimeout = idleTimeout;
            _tryEstablishSession = tryEstablishSession;
        }

        public bool IsAvailable
        {
            get { return _store.IsAvailable; }
        }

        public ISession Create()
        {
            return _store.Create(_sessionKey, _idleTimeout, _tryEstablishSession);
        }
    }
}