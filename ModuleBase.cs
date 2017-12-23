using CitizenFX.Core;
using System;
using System.Collections.Generic;

namespace Aeonix
{
	public class ModuleBase
	{
		public Dictionary<String, CommandBase> Commands = new Dictionary<String, CommandBase>();
		public Dictionary<String, Dictionary<String, dynamic>> Handlers = new Dictionary<String, Dictionary<String, dynamic>>();
		public String Name = "";

		public Dictionary<String, CommandBase> GetCommands()
		{
			return this.Commands;
		}

		public Dictionary<String, Dictionary<String, dynamic>> GetHandlers()
		{
			return this.Handlers;
		}

		public String GetName()
		{
			return this.Name;
		}

		public void Init(String name)
		{
			this.SetName(name);
			Debug.WriteLine("Initializing module: " + this.GetName());
		}

		public void Init(String name, Dictionary<String, CommandBase> commands)
		{
			this.SetName(name);
			Debug.WriteLine("Initializing module: " + this.GetName());

			foreach(KeyValuePair<String, CommandBase> command in commands)
			{
				Debug.WriteLine("[" + this.GetName() + "] Added " + command.Key + " command to module");
				this.Commands.Add(command.Key, command.Value);
			}

			this.RegisterCommands();
		}

		public void RegisterCommands()
		{
			Dictionary<String, CommandBase> commands = this.GetCommands();

			foreach (KeyValuePair<String, CommandBase> command in commands)
			{
				Debug.WriteLine("[Module: " + this.GetName() + "] Registering command: " + command.Key);
				Core.GetInstance().RegisterCommand(command.Key, command.Value);
			}
		}

		public void RegisterHandler(String type, String key, dynamic value)
		{
			Dictionary<String, dynamic> objectValue = new Dictionary<string, dynamic>
			{
				{ key, value }
			};

			foreach (KeyValuePair<String, Dictionary<String, dynamic>> searchKey in this.Handlers)
			{
				if (searchKey.Key == type)
				{
					this.Handlers.Add(searchKey.Key, objectValue);
					break;
				}
			}
		}

		public void SetName(String name)
		{
			this.Name = name;
		}
	}
}
