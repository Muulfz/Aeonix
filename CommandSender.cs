using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeRP
{
	class CommandSender
	{
		private int playerId = 0;
		private String playerName = "";

		public CommandSender(int playerId, String playerName)
		{
			this.setPlayerId(playerId);
			this.setPlayerName(playerName);
		}

		public int getPlayerId()
		{
			return this.playerId;
		}

		public String getPlayerName()
		{
			return this.playerName;
		}

		public void setPlayerId(int playerId)
		{
			this.playerId = playerId;
		}

		public void setPlayerName(String playerName)
		{
			this.playerName = playerName;
		}
	}
}
