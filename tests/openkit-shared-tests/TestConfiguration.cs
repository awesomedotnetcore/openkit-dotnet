﻿using Dynatrace.OpenKit.Core.Configuration;
using Dynatrace.OpenKit.Protocol.SSL;

namespace Dynatrace.OpenKit
{
    public class TestConfiguration : AbstractConfiguration
    {
        public TestConfiguration()
            : base(OpenKitType.DYNATRACE, "", "", 0, "", new Providers.TestSessionIDProvider())
        {
            HTTPClientConfig = new HTTPClientConfiguration("", 0, "", new SSLStrictTrustManager());
            EnableCapture();
        }

        protected override string CreateBaseURL(string endpointURL, string monitorName)
        {
            return "";
        }
    }
}
