using System.Threading;
using ReimuAPI.ReimuBase;
using ReimuAPI.ReimuBase.TgData;

namespace DevBlackListSoamChecker
{
    internal class CheckInReportGroup
    {
        internal bool CheckAdminInReportGroup(long ChatID)
        {
            if (Temp.ReportGroupID != 0)
            {
                if (adminInReport.Contains(ChatID))
                    return true;
                
                bool status = false;
                GroupUserInfo[] admins = TgApi.getDefaultApiConnection().getChatAdministrators(ChatID,true);
                foreach (var admin in admins)
                {
                    if (TgApi.getDefaultApiConnection().getChatMember(ChatID, admin.user.id).ok)
                    {
                        status = true;
                        break;
                    }
                }

                if (status)
                    adminInReport.Add(ChatID);
                
                return status
                    
            }
            else
            {
                return true;
            }
        }
    }
}