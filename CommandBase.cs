using System;
using System.Collections.Generic;

namespace Aeonix
{
	public abstract class CommandBase
	{
		private String Description = "";
		private CommandHandlerBase Handler = null;
		private String Name = "";
		private String UsageResponse = "";

		public String GetDescription()
		{
			return this.Description;
		}

		public CommandHandlerBase GetHandler()
		{
			return this.Handler;
		}

		public String GetName()
		{
			return this.Name;
		}

		public String GetUsageResponse()
		{
			if (this.UsageResponse != "")
			{
				return this.UsageResponse;
			}

			return "/" + this.GetName().ToLower();
		}

		public void Init(String name, String description = "", String usageResponse = "")
		{
			this.SetHandler();
			this.SetName(name);

			if (description != "")
			{
				this.SetDescription(description);
			}

			if (usageResponse != "")
			{
				this.SetUsageResponse(usageResponse);
			}
		}

		public abstract bool Process(List<String> args);

		public void SendResponse()
		{
		}

		public void SetDescription(String description)
		{
			this.Description = description;
		}

		public void SetHandler()
		{
			CommandHandlerBase commandHandler = new CommandHandlerBase();
			commandHandler.Init(this);
			this.Handler = commandHandler;
		}

		public void SetName(String name)
		{
			this.Name = name;
		}

		public void SetUsageResponse(String usageResponse)
		{
			this.UsageResponse = usageResponse;
		}
	}
}
