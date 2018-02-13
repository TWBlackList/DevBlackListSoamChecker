using System.Collections.Generic;
using CNBlackListSoamChecker.DbManager;
using ReimuAPI.ReimuBase.Interfaces;

namespace CNBlackListSoamChecker
{
    internal class ItemCleaner : IClearItemsReceiver
    {
        public void ClearItems()
        {
            Temp.spamMessageList = null;
            Temp.groupConfig = new Dictionary<long, GroupCfg>();
            Temp.bannedUsers = new Dictionary<int, BanUser>();
        }
    }
}