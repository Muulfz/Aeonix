using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeRP
{
	public class ModuleBase
	{
		public Dictionary<String, Command> commands = new Dictionary<String, Command>();
		public Dictionary<String, Dictionary<String, dynamic>> handlers = new Dictionary<String, Dictionary<String, dynamic>>();
		public String name = "";

		public Dictionary<String, Command> getCommands()
		{
			return this.commands;
		}

		public Dictionary<String, Dictionary<String, dynamic>> getHandlers()
		{
			return this.handlers;
		}

		public String getName()
		{
			return this.name;
		}

		public void init(String name)
		{
			Debug.WriteLine("Initializing module: " + this.getName());
			this.setName(name);
		}

		public void registerCommands()
		{
			Dictionary<String, Command> commands = this.getCommands();

			foreach (KeyValuePair<String, Command> command in commands)
			{
				Debug.WriteLine("[Module: " + this.getName() + "] Registering command: " + command.Key);
				Core.getInstance().registerCommand(command.Key, command.Value);
			}
		}

		public void registerHandler(String type, String key, dynamic value)
		{
			Dictionary<String, dynamic> objectValue = new Dictionary<string, dynamic>();
			objectValue.Add(key, value);

			foreach (KeyValuePair<String, Dictionary<String, dynamic>> searchKey in this.handlers)
			{
				if (searchKey.Key == type)
				{
					this.handlers.Add(searchKey.Key, objectValue);
					break;
				}
			}
		}

		public void setName(String name)
		{
			this.name = name;
		}
	}
}
