namespace BaseXamarin.Services
{
	using System;
	using System.Runtime.CompilerServices;

	public interface ILogService
    {
		void Log(LogItem logItem);
		void Log(string message, [CallerMemberName]string callerMemberName = null);
		void LogError(Exception ex);
		void LogError(Exception ex, [CallerMemberName]string callerMemberName = null);
	}
}
