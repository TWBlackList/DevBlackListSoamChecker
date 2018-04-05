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
                if (Temp.adminInReport.Contains(ChatID))
                    return true;
                
                bool status = false;
                GroupUserInfo[] admins = TgApi.getDefaultApiConnection().getChatAdministrators(ChatID,true);
                foreach (var admin in admins)
                {
                    var result = TgApi.getDefaultApiConnection().getChatMember(ChatID, admin.user.id);
                    if (result.ok)
                        if(result.status != "left")
                        {
                            status = true;
                            break;
                        }
                }

                if (status)
                    Temp.adminInReport.Add(ChatID);

                return status;

            }
            else
            {
                return true;
            }
        }
    }
}