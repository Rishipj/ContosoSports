﻿using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace Contoso.Apps.SportsLeague.Web.Helpers
{
    /// <summary>
    /// Helper methods for writing Application Insights Events.
    /// </summary>
    public sealed class TelemetryHelper
    {
        // All methods are static, so this can be private.
        private TelemetryHelper()
        { 
            
        }

        /// <summary>
        /// Writes the passed in Exception as a tracked exception in Application Insights.
        /// </summary>
        /// <param name="exc"></param>
        public static void TrackException(Exception exc)
        {
            var client = new TelemetryClient(TelemetryConfiguration.CreateDefault());
            client.TrackException(new Microsoft.ApplicationInsights.DataContracts.ExceptionTelemetry(exc));
        }

        /// <summary>
        /// Allows you to report events that can be searched and tracked in Application Insights.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="properties"></param>
        public static void TrackEvent(string eventName, Dictionary<string, string> properties)
        {
            var client = new TelemetryClient(TelemetryConfiguration.CreateDefault());
            client.TrackEvent(eventName, properties);
        }
    }
}