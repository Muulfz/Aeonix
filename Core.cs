using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WeRP
{
	public class Core
	{
		private Dictionary<String, Command> commands = new Dictionary<String, Command>() { };
		private Dictionary<String, ModuleBase> modules = new Dictionary<String, ModuleBase>() { };
		private Version version = new Version(1, 0, 1);

		public static Core instance = null;

		public Command getCommand(String command)
		{
			this.commands.TryGetValue(command, out Command foundCommand);
			return foundCommand;
		}

		public Dictionary<String, Command> getCommands()
		{
			return this.commands;
		}

		public static Core getInstance()
		{
			if (instance == null)
			{
				instance = new Core();
			}

			return instance;
		}

		public ModuleBase getModule(String key)
		{
			ModuleBase value = null;
			this.modules.TryGetValue(key, out value);
			return value;
		}

		public Dictionary<String, ModuleBase> getModules()
		{
			return this.modules;
		}

		public String getVersion(bool asCode = false)
		{
			if (asCode)
			{
				return this.version.Major.ToString() + this.version.Minor.ToString() + this.version.Revision.ToString();
			}
			else
			{
				return this.version.ToString();
			}
		}

		public bool hasCommand(String command)
		{
			return this.commands.TryGetValue(command, out Command foundCommand);
		}

		public bool hasModule(String key)
		{
			return this.modules.TryGetValue(key, out ModuleBase value);
		}

		public void loadModules(Type type)
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
				Core.getInstance().registerModule(moduleName, moduleObject);
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

		public void registerCommand(String key, Command value)
		{
			this.commands.Add(key, value);
		}

		public void registerModule(String key, ModuleBase value)
		{
			this.modules.Add(key, value);
		}

		public void unregisterCommand(String key)
		{
			this.commands.Remove(key);
		}

		public void unregisterModule(String key)
		{
			this.modules.Remove(key);
		}
	}
}
