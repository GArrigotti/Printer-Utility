using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Utility_Core.Architecture.Application_Layer.Extensions
{
    public static class ILoggerExtension
    {
        public static void Decorate(this ILogger logger, Exception exception)
        {
            logger.Error($"┌{new string('─', 100)}┐");
            logger.Error($"│{"Exception:".Left()}│");
            logger.Error($"│{exception.Message.Left()}│");
            logger.Error($"└{new string('─', 100)}┘");
        }

        public static void Decorate(this ILogger logger, params string[] contents)
        {
            logger.Information($"┌{new string('─', 100)}┐");

            foreach (var content in contents)
                logger.Information($"│{content.Left()}│");

            logger.Information($"└{new string('─', 100)}┘");
        }

        #region Private:

        private static string Left(this string content, int console = 100)
        {
            String characters = content.Length > 96 ?
                content.Substring(0, 96) :
                content.Substring(0, content.Length);

            return $"{new String(' ', 2)}{characters}{new String(' ', (console - (2 + characters.Length)))}";
        }

        private static string Center(this string content, int console = 100)
        {
            var characters = content.Substring(0, 96);
            int left = (console - characters.Length) / 2;
            int right = console - (left + characters.Length);

            return $"{new String(' ', left)}{characters}{new String(' ', right)}";
        }

        #endregion
    }
}
