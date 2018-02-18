using System.Collections.Generic;
using DevBlackListSoamChecker.DbManager;
using ReimuAPI.ReimuBase.Interfaces;

namespace DevBlackListSoamChecker
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