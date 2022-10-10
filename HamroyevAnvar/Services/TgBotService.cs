using HamroyevAnvar.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace HamroyevAnvar.Services;

public class TgBotService
{
    private ITelegramBotClient botClient;
    private readonly TgBot _tgBot;

    [Obsolete]
    public TgBotService(TgBot tgBot)
    {
        _tgBot = tgBot;
        botClient = new TelegramBotClient(tgBot.Token);
        //botClient.OnMessage += BotClient_OnMessage;

        botClient.StartReceiving();
    }

    public async Task<string> SendMessageToAdmins(Models.Contact contact)
    {
        int i = 0;
        try
        {
            foreach (long adminId in _tgBot.AdminIds)
            {
                await botClient.SendTextMessageAsync(adminId,
                    "Saytdan yangi murojaat keldi...\n\n\n"
                    + $"<b>Ismi:</b> {contact.FullName}\n"
                    + $"<b>Tel:</b> {contact.Tel}\n"
                    + $"<b>Mavzu:</b> {contact.Subject}\n\n"
                    + $"<b>Xabar:</b> {contact.Text}",
                    ParseMode.Html);
                i++;
            }
            return "Xabaringiz muvaffaqiyatli yuborildi!";
        }
        catch
        {
            if (i > 0)
                return "Xabaringiz muvaffaqiyatli yuborildi!";
            return "Xabarni yuborishda xatolik sodir bo'ldi.\n"
                + "Iltimos saytda keltirilgan telefon raqamlarga bog'laning!";
        }
    }

    //private async void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
    //{
    //    long chatId = e.Message.Chat.Id;
    //    string msg = e.Message.Text;
    //    if (msg == "/start")
    //    {
    //        await botClient.SendTextMessageAsync(chatId,
    //            $"Assalomu aleykum hurmatli <b>{e.Message.Chat.FirstName}</b>.\n"
    //            + $"Bu bot <b>Hamroyev Anvar</b> ga tegishli, shaxsiy sayt: {0}",
    //            ParseMode.Html);
    //        return;
    //    }
    //    await botClient.SendTextMessageAsync(chatId,
    //        $"Hurmatli <b>{e.Message.Chat.FirstName}</b> bot bunday amalni bajarmaydi!",
    //        replyToMessageId: e.Message.MessageId,
    //        parseMode: ParseMode.Html);
    //}

    [Obsolete]
    ~TgBotService()
    {
        botClient.StopReceiving();
        botClient = null;
    }
}
