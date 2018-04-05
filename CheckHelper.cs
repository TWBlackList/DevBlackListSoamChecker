using ReimuAPI.ReimuBase;
using ReimuAPI.ReimuBase.TgData;

namespace DevBlackListSoamChecker
{
    public class CheckHelper
    {
        public bool CheckAdminInReportGroup(long ChatID)
        {
            System.Console.WriteLine("CheckAdminInReportGroup Called. ChatID" + ChatID.ToString());
            if (Temp.ReportGroupID != 0)
            {
                foreach (long i in Temp.adminInReport)
                    if (i == ChatID)
                        return true;
                System.Console.WriteLine("Not in temp list");
                
                bool status = false;
                GroupUserInfo[] admins = TgApi.getDefaultApiConnection().getChatAdministrators(ChatID,true);
                System.Console.WriteLine("get admins");
                foreach (var admin in admins)
                {
                    var result = TgApi.getDefaultApiConnection().getChatMember(ChatID, admin.user.id);
                    System.Console.WriteLine("result ok " + result.ok.ToString() + " status" + result.result.status);
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