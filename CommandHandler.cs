using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeRP
{
	public class CommandHandler
	{
		private List<String> args = new List<String>();
		private int executorId = 0;
		private String executorName = "";
		private Command command = null;

		public CommandHandler(Command command)
		{
			this.setCommand(command);
		}

		public CommandHandler(Command command, List<String> args)
		{
			this.setCommand(command);
			this.setArgs(args);
		}

		public List<String> getArgs()
		{
			return this.args;
		}

		public Command getCommand()
		{
			return this.command;
		}

		public String getExecutor()
		{
			return this.getExecutorName() + "(" + this.getExecutorId() + ")";
		}

		public int getExecutorId()
		{
			return this.executorId;
		}

		public String getExecutorName()
		{
			return this.executorName;
		}

		public bool process()
		{
			List<String> args = this.getArgs();
			Command command = this.getCommand();

			if (command.Equals(null))
			{
				Debug.WriteLine(this.GetType().Name + " expects a valid command to be given, none provided..");
				return false;
			}

			return command.process(args);
		}

		public void sendUsageMessage()
		{
			BaseScript.TriggerEvent("chatMessage", "[System]", new int[] { 255, 255, 255 }, this.command.getUsageResponse());
		}

		public void setArgs(List<String> args)
		{
			this.args = args;
		}

		public void setCommand(Command command)
		{
			this.command = command;
		}

		public void setExecutor(int playerId, String playerName)
		{
			this.executorId = playerId;
			this.executorName = playerName;
		}
	}
}
