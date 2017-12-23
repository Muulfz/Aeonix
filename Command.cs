using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeRP
{
	public abstract class Command
	{
		private String description = "";
		private CommandHandler handler = null;
		private String name = "";
		private String usageResponse = "";

		public String getDescription()
		{
			return this.description;
		}

		public CommandHandler getHandler()
		{
			return this.handler;
		}

		public String getName()
		{
			return this.name;
		}

		public String getUsageResponse()
		{
			if (this.usageResponse != "")
			{
				return this.usageResponse;
			}

			return "/" + this.getName().ToLower();
		}

		public void init(String name, String description = "", String usageResponse = "")
		{
			this.setHandler();
			this.setName(name);

			if (description != "")
			{
				this.setDescription(description);
			}

			if (usageResponse != "")
			{
				this.setUsageResponse(usageResponse);
			}
		}

		public abstract bool process(List<String> args);

		public void sendResponse()
		{
		}

		public void setDescription(String description)
		{
			this.description = description;
		}

		public void setHandler()
		{
			this.handler = new CommandHandler(this);
		}

		public void setName(String name)
		{
			this.name = name;
		}

		public void setUsageResponse(String usageResponse)
		{
			this.usageResponse = usageResponse;
		}
	}
}
