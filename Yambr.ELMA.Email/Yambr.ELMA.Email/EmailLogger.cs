using EleWise.ELMA;
using EleWise.ELMA.Logging;

namespace Yambr.ELMA.Email
{
    public static class EmailLogger
    {
        public static ILogger Logger { get; } = EleWise.ELMA.Logging.Logger.GetLogger("YambrELMAEmail");

        public static void Debug(string message)
        {
            if (Logger.IsEnabled(LogLevel.Debug))
            {
                Logger.Debug(SR.T(message));
            }
        }

        public static void Debug(string format, params object[]args)
        {
            if (Logger.IsEnabled(LogLevel.Debug))
            {
                Logger.Debug(SR.T(format, args));
            }
        }
    }
}
