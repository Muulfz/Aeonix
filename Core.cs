using CitizenFX.Core;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Aeonix
{
	public class Core
	{
		private Dictionary<String, CommandBase> Commands = new Dictionary<String, CommandBase>() { };
		private Dictionary<String, ModuleBase> Modules = new Dictionary<String, ModuleBase>() { };
		private Version Version = new Version(1, 0, 1);

		public static Core Instance = null;

		public CommandBase GetCommand(String command)
		{
			this.Commands.TryGetValue(command, out CommandBase foundCommand);
			return foundCommand;
		}

		public Dictionary<String, CommandBase> GetCommands()
		{
			return this.Commands;
		}

		public static Core GetInstance()
		{
			if (Instance == null)
			{
				Instance = new Core();
			}

			return Instance;
		}

		public ModuleBase GetModule(String key)
		{
			ModuleBase value = null;
			this.Modules.TryGetValue(key, out value);
			return value;
		}

		public Dictionary<String, ModuleBase> GetModules()
		{
			return this.Modules;
		}

		public String GetVersion(bool asCode = false)
		{
			if (asCode)
			{
				return this.Version.Major.ToString() + this.Version.Minor.ToString() + this.Version.Revision.ToString();
			}
			else
			{
				return this.Version.ToString();
			}
		}

		public bool HasCommand(String command)
		{
			return this.Commands.TryGetValue(command, out CommandBase foundCommand);
		}

		public bool HasModule(String key)
		{
			return this.Modules.TryGetValue(key, out ModuleBase value);
		}

		public void LoadModules(Type type)
		{
			Debug.WriteLine("Loading modules..");

			Assembly assembly = Assembly.GetCallingAssembly();
			List<String> modules = new List<String>();
			int registeredModules = 0;

			foreach (TypeInfo typeInfo in assembly.DefinedTypes)
			{
				if (!typeInfo.FullName.Contains("Module"))
				{
					continue;
				}

				modules.Add(typeInfo.FullName);
			}

			if (modules.Count == 0)
			{
				Debug.WriteLine("No modules found to load..");
				return;
			}

			foreach (String module in modules)
			{
				String moduleName = module.ToLower().Replace("client.module.", "");
				Type moduleType = assembly.GetType(module);

				if (moduleType == null)
				{
					Debug.WriteLine("Can't create module object for '" + moduleName + "', class doesn't exist..");
					continue;
				}

				ModuleBase moduleObject = (ModuleBase)Activator.CreateInstance(moduleType);
				if (moduleObject == null)
				{
					Debug.WriteLine("Module '" + moduleName + "' not registered, couldn't create instance..");
					continue;
				}

				Debug.WriteLine("Module registered: " + moduleName);

				registeredModules++;
				Core.GetInstance().RegisterModule(moduleName, moduleObject);
			}

			if (registeredModules == modules.Count)
			{
				Debug.WriteLine("All modules registered successfully!");
			}
			else
			{
				Debug.WriteLine("Registered " + registeredModules + "/" + modules.Count + " successfully");
			}
		}

		public void RegisterCommand(String key, CommandBase value)
		{
			this.Commands.Add(key, value);
		}

		public void RegisterModule(String key, ModuleBase value)
		{
			this.Modules.Add(key, value);
		}

		public void UnregisterCommand(String key)
		{
			this.Commands.Remove(key);
		}

		public void UnregisterModule(String key)
		{
			this.Modules.Remove(key);
		}
	}
}
