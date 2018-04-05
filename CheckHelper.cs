using ReimuAPI.ReimuBase;
using ReimuAPI.ReimuBase.TgData;

namespace DevBlackListSoamChecker
{
    internal class CheckHelper
    {
        private bool CheckAdminInReportGroup(long ChatID)
        {
            if (Temp.ReportGroupID != 0)
            {
                foreach (long i in Temp.adminInReport)
                    if (i == ChatID)
                        return true;
                
                bool status = false;
                GroupUserInfo[] admins = TgApi.getDefaultApiConnection().getChatAdministrators(ChatID,true);
                foreach (var admin in admins)
                {
                    var result = TgApi.getDefaultApiConnection().getChatMember(ChatID, admin.user.id);
                    if (result.ok)
                        if(result.result.status != "left")
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