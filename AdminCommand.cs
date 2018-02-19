﻿using DevBlackListSoamChecker.CommandObject;
using ReimuAPI.ReimuBase;
using ReimuAPI.ReimuBase.TgData;

namespace DevBlackListSoamChecker
{
    internal class AdminCommand
    {
        private readonly string Disabled_Ban_Msg = "非常抱歉，目前版本已關閉封鎖用戶的功能，請聯絡管理員開啟此功能。";

        internal bool AdminCommands(TgMessage RawMessage, string JsonMessage, string Command){
            if (RAPI.getIsBotOP(RawMessage.GetSendUser().id) || RAPI.getIsBotAdmin(RawMessage.GetSendUser().id))
            {
                if(!Temp.DisableBanList)
                {
                    switch (Command)
                    {
                        
                        case "/getspampoints":
                            new SpamStringManager().GetSpamPoints(RawMessage);
                            throw new StopProcessException();
                        case "/" + Temp.CommandPrefix + "ban":
                        case "/ban":
                            new BanUserCommand().Ban(RawMessage, JsonMessage, Command);
                            throw new StopProcessException();
                        case "/" + Temp.CommandPrefix + "unban":
                        case "/unban":
                            new UnbanUserCommand().Unban(RawMessage);
                            throw new StopProcessException();
                    }
                }
                if(RAPI.getIsBotAdmin(RawMessage.GetSendUser().id))
                {
                    if(!Temp.DisableBanList){
                        switch (Command)
                        {
                            case "/__getallspamstr": //暫時不用
                                new SpamStringManager().GetAllInfo(RawMessage);
                                return true;
                            case "/__kick": //暫時不用
                                //new SpamStringManager().GetAllInfo(RawMessage);
                                return true;
                            case "/addspamstr":
                                new SpamStringManager().Add(RawMessage);
                                throw new StopProcessException();
                            case "/delspamstr":
                                new SpamStringManager().Remove(RawMessage);
                                throw new StopProcessException();
                            case "/suban":
                                new BanMultiUserCommand().BanMulti(RawMessage, JsonMessage, Command);
                                throw new StopProcessException();
                            case "/suunban":
                                new UnBanMultiUserCommand().UnbanMulti(RawMessage);
                            case "/getspamstr":
                                new SpamStringManager().GetName(RawMessage);
                                throw new StopProcessException();
                        }
                    }
                    switch (Command)
                    {

                        case "/say":
                            new BroadCast().BroadCast_Status(RawMessage);
                            throw new StopProcessException();
                        case "/sdall":
                            new OP().SDAll(RawMessage);
                            throw new StopProcessException();
                        case "/seall":
                            new OP().SEAll(RawMessage);
                            throw new StopProcessException();
                        case "/addop":
                            new OP().addOP(RawMessage);
                            throw new StopProcessException();
                        case "/delop":
                            new OP().delOP(RawMessage);
                            throw new StopProcessException();
                        case "/addwl":
                            new Whitelist().addWhitelist(RawMessage);
                            throw new StopProcessException();
                        case "/delwl":
                            new Whitelist().deleteWhitelist(RawMessage);
                            throw new StopProcessException();
                        case "/lswl":
                            new Whitelist().listWhitelist(RawMessage);
                            throw new StopProcessException();
                        case "/block":
                            new BlockGroup().addBlockGroup(RawMessage);
                            throw new StopProcessException();
                        case "/unblock":
                            new BlockGroup().deleteBlockGroup(RawMessage);
                            throw new StopProcessException();
                        case "/blocks":
                            new BlockGroup().listBlockGroup(RawMessage);
                            throw new StopProcessException();
                    }
                    throw new StopProcessException();
                }
            }
            return false;
        }
    }
}