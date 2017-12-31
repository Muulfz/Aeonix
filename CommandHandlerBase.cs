using Aeonix.Util;
using CitizenFX.Core;
using System;
using System.Collections.Generic;

namespace Aeonix
{
	public class CommandHandlerBase
	{
		private List<String> Args = new List<String>();
		private int ExecutorId = 0;
		private String ExecutorName = "";
		private CommandBase Command = null;

		public List<String> GetArgs()
		{
			return this.Args;
		}

		public CommandBase GetCommand()
		{
			return this.Command;
		}

		public String GetExecutor()
		{
			return this.GetExecutorName() + "(" + this.GetExecutorId() + ")";
		}

		public int GetExecutorId()
		{
			return this.ExecutorId;
		}

		public String GetExecutorName()
		{
			return this.ExecutorName;
		}

		public void Init(CommandBase command)
		{
			this.SetCommand(command);
		}

		public void Init(CommandBase command, List<String> args)
		{
			this.SetCommand(command);
			this.SetArgs(args);
		}

		public bool Process()
		{
			List<String> args = this.GetArgs();
			CommandBase command = this.GetCommand();

			if (command.Equals(null))
			{
				Core.Log(this.GetType().Name + " expects a valid command to be given, none provided..");
				return false;
			}

			return command.Process(args);
		}

		public void SendUsageMessage()
		{
			BaseScript.TriggerEvent("chatMessage", "", Color.Default, this.Command.GetUsageResponse());
		}

		public void SetArgs(List<String> args)
		{
			this.Args = args;
		}

		public void SetCommand(CommandBase command)
		{
			this.Command = command;
		}

		public void SetExecutor(int playerId, String playerName)
		{
			this.ExecutorId = playerId;
			this.ExecutorName = playerName;
		}
	}
}
