﻿using BotTools.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord;
using System.Collections.Specialized;
using JsonConfig;
using Discord.Commands;
using System.Threading;
using BotTools.Handlers;
using CruxBot;

namespace Crux.Commands
{
    class Config1 : IJsonConfig
    {
        public List<string> Registered;

        public void LoadDefaults()
        {
            Registered = new List<string>();
        }
    }

    class EmbedTest : IDiscordCommand
    {
        public string Name => "ModHelp";

        public string Help => "Shows all moderator commands (only executable by Moderators)";

        public string Syntax => "";

        public string Permission => "admin";

        public async Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            Task.Run(async () =>
            {
                if (parameters.Length > 0)
                {
                    await msg.Channel.SendMessageAsync("**This command does not take parameters**");
                    return;
                }

                EmbedBuilder eb = new EmbedBuilder();
                EmbedFooterBuilder ef = new EmbedFooterBuilder();

                //await msg.DeleteAsync();

                eb.Color = Color.DarkRed;

                ef.WithText("I have no clue what this does..");
                ef.Text = "CMS";
                eb.WithFooter(footer: ef);

                eb.Title = "Very nice title indeed!";
                eb.Description = "This is just me testing stuff out.";


                eb.ThumbnailUrl = "https://www.askideas.com/media/40/Wolf-Funny-Face-Expression-Image.jpg";
                eb.ImageUrl = "https://vignette3.wikia.nocookie.net/animal-jam-clans-1/images/c/cd/223731-wolf-lovers-wolf-banner-1.jpg/revision/latest?cb=20170108024653";

                eb.AddField("Hey", ":D");
                eb.AddInlineField("who", "dis?");
                eb.AddInlineField("who", "dis?");
                eb.AddInlineField("who", "dis?");
                eb.AddInlineField("who", "dis?");

                eb.Timestamp = DateTime.Now;
                eb.WithCurrentTimestamp();

                //await msg.Author.GetOrCreateDMChannelAsync();
                //await msg.Author.SendMessageAsync("**CruxBot**", embed: eb);

                await msg.Channel.SendMessageAsync("", embed: eb);
            });
        }

    }

    class Test : IDiscordCommand
    {
        public string Name => "T";

        public string Help => "A command to test if the bot is working properly";

        public string Syntax => "";

        public string Permission => "Default";

        public async Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            await msg.Channel.SendMessageAsync("command triggered");
        }
    }

    class Prefixes : IDiscordCommand
    {
        public string Name => "Prefixes";

        public string Help => "";

        public string Syntax => "Shows all the prefixes of the different bots";

        public string Permission => "Default";

        public async Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            await Task.Run(async () =>
            {
                EmbedBuilder eb = new EmbedBuilder();
                eb.AddField("Name: CruxBot", "Prefix: ;;");
                eb.AddField("Name: Dyno", "Prefix: &");
                eb.AddField("Name: Marv", "Prefix: -");
                eb.AddField("Name: Mee6", "Prefix: !");

                eb.Color = Color.LightGrey;

                var sentMsg = await msg.Channel.SendMessageAsync("", embed: eb);

                await Task.Delay(10000);
                await msg.DeleteAsync();
                await sentMsg.DeleteAsync();
            });
        }
    }

    class Roulette : IDiscordCommand
    {
        public string Name => "roulette";

        public string Help => "";

        public string Syntax => "Shows information about the Roulette command";

        public string Permission => "default";

        public Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {

            Task.Run(async () =>
            {
                EmbedBuilder eb = new EmbedBuilder();
                eb.AddField("1/6 Bullets in the chamber", ";;roulette_1");
                eb.AddField("2/6 Bullets in the chamber", ";;roulette_2");
                eb.AddField("3/6 Bullets in the chamber", ";;roulette_3");
                eb.AddField("4/6 Bullets in the chamber", ";;roulette_4");
                eb.AddField("5/6 Bullets in the chamber", ";;roulette_5");

                eb.Color = Color.Purple;

                var sentMsg = await msg.Channel.SendMessageAsync("This is a virtual 6-chamber Revoler, to proceed type one of the following commands.", embed: eb);

                await Task.Delay(10000);
                await msg.DeleteAsync();
                await sentMsg.DeleteAsync();
            });
            return Task.CompletedTask;
        }
    }

    class Roulette1 : IDiscordCommand
    {
        public string Name => "roulette_1";

        public string Help => "Use ;;Roulette for information";

        public string Syntax => "";

        public string Permission => "default";

        public Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            Task.Run(async () =>
            {
                var randomObject = new Random();

                var sentMsg = await msg.Channel.SendMessageAsync("Rolling Chamber...");
                string msg1 = "";
                await Task.Delay(2000);

                switch (randomObject.Next(1, 6 + 1))
                {
                    case 2:
                        msg1 = $"**BOOM** {msg.Author.Mention} Will forever be missed!";
                        break;

                    default:
                        msg1 = $"*click* {msg.Author.Mention} Gets to live another day!";
                        break;
                }
                var sentMsg1 = await msg.Channel.SendMessageAsync(msg1);

                await Task.Delay(10000);

                await sentMsg.DeleteAsync();
                await sentMsg1.DeleteAsync();
                await msg.DeleteAsync();
            });
            return Task.CompletedTask;
        }
    }

    class Roulette2 : IDiscordCommand
    {
        public string Name => "roulette_2";

        public string Help => "Use ;;Roulette for information";

        public string Syntax => "";

        public string Permission => "default";

        public Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            Task.Run(async () =>
            {
                var randomObject = new Random();

                var sentMsg = await msg.Channel.SendMessageAsync("Rolling Chamber...");
                string msg1 = "";
                await Task.Delay(2000);

                switch (randomObject.Next(1, 6 + 1))
                {
                    case 2:
                        msg1 = $"**BOOM** {msg.Author.Mention} Will forever be missed!";
                        break;

                    case 3:
                        msg1 = $"**BOOM** {msg.Author.Mention} Will forever be missed!";
                        break;

                    default:
                        msg1 = $"*click* {msg.Author.Mention} Gets to live another day!";
                        break;
                }
                var sentMsg1 = await msg.Channel.SendMessageAsync(msg1);

                await Task.Delay(10000);

                await sentMsg.DeleteAsync();
                await sentMsg1.DeleteAsync();
                await msg.DeleteAsync();
            });
            return Task.CompletedTask;
        }
    }

    class Roulette3 : IDiscordCommand
    {
        public string Name => "roulette_3";

        public string Help => "Use ;;Roulette for information";

        public string Syntax => "";

        public string Permission => "default";

        public Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            Task.Run(async () =>
            {
                var randomObject = new Random();

                var sentMsg = await msg.Channel.SendMessageAsync("Rolling Chamber...");
                string msg1 = "";
                await Task.Delay(2000);

                switch (randomObject.Next(1, 6 + 1))
                {
                    case 2:
                        msg1 = $"**BOOM** {msg.Author.Mention} Will forever be missed!";
                        break;

                    case 3:
                        msg1 = $"**BOOM** {msg.Author.Mention} Will forever be missed!";
                        break;

                    case 6:
                        msg1 = $"**BOOM** {msg.Author.Mention} Will forever be missed!";
                        break;

                    default:
                        msg1 = $"*click* {msg.Author.Mention} Gets to live another day!";
                        break;
                }
                var sentMsg1 = await msg.Channel.SendMessageAsync(msg1);

                await Task.Delay(10000);

                await sentMsg.DeleteAsync();
                await sentMsg1.DeleteAsync();
                await msg.DeleteAsync();
            });
            return Task.CompletedTask;
        }
    }

    class Roulette4 : IDiscordCommand
    {
        public string Name => "roulette_4";

        public string Help => "Use ;;Roulette for information";

        public string Syntax => "";

        public string Permission => "default";

        public Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            Task.Run(async () =>
            {
                var randomObject = new Random();

                var sentMsg = await msg.Channel.SendMessageAsync("Rolling Chamber...");
                string msg1 = "";
                await Task.Delay(2000);

                switch (randomObject.Next(1, 6 + 1))
                {
                    case 1:
                        msg1 = $"*click* {msg.Author.Mention} Gets to live another day!";
                        break;

                    case 4:
                        msg1 = $"*click* {msg.Author.Mention} Gets to live another day!";
                        break;

                    default:
                        msg1 = $"**BOOM** {msg.Author.Mention} Will forever be missed!";
                        break;
                }
                var sentMsg1 = await msg.Channel.SendMessageAsync(msg1);

                await Task.Delay(10000);

                await sentMsg.DeleteAsync();
                await sentMsg1.DeleteAsync();
                await msg.DeleteAsync();
            });
            return Task.CompletedTask;
        }
    }

    class Roulette5 : IDiscordCommand
    {
        public string Name => "roulette_5";

        public string Help => "Use ;;Roulette for information";

        public string Syntax => "";

        public string Permission => "default";

        public Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            Task.Run(async () =>
            {
                var randomObject = new Random();

                var sentMsg = await msg.Channel.SendMessageAsync("Rolling Chamber...");
                string msg1 = "";
                await Task.Delay(2000);

                switch (randomObject.Next(1, 6 + 1))
                {
                    case 5:
                        msg1 = $"*click* {msg.Author.Mention} Gets to live another day!";
                        break;

                    default:
                        msg1 = $"**BOOM** {msg.Author.Mention} Will forever be missed!";
                        break;
                }
                var sentMsg1 = await msg.Channel.SendMessageAsync(msg1);

                await Task.Delay(10000);

                await sentMsg.DeleteAsync();
                await sentMsg1.DeleteAsync();
                await msg.DeleteAsync();
            });
            return Task.CompletedTask;
        }
    }

    class Staff : IDiscordCommand
    {
        public string Name => "staff";

        public string Help => "Shows all the current members of the staff";

        public string Syntax => "";

        public string Permission => "default";

        public Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            Task.Run(async () =>
            {
                EmbedBuilder eb = new EmbedBuilder();

                eb.AddField("Username: @Tactical Pug", "Steam Account: http://steamcommunity.com/id/Beafraid98/");
                eb.AddField("Username: @TheWolfenGang XP", "Steam Account: http://steamcommunity.com/profiles/76561198252378620/");
                eb.AddField("Username: @Boot's & Cat's", "Steam Account: https://steamcommunity.com/profiles/76561194136173112");
                eb.AddField("Username: @PouGamer (Support)", "Steam Account: http://steamcommunity.com/profiles/76561198312811780/");

                var sentMsg = await msg.Channel.SendMessageAsync("All the current server moderators.", embed: eb);

                await Task.Delay(10000);
                await msg.DeleteAsync();
                await sentMsg.DeleteAsync();
            });
            return Task.CompletedTask;
        }
    }

    class Apply : IDiscordCommand
    {
        public string Name => "apply";

        public string Help => "Apply to anything using this command";

        public string Syntax => "";

        public string Permission => "default";

        public Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {

            Task.Run(async () =>
            {
                if (Program.Configuration.Instance.Registered.Contains(msg.Author.Mention))

                {
                    await msg.Author.GetOrCreateDMChannelAsync();
                    await msg.Author.SendMessageAsync("You have already applied!");

                    await msg.DeleteAsync();

                    return;
                }
                else
                {
                    await msg.Author.GetOrCreateDMChannelAsync();
                    await msg.Author.SendMessageAsync("You have been registered!");

                    Program.Configuration.Instance.Registered.Add(msg.Author.Username);

                    Program.Configuration.Save();

                    await msg.DeleteAsync();
                }
            });
            return Task.CompletedTask;
        }
    }

    class CheckApply : IDiscordCommand
    {
        public string Name => "checkapply";

        public string Help => "Checks who has applied (only executable by moderators)";

        public string Syntax => "";

        public string Permission => "admin";

        public Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            Task.Run(async () =>
            {
                await msg.Author.GetOrCreateDMChannelAsync();
                await msg.Author.SendMessageAsync(Program.Configuration.Instance.Registered.Count > 0 ? string.Join("\n", Program.Configuration.Instance.Registered) : "No one is registered");

                Program.Configuration.Save();

                await msg.DeleteAsync();
            });
            return Task.CompletedTask;
        }
    }

    class ApplyClear : IDiscordCommand
    {
        public string Name => "applyclear";

        public string Help => "Clear employment list (only executable by moderators)";

        public string Syntax => "";

        public string Permission => "admin";

        public Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {

            Task.Run(async () =>
            {
                Program.Configuration.Instance.Registered.Clear();

                Program.Configuration.Save();

                await msg.DeleteAsync();
            });
            return Task.CompletedTask;
        }
    }


    class Ban : Program, IDiscordCommand
    {
        public string Name => "ban";

        public string Help => "Ban a user (only executable by moderators)";

        public string Syntax => "<@username> (reason)";

        public string Permission => "admin";

        public Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {

            Task.Run(async () =>
            {
                if (parameters.Length < 2) return;

                string targetId = msg.MentionedUsers.Count == 1 ? msg.MentionedUsers.First().Id.ToString() : parameters[0];
                SocketGuild server = ((SocketGuildChannel)msg.Channel).Guild;
                SocketGuildUser target = server.Users.FirstOrDefault(x => x.Id.ToString() == targetId);

                if (target == null)
                {
                    await msg.Channel.SendMessageAsync($"Correct Usage: `;;ban <@username> (reason)`");
                    return;
                }

                var allBans = await server.GetBansAsync();
                bool isBanned = allBans.Any(x => x.User.Id == target.Id);

                if (!isBanned)
                {
                    var senderHighest = ((SocketGuildUser)msg.Author).Hierarchy;

                    if (target.Hierarchy < senderHighest)
                    {
                        try
                        {
                            var dmChannel = await target.GetOrCreateDMChannelAsync();
                            await dmChannel.SendMessageAsync($"You have been banned from **{server.Name}** by Moderator **{msg.Author}**. Reason: **{String.Join(" ", parameters.Skip(1))}**");
                        }
                        catch (Exception e)
                        {
                            await msg.Author.GetOrCreateDMChannelAsync();
                            await msg.Author.SendMessageAsync($"Failed to send DM to **{target.Username}.\nError message: {e.Message}");
                        }

                        var TextChannelLogs = client.GetChannel(353561970038931458) as SocketTextChannel;

                        EmbedBuilder eb = new EmbedBuilder();

                        eb.Color = Color.Red;

                        eb.AddField("Case:", $"{Name}");
                        eb.AddField("Target", $"{target.Mention}");
                        eb.AddField($"Moderator: ", $"{msg.Author.Mention}");
                        eb.AddField($"Reason:", $"{String.Join(" ", parameters.Skip(1))}");

                        await TextChannelLogs.SendMessageAsync("", embed: eb);

                        await server.AddBanAsync(target);
                        await msg.Channel.SendMessageAsync($"**{target.Username}** has been banned by Moderator **{msg.Author}**. Reason: **{String.Join(" ", parameters.Skip(1))}**");
                    }
                }
            });
            return Task.CompletedTask;
        }
    }



    public class Warn : IDiscordCommand
    {
        public string Name => "Warn";

        public string Help => "Warn a user (only executable by moderators)";

        public string Syntax => "<@username> <reason>";

        public string Permission => "admin";

        public async Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            if (parameters.Length < 2) return;

            string targetId = msg.MentionedUsers.Count == 1 ? msg.MentionedUsers.First().Id.ToString() : parameters[0];
            SocketGuild server = ((SocketGuildChannel)msg.Channel).Guild;
            SocketGuildUser target = server.Users.FirstOrDefault(x => x.Id.ToString() == targetId);

            if (target == null)
            {
                await msg.Channel.SendMessageAsync($"Correct Usage: `;;warn {Syntax}");
                return;
            }
            var dmChannel = await target.GetOrCreateDMChannelAsync();
            var TCLog = Program.client.GetChannel(353561970038931458) as SocketTextChannel;

            await dmChannel.SendMessageAsync($"You have been warned by {msg.Author.Mention}. Reason: **{String.Join(" ", parameters.Skip(1))}**");
            await dmChannel.SendMessageAsync("This will be your first and last warning, if you do this again it will result in a ban!");

            EmbedBuilder eb = new EmbedBuilder();

            eb.Color = Color.DarkBlue;

            eb.AddField("Case:", $"{Name}");
            eb.AddField("Target:", $"{target.Mention}");
            eb.AddField($"Moderator: ", $"{msg.Author.Mention}");
            eb.AddField($"Reason:", $"{String.Join(" ", parameters.Skip(1))}");

            await TCLog.SendMessageAsync("", embed: eb);
        }
    }

    public class Kick : IDiscordCommand
    {
        public string Name => "Kick";

        public string Help => "Kick a user (only executable by moderators)";

        public string Syntax => "<@username> (reason)";

        public string Permission => "admin";

        public Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {

            Task.Run(async () =>
            {
                if (parameters.Length < 2) return;

                string targetId = msg.MentionedUsers.Count == 1 ? msg.MentionedUsers.First().Id.ToString() : parameters[0];
                SocketGuild server = ((SocketGuildChannel)msg.Channel).Guild;
                SocketGuildUser target = server.Users.FirstOrDefault(x => x.Id.ToString() == targetId);

                if (target == null)
                {
                    await msg.Channel.SendMessageAsync($"Correct Usage: `;;ban {Syntax}`");
                    return;
                }

                var dmChannel = await target.GetOrCreateDMChannelAsync();

                await dmChannel.SendMessageAsync($"You have been kicked from **{server.Name}** By Moderator **{msg.Author.Mention}**. Reason: **{String.Join(" ", parameters.Skip(1))}**");
                await msg.Channel.SendMessageAsync($"{target.Username} has been Kicked by Moderator {msg.Author}. Reason: {String.Join(" ", parameters.Skip(1))}");

                var TCLog = Program.client.GetChannel(353561970038931458) as SocketTextChannel;

                EmbedBuilder eb = new EmbedBuilder();

                eb.Color = Color.LightOrange;

                eb.AddField("Case:", $"{Name}");
                eb.AddField("Target", $"{target.Mention}");
                eb.AddField($"Moderator: ", $"{msg.Author.Mention}");
                eb.AddField($"Reason:", $"{String.Join(" ", parameters.Skip(1))}");

                await TCLog.SendMessageAsync("", embed: eb);

                await target.KickAsync();
            });
            return Task.CompletedTask;
        }
    }

    public class Magic8ball : IDiscordCommand
    {
        public string Name => "magic8ball";

        public string Help => "Ask a question you want aswered";

        public string Syntax => "<question>";

        public string Permission => "default";

        public async Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            var randomObject = new Random();
            var rand2 = new Random();
            var content = msg.Content;

            string msg1 = "";

            Task.Run(async () =>
            {
                if (parameters.Length < 2)
                {
                    msg1 = $"Correct Usage: `;;{Name} {Syntax}`";

                    var sentMsg = await msg.Channel.SendMessageAsync(msg1);

                    await Task.Delay(5000);

                    msg.DeleteAsync();
                    sentMsg.DeleteAsync();

                    return;
                }

                if (!content.Contains("?"))
                {
                    msg1 = "Please ask a valid question. (Including a question mark)";

                    var sentMsg = await msg.Channel.SendMessageAsync(msg1);

                    await Task.Delay(5000);

                    msg.DeleteAsync();
                    sentMsg.DeleteAsync();

                    return;
                }

                switch (randomObject.Next(1, 12 + 1))
                {
                    case 1:
                        msg1 = $"Yes";
                        break;

                    case 2:
                        msg1 = $"Yea";
                        break;

                    case 3:
                        msg1 = $"I don't know about that :thinking:";
                        break;

                    case 4:
                        msg1 = $"No";
                        break;

                    case 5:
                        msg1 = $"Nope.";
                        break;

                    case 6:
                        msg1 = $"Deffinitely not!";
                        break;

                    case 7:
                        msg1 = $"Of course!";
                        break;

                    case 8:
                        msg1 = $"No, lol :joy:";
                        break;

                    case 9:
                        msg1 = $"Uh huh";
                        break;

                    case 10:
                        msg1 = $"YEA!!";
                        break;

                    case 11:
                        msg1 = $"EWW, NO!";
                        break;

                    case 12:
                        msg1 = $"Maybe..";
                        break;

                    default:
                        msg1 = $"Let me think for a second...";
                        Task.Delay(3000);

                        switch (rand2.Next(1, 2 + 1))
                        {
                            case 1:
                                msg1 = $"I'd have to say no on that one";
                                break;

                            case 2:
                                msg1 = $"I'd say Yes.";
                                break;
                        }
                        break;
                }
                var sentMsg1 = await msg.Channel.SendMessageAsync(msg1);

                await Task.Delay(10000);

                await msg.DeleteAsync();
                await sentMsg1.DeleteAsync();
            });
        }
    }

    public class Freestyle : IDiscordCommand
    {
        public string Name => "freestyle";

        public string Help => "Starts a loop of words for any occuring freestyle battle (needs a moderator to start)";

        public string Syntax => "<diffculty>";

        public string Permission => "admin";

        public async Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
#pragma warning disable CS1998
            Task.Run(async () =>
            {
                if (parameters.Length < 1)
                {
                    await msg.Channel.SendMessageAsync($"**Correct usage:** `;;{Name} {Syntax}`");
                    return;
                }

                if (parameters.Length > 1)
                {
                    await msg.Channel.SendMessageAsync($"**Correct usage:** `;;{Name} {Syntax}`");
                    return;
                }

                var TCfreestyle = Program.client.GetChannel(383276102853984266) as SocketTextChannel;
                var content = msg.Content;

                if (parameters.Contains("easy"))
                {
                    await msg.Channel.SendMessageAsync($"Starting word loop in **#{TCfreestyle.Name}** ({TCfreestyle.Id})");

                    Task.Run(async () =>
                    {
                        while (true)
                        {
                            FreestyleEasy.FreestyleEZ();
                            await Task.Delay(6000);
                        }
                    });
                }

                if (content.ToLower() != "easy")
                {
                    await msg.Channel.SendMessageAsync($"**Correct usage:** `;;{Name} {Syntax}`");
                    return;
                }
            });
#pragma warning restore CS1998
        }
    }

    public class ServerInfo : IDiscordCommand
    {
        public string Name => "ServerInfo";

        public string Help => "Shows the server info";

        public string Syntax => "";

        public string Permission => "default";

        public async Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            if (parameters.Length > 0)
            {
                await msg.Channel.SendMessageAsync($"**This message does not take parameters**");
            }

            SocketGuild server = ((SocketGuildChannel)msg.Channel).Guild;

            EmbedBuilder eb = new EmbedBuilder();
            EmbedFooterBuilder ef = new EmbedFooterBuilder();

            ef.WithText($"{server.Name}");
            eb.WithFooter(footer: ef);

            eb.ThumbnailUrl = $"{server.IconUrl}";
            eb.AddInlineField("Owner", $"{server.Owner}");
            eb.AddInlineField("Member Count", $"{server.MemberCount}");
            eb.AddInlineField("Creation Date", $"{server.CreatedAt.LocalDateTime}");
            eb.AddInlineField("Region", $"{server.VoiceRegionId.ToUpperInvariant()}");
            eb.AddInlineField("Text Channels", $"{server.TextChannels.Count}");
            eb.AddInlineField("Voice Channels", $"{server.VoiceChannels.Count}");

            eb.WithCurrentTimestamp();

            await msg.Channel.SendMessageAsync($"", embed: eb);
        }
    }

    public class UserInfo : IDiscordCommand
    {
        public string Name => "UserInfo";

        public string Help => "Shows information about the caller";

        public string Syntax => "(@username)";

        public string Permission => "default";

        public Task ExecuteAsync(SocketUserMessage msg, string[] parameters)
        {
            Task.Run(async () =>
            {
                    EmbedBuilder eb = new EmbedBuilder();
                    EmbedFooterBuilder ef = new EmbedFooterBuilder();

                    string targetId = msg.MentionedUsers.Count == 1 ? msg.MentionedUsers.First().Id.ToString() : parameters[1];
                    SocketGuild server = ((SocketGuildChannel)msg.Channel).Guild;
                    SocketGuildUser target = server.Users.FirstOrDefault(x => x.Id.ToString() == targetId);
                    var author = msg.Author;

                if (parameters.Length > 1)
                {
                    msg.Channel.SendMessageAsync($"Correct Usage: `;;{Name} {Syntax}");
                }

                if(target == null)
                {
                    ef.WithText(author.Username);
                    eb.WithFooter(footer: ef);

                    eb.Color = Color.DarkTeal;

                    eb.AddInlineField("User Creation Date", $"{author.CreatedAt.DateTime}");
                    eb.AddInlineField("Currently Playing", $"{author.Game}");
                    eb.AddInlineField("Is Bot User", $"{author.IsBot}");
                    eb.AddInlineField("Status", $"{author.Status}");
                    eb.AddInlineField("Username", $"{author.Username}");

                    eb.WithCurrentTimestamp();

                    msg.Channel.SendMessageAsync($"", embed: eb);
                }

                ef.WithText(target.Nickname);
                    eb.WithFooter(footer: ef);

                    eb.ThumbnailUrl = author.GetAvatarUrl();

                    eb.AddInlineField("Username", $"{target.Username}");
                    eb.AddInlineField("Nickname", $"{target.Nickname}");
                    eb.AddInlineField("Join Date", $"{target.JoinedAt}");
                    eb.AddInlineField("Is Bot User", $"{target.IsBot}");
                    eb.AddInlineField("Status", $"{target.Status}");

                    await msg.Channel.SendMessageAsync("", embed: eb);
            });
            return Task.CompletedTask;
        }
    }
}
