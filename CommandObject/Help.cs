﻿using ReimuAPI.ReimuBase;
using ReimuAPI.ReimuBase.TgData;

namespace DevBlackListSoamChecker.CommandObject
{
    internal class Help
    {
        internal bool HelpStatus(TgMessage RawMessage)
        {
            string finalHelpMsg;
            string groupHelp = "/leave - 離開群組\n" +
                               "/soamenable - 啟用功能\n" +
                               "/soamdisable - 關閉功能\n" +
                               "/soamstatus - 取得目前群組開啟功能";
            string privateHelp = "";
            string sharedHelp = "/banstat - 查詢處分狀態\n" +
                                "/user - 取得 User ID\n" +
                                "/lsop - Operator 名冊";
            switch (RawMessage.chat.type)
            {
                case "group":
                case "supergroup":
                    finalHelpMsg = groupHelp + "\n" + sharedHelp;
                    break;
                case "private":
                    finalHelpMsg = privateHelp + "\n" + sharedHelp;
                    break;
                default:
                    finalHelpMsg = sharedHelp;
                    break;
            }

            if (RAPI.getIsBotOP(RawMessage.from.id) || RAPI.getIsBotAdmin(RawMessage.from.id))
                finalHelpMsg = finalHelpMsg + "\n\nOperator指令:\n" +
                               "/groupadmin - 取得群組管理員名單\n" +
                               "/cnban - 封鎖\n" +
                               "/ban - 封鎖\n" +
                               "/cnunban - 解除封鎖\n" +
                               "/unban - 解除封鎖\n" +
                               "/addhk - 新增使用者至HK白名單\n" +
                               "/delhk - 從HK白名單中刪除使用者\n" +
                               "/lshk - 取得HK白名單列表\n" +
                               "/groups - 取得所有群組\n" +
                               "/getspampoints - 測試關鍵字";
            if (RAPI.getIsBotAdmin(RawMessage.from.id))
                finalHelpMsg = finalHelpMsg + "\n\nAdmin指令:\n" +
                               "/suban - 批次封鎖\n" +
                               "/suunban - 批次解除封鎖\n" +
                               "/addspamstr - 新增 1 個自動規則\n" +
                               "/delspamstr - 刪除 1 個自動規則\n" +
                               "/getspamstr - 查看自動規則列表\n" +
                               "/getallspamstr - 查看所有自動規則列表\n" +
                               "/reloadspamstr - 重新載入自動規則列表\n" +
                               "/points - 取得匹配到的關鍵字\n" +
                               "/say - 廣播\n" +
                               "/addwl - 新增使用者至白名單\n" +
                               "/delwl - 從白名單中刪除使用者\n" +
                               "/lswl - 取得白名單列表\n" +
                               "/block - 新增群組至禁止使用名單\n" +
                               "/unblock - 從禁止使用名單中刪除群組\n" +
                               "/blocks - 取得禁止使用名單\n" +
                               "/addop - 新增 Operator\n" +
                               "/delop - 解除 Operator\n" +
                               "/seall - 開啟所有群組功能\n" +
                               "/sdall - 關閉所有群組功能\n" +
                               "/cleanup - 清理機器人不在群組內的群組資料\n";
            finalHelpMsg = finalHelpMsg + "\n如要贊助本項目請洽[生產公司](http://t.me/DonateDoramiBot)";
            TgApi.getDefaultApiConnection()
                .sendMessage(RawMessage.GetMessageChatInfo().id, finalHelpMsg, RawMessage.message_id,ParseMode: TgApi.PARSEMODE_MARKDOWN);
            return true;
        }
    }
}