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
                    System.Console.WriteLine("getting member chatid" + ChatID + " userid" + admin.user.id);
                    var result = TgApi.getDefaultApiConnection().getChatMember(ChatID, admin.user.id);
                    System.Console.WriteLine("ok" + result.ok.ToString() + " status" + result.result.status);
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