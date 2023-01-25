using System.Threading.Tasks;
using System.Threading;

namespace SEFI.Infrastructure.Interfaces
{
	public interface ICommand
	{
		string QueueName { get; set; }
		string QueueHostName { get; set; }
		string QueueUserName { get; set; }
		string QueueUserSecret { get; set; }
		string QueueExchange { get; set; }
		void Close();
		void Run(string message);
	}
}
