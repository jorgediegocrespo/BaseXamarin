namespace BaseXamarin.Services
{
	using System;
	using System.Runtime.CompilerServices;

	public interface ILogService
    {
		void Start();
		void Log(string message);
		void Log(string message, [CallerMemberName]string callerMemberName = null);
		void LogError(Exception ex);
		void LogError(Exception ex, [CallerMemberName]string callerMemberName = null);
	}
}
