using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Allweb.Core.Common.Contracts;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Allweb.Core.Common.Utils.Logging
{
    // https://github.com/serilog/serilog/wiki/2.x-Upgrade-Guide
    [Export(typeof(ILoggerService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LoggingService : ILoggerService
    {
        public ILogger ForContext(IEnumerable<ILogEventEnricher> enrichers)
        {
            return Log.Logger?.ForContext(enrichers);
        }

        public ILogger ForContext(string propertyName, object value, bool destructureObjects = false)
        {
            return Log.Logger?.ForContext(propertyName, value, destructureObjects);
        }

        public ILogger ForContext<TSource>()
        {
            return Log.Logger?.ForContext<TSource>();
        }

        public ILogger ForContext(Type source)
        {
            return Log.Logger?.ForContext(source);
        }

        public void Write(LogEvent logEvent)
        {
            Log.Logger?.Write(logEvent);
        }

        public void Write(LogEventLevel level, string messageTemplate, params object[] propertyValues)
        {
            Log.Logger?.Write(level, messageTemplate, propertyValues);
        }

        public void Write(LogEventLevel level, Exception exception, string messageTemplate,
            params object[] propertyValues)
        {
            Log.Logger?.Write(level, exception, messageTemplate, propertyValues);
        }

        public bool IsEnabled(LogEventLevel level)
        {
            return (Log.Logger != null && Log.Logger.IsEnabled(level));
        }

        public void Verbose(string messageTemplate, params object[] propertyValues)
        {
            Log.Logger?.Verbose(messageTemplate, propertyValues);
        }

        public void Verbose(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            Log.Logger?.Verbose(exception, messageTemplate, propertyValues);
        }

        public void Debug(string messageTemplate, params object[] propertyValues)
        {
            Log.Logger?.Debug(messageTemplate, propertyValues);
        }

        public void Debug(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            Log.Logger?.Debug(exception, messageTemplate, propertyValues);
        }

        public void Information(string messageTemplate, params object[] propertyValues)
        {
            Log.Logger?.Information(messageTemplate, propertyValues);
        }

        public void Information(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            Log.Logger?.Information(messageTemplate, propertyValues);
        }

        public void Warning(string messageTemplate, params object[] propertyValues)
        {
            Log.Logger?.Warning(messageTemplate, propertyValues);
        }

        public void Warning(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            Log.Logger?.Warning(exception, messageTemplate, propertyValues);
        }

        public void Error(string messageTemplate, params object[] propertyValues)
        {
            Log.Logger?.Error(messageTemplate, propertyValues);
        }

        public void Error(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            Log.Logger?.Error(exception, messageTemplate, propertyValues);
        }

        public void Fatal(string messageTemplate, params object[] propertyValues)
        {
            Log.Logger?.Fatal(messageTemplate, propertyValues);
        }

        public void Fatal(Exception exception, string messageTemplate, params object[] propertyValues)
        {
            Log.Logger?.Fatal(exception, messageTemplate, propertyValues);
        }

        public ILogger ForContext(ILogEventEnricher enricher)
        {
            return Log.Logger?.ForContext(enricher);
        }

        public void Write(LogEventLevel level, string messageTemplate)
        {
            Log.Logger?.Write(level, messageTemplate);
        }

        public void Write<T>(LogEventLevel level, string messageTemplate, T propertyValue)
        {
            Log.Logger?.Write<T>(level, messageTemplate, propertyValue);
        }

        public void Write<T0, T1>(LogEventLevel level, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            Log.Logger?.Write<T0, T1>(level, messageTemplate, propertyValue0, propertyValue1);
        }

        public void Write<T0, T1, T2>(LogEventLevel level, string messageTemplate, T0 propertyValue0,
            T1 propertyValue1, T2 propertyValue2)
        {
            Log.Logger?.Write<T0, T1, T2>(level, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Write(LogEventLevel level, Exception exception, string messageTemplate)
        {
            Log.Logger?.Write(level, exception, messageTemplate);
        }

        public void Write<T>(LogEventLevel level, Exception exception, string messageTemplate, T propertyValue)
        {
            Log.Logger?.Write<T>(level, exception, messageTemplate, propertyValue);
        }

        public void Write<T0, T1>(LogEventLevel level, Exception exception, string messageTemplate,
            T0 propertyValue0, T1 propertyValue1)
        {
            Log.Logger?.Write<T0, T1>(level, exception, messageTemplate, propertyValue0, propertyValue1);
        }

        public void Write<T0, T1, T2>(LogEventLevel level, Exception exception, string messageTemplate,
            T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            Log.Logger?.Write<T0, T1, T2>(level, exception, messageTemplate, propertyValue0, propertyValue1,
                propertyValue2);
        }

        public void Verbose(string messageTemplate)
        {
            Log.Logger?.Verbose(messageTemplate);
        }

        public void Verbose<T>(string messageTemplate, T propertyValue)
        {
            Log.Logger?.Verbose<T>(messageTemplate, propertyValue);
        }

        public void Verbose<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            Log.Logger?.Verbose<T0, T1>(messageTemplate, propertyValue0, propertyValue1);
        }

        public void Verbose<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1,
            T2 propertyValue2)
        {
            Log.Logger?.Verbose<T0, T1, T2>(messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Verbose(Exception exception, string messageTemplate)
        {
            Log.Logger?.Verbose(exception, messageTemplate);
        }

        public void Verbose<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            Log.Logger?.Verbose<T>(exception, messageTemplate, propertyValue);
        }

        public void Verbose<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            Log.Logger?.Verbose<T0, T1>(exception, messageTemplate, propertyValue0, propertyValue1);
        }

        public void Verbose<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0,
            T1 propertyValue1, T2 propertyValue2)
        {
            Log.Logger?.Verbose<T0, T1, T2>(exception, messageTemplate, propertyValue0, propertyValue1,
                propertyValue2);
        }

        public void Debug(string messageTemplate)
        {
            Log.Logger?.Debug(messageTemplate);
        }

        public void Debug<T>(string messageTemplate, T propertyValue)
        {
            Log.Logger?.Debug<T>(messageTemplate, propertyValue);
        }

        public void Debug<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            Log.Logger?.Debug<T0, T1>(messageTemplate, propertyValue0, propertyValue1);
        }

        public void Debug<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            Log.Logger?.Debug<T0, T1, T2>(messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Debug(Exception exception, string messageTemplate)
        {
            Log.Logger?.Debug(exception, messageTemplate);
        }

        public void Debug<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            Log.Logger?.Debug<T>(exception, messageTemplate, propertyValue);
        }

        public void Debug<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            Log.Logger?.Debug<T0, T1>(exception, messageTemplate, propertyValue0, propertyValue1);
        }

        public void Debug<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0,
            T1 propertyValue1, T2 propertyValue2)
        {
            Log.Logger?.Debug<T0, T1, T2>(exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Information(string messageTemplate)
        {
            Log.Logger?.Information(messageTemplate);
        }

        public void Information<T>(string messageTemplate, T propertyValue)
        {
            Log.Logger?.Information<T>(messageTemplate, propertyValue);
        }

        public void Information<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            Log.Logger?.Information<T0, T1>(messageTemplate, propertyValue0, propertyValue1);
        }

        public void Information<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1,
            T2 propertyValue2)
        {
            Log.Logger?.Information<T0, T1, T2>(messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Information(Exception exception, string messageTemplate)
        {
            Log.Logger?.Information(exception, messageTemplate);
        }

        public void Information<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            Log.Logger?.Information<T>(exception, messageTemplate, propertyValue);
        }

        public void Information<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0,
            T1 propertyValue1)
        {
            Log.Logger?.Information<T0, T1>(exception, messageTemplate, propertyValue0, propertyValue1);
        }

        public void Information<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0,
            T1 propertyValue1, T2 propertyValue2)
        {
            Log.Logger?.Information<T0, T1, T2>(exception, messageTemplate, propertyValue0, propertyValue1,
                propertyValue2);
        }

        public void Warning(string messageTemplate)
        {
            Log.Logger?.Warning(messageTemplate);
        }

        public void Warning<T>(string messageTemplate, T propertyValue)
        {
            Log.Logger?.Warning<T>(messageTemplate, propertyValue);
        }

        public void Warning<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            Log.Logger?.Warning<T0, T1>(messageTemplate, propertyValue0, propertyValue1);
        }

        public void Warning<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1,
            T2 propertyValue2)
        {
            Log.Logger?.Warning<T0, T1, T2>(messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Warning(Exception exception, string messageTemplate)
        {
            Log.Logger?.Warning(exception, messageTemplate);
        }

        public void Warning<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            Log.Logger?.Warning<T>(exception, messageTemplate, propertyValue);
        }

        public void Warning<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            Log.Logger?.Warning<T0, T1>(exception, messageTemplate, propertyValue0, propertyValue1);
        }

        public void Warning<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0,
            T1 propertyValue1, T2 propertyValue2)
        {
            Log.Logger?.Warning<T0, T1, T2>(exception, messageTemplate, propertyValue0, propertyValue1,
                propertyValue2);
        }

        public void Error(string messageTemplate)
        {
            Log.Logger?.Error(messageTemplate);
        }

        public void Error<T>(string messageTemplate, T propertyValue)
        {
            Log.Logger?.Error<T>(messageTemplate, propertyValue);
        }

        public void Error<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            Log.Logger?.Error<T0, T1>(messageTemplate, propertyValue0, propertyValue1);
        }

        public void Error<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            Log.Logger?.Error<T0, T1, T2>(messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Error(Exception exception, string messageTemplate)
        {
            Log.Logger?.Error(exception, messageTemplate);
        }

        public void Error<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            Log.Logger?.Error<T>(exception, messageTemplate, propertyValue);
        }

        public void Error<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            Log.Logger?.Error<T0, T1>(exception, messageTemplate, propertyValue0, propertyValue1);
        }

        public void Error<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0,
            T1 propertyValue1, T2 propertyValue2)
        {
            Log.Logger?.Error<T0, T1, T2>(exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Fatal(string messageTemplate)
        {
            Log.Logger?.Fatal(messageTemplate);
        }

        public void Fatal<T>(string messageTemplate, T propertyValue)
        {
            Log.Logger?.Fatal<T>(messageTemplate, propertyValue);
        }

        public void Fatal<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            Log.Logger?.Fatal<T0, T1>(messageTemplate, propertyValue0, propertyValue1);
        }

        public void Fatal<T0, T1, T2>(string messageTemplate, T0 propertyValue0, T1 propertyValue1, T2 propertyValue2)
        {
            Log.Logger?.Fatal<T0, T1, T2>(messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public void Fatal(Exception exception, string messageTemplate)
        {
            Log.Logger?.Fatal(exception, messageTemplate);
        }

        public void Fatal<T>(Exception exception, string messageTemplate, T propertyValue)
        {
            Log.Logger?.Fatal<T>(exception, messageTemplate, propertyValue);
        }

        public void Fatal<T0, T1>(Exception exception, string messageTemplate, T0 propertyValue0, T1 propertyValue1)
        {
            Log.Logger?.Fatal<T0, T1>(exception, messageTemplate, propertyValue0, propertyValue1);
        }

        public void Fatal<T0, T1, T2>(Exception exception, string messageTemplate, T0 propertyValue0,
            T1 propertyValue1, T2 propertyValue2)
        {
            Log.Logger?.Fatal<T0, T1, T2>(exception, messageTemplate, propertyValue0, propertyValue1, propertyValue2);
        }

        public bool BindMessageTemplate(string messageTemplate, object[] propertyValues,
            out MessageTemplate parsedTemplate, out IEnumerable<LogEventProperty> boundProperties)
        {
            parsedTemplate = null;
            boundProperties = null;
            return false;
        }

        public bool BindProperty(string propertyName, object value, bool destructureObjects,
            out LogEventProperty property)
        {
            property = null;
            return false;
        }
    }
}
