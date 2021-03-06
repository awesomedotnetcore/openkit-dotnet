﻿//
// Copyright 2018 Dynatrace LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Dynatrace.OpenKit.API;
using Dynatrace.OpenKit.Core.Configuration;
using Dynatrace.OpenKit.Protocol;

namespace Dynatrace.OpenKit.Providers
{
    public class DefaultHTTPClientProvider : IHTTPClientProvider
    {
        private readonly ILogger logger;

        public DefaultHTTPClientProvider(ILogger logger)
        {
            this.logger = logger;
        }

        public IHTTPClient CreateClient(HTTPClientConfiguration configuration)
        {
#if NET40 || NET35
            return new HTTPClientWebClient(logger, configuration); // HttpClient is not availalbe in .NET 3.5 and 4.0
#else
            return new HTTPClientHttpClient(logger, configuration);
#endif
        }
    }
}
