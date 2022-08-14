using ViberBot.Entities;
using ViberBot.Models;
using ViberBot.Models.SendMessage;

namespace ViberBot.ViberService.Mapper;

//I know that it's not mapper, I didn't come up with another name :)
public static class SendMessageMapper
{
    public static MessageBody GenerateMessageBodyForShowSumStatistic(string userId, Statistic sumStatistic, string imei)
    {
        TimeSpan lengthOfWalk = sumStatistic.TimeLength!.Value.Subtract(new DateTime(1900, 1, 1));
        return new MessageBody()
        {
            Receiver = userId,
            Sender = new Sender() {Name = "Misha"},
            Type = "text",
            Text =
                $"Всего прогулок: {sumStatistic.Id}\n" +
                $"Всего км пройдено: {sumStatistic.Distance}\n" +
                $"Всего времени: {(int)lengthOfWalk.TotalMinutes}:{lengthOfWalk.Seconds:00}",
            Keyboard = new Keyboard()
            {
                Type = "keyboard",
                Buttons = new List<Button>()
                {
                    new Button()
                    {
                        ActionType = "reply",
                        ActionBody = "top " + imei,
                        Text = "ТОП 10 прогулок",
                        TextSize = "regular"
                    }
                }
            }
        };
    }

    public static MessageBody GenerateMessageBodyForShowTopStatistic(string userId, IEnumerable<Statistic> topStatistics)
    {
        List<Button> buttons = new List<Button>();
        Button buttonModel = new Button()
        {
            Columns = 2,
            Rows = 1,
            BgColor = "#CBE9B3",
            ActionType = "none"
        };
        string[] nameOfColumns = new[]
        {
            "Название", "Километров", "Минут"
        };
        for (int i = 0; i < 3; i++)
        {
            buttons.Add(new Button()
            {
                Columns = 2,
                Rows = 1,
                BgColor = "#CBE9B3",
                ActionType = "none",
                Text = $"<b>{nameOfColumns[i]}<\\b>",
                TextSize = "small"
            });
        }

        foreach (Statistic statistic in topStatistics)
        {
            TimeSpan lengthOfWalk = 
                statistic.TimeLength!.Value.Subtract(new DateTime(1900, 1, 1));
            buttons.AddRange(new []
            {
                new Button()
                {
                    Columns = 2,
                    Rows = 1,
                    BgColor = "#CBE9B3",
                    ActionType = "none",
                    Text = $"Прогулка {statistic.Id}",
                    TextSize = "small"
                },
                new Button()
                {
                    Columns = 2,
                    Rows = 1,
                    BgColor = "#CBE9B3",
                    ActionType = "none",
                    Text = $"{statistic.Distance}",
                    TextSize = "small"
                },
                new Button()
                {
                    Columns = 2,
                    Rows = 1,
                    BgColor = "#CBE9B3",
                    ActionType = "none",
                    Text = $"{(int)lengthOfWalk.TotalMinutes}:{lengthOfWalk.Seconds:00}",
                    TextSize = "small"
                },
            });
        }
        return new MessageBody()
        {
            Receiver = userId,
            Sender = new Sender() {Name = "Misha"},
            Type = "rich_media",
            MinApiVersion = 7,
            Keyboard = new Keyboard()
            {
                Type = "keyboard",
                Buttons = new List<Button>()
                {
                    new Button()
                    {
                        ActionType = "reply",
                        ActionBody = "back",
                        Text = "Назад",
                        TextSize = "regular"
                    }
                }
            },
            RichMedia = new RichMedia()
            {
                Type = "rich_media",
                Buttons = buttons
            }
        };
    }

    public static MessageBody GenerateMessageBodyForMessage(string userId, string text)
    {
        return new MessageBody()
        {
            Receiver = userId,
            Sender = new Sender() {Name = "Misha"},
            Type = "text",
            Text = text
        };
    }
}