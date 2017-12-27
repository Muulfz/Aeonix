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

		public String GetName(bool forUse = false)
		{
			String name = this.Name;

			if (forUse)
			{
				name = name.ToLower().Replace(" ", "");
			}

			return name;
		}

		public String GetUsageResponse()
		{
			if (this.UsageResponse != "")
			{
				return this.UsageResponse;
			}

			return "/" + this.GetName(true);
		}

		public void Init(String name, String description = "", String usageResponse = "")
		{
			this.SetHandler();
			this.SetName(name);
			this.SetDescription(description);
			this.SetUsageResponse(usageResponse);
		}

		public abstract bool Process(List<String> args);

		public void SendResponse()
		{
		}

		public void SetDescription(String description)
		{
			if (description == "")
			{
				return;
			}

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
			if (usageResponse == "")
			{
				return;
			}

			this.UsageResponse = usageResponse;
		}
	}
}
