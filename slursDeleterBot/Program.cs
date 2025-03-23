using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace botScript
{
    class Program
    {
        static string[] engSlurs = { "fuck", "shit", "cum", "ass", "nig", "pussy" };
        static string[] rusSlurs = { "бля", "сук", "говн", "ху", "пизд", "дерьм" , "ёп", "еб", "ёб", "сра", "сре", "срё", "сри"};

        static void Main(string[] args)
        {
            var bot = new TelegramBotClient("7095799167:AAHoPWwniRWkHHKZrs9aa3HS3TA2lsk3cSI");
            bot.StartReceiving(UpdateHandler, ErrorHandler);
            Console.WriteLine("Bot started");
            Console.ReadLine();
        }

        private static async Task ErrorHandler(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        private static async Task UpdateHandler(ITelegramBotClient client, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (message.Text != null)
            {
                if (engSlurs.Any(message.Text.ToLower().Contains) || rusSlurs.Any(message.Text.ToLower().Contains))
                {
                    await client.DeleteMessage(message.Chat.Id, message.Id);
                }
            }
        }
    }
}
