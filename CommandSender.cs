using System;

namespace Aeonix
{
	class CommandSender
	{
		private int PlayerId = 0;
		private String PlayerName = "";

		public CommandSender(int playerId, String playerName)
		{
			this.SetPlayerId(playerId);
			this.SetPlayerName(playerName);
		}

		public int GetPlayerId()
		{
			return this.PlayerId;
		}

		public String GetPlayerName()
		{
			return this.PlayerName;
		}

		public void SetPlayerId(int playerId)
		{
			this.PlayerId = playerId;
		}

		public void SetPlayerName(String playerName)
		{
			this.PlayerName = playerName;
		}
	}
}
