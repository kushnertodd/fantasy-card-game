using System;
using System.Collections.Generic;

namespace fantasy_card_game_lib
{
    public class Errors
    {
        private List<Error> errors = new List<Error>();
        public enum MessageId
        {
            MISC_TEXT,
            CARD_NOT_FOUND,
            NO_CARDS,
            NOT_ENOUGH_MANA,
            PLAYER_NOT_FOUND,
            UNKNOWN_CARD_TYPE
        }
        static Dictionary<MessageId, string> messageNames = new Dictionary<MessageId, string>()
        {
            { MessageId.MISC_TEXT, "message"},
            { MessageId.CARD_NOT_FOUND, "card not found"},
            { MessageId.NO_CARDS, "no cards"},
            { MessageId.NOT_ENOUGH_MANA, "not enough mana"},
            { MessageId.PLAYER_NOT_FOUND, "player not found"},
            { MessageId.UNKNOWN_CARD_TYPE, "unknown card type"}
        };
        public class Error
        {
            public MessageId messageId;
            private Object[] arguments;
            public Error(MessageId messageId, Object[] arguments)
            {
                this.messageId = messageId;
                this.arguments = arguments;
            }
            public override string ToString()
            {
                string text = "";
                switch (messageId)
                {
                    case MessageId.MISC_TEXT:
                        {
                            text = (string)arguments[0];
                            break;
                        }
                    case MessageId.CARD_NOT_FOUND:
                        {
                            Card card = (Card)arguments[0];
                            text = card.ToString();
                            break;
                        }
                    case MessageId.NO_CARDS:
                        {
                            break;
                        }
                    case MessageId.NOT_ENOUGH_MANA:
                        {
                            int cost = (int)arguments[0];
                            int manaCount = (int)arguments[1];
                            text = manaCount + " not enough for cost " + cost;
                            break;
                        }
                    case MessageId.PLAYER_NOT_FOUND:
                        {
                            text = (string)arguments[0];
                            break;
                        }
                    case MessageId.UNKNOWN_CARD_TYPE:
                        {
                            text = (string)arguments[0];
                            break;
                        }
                    default:
                        break;
                }
                string message = messageNames[messageId] + ": " + text;
                return message;
            }
        }
        public bool Have { get { return errors.Count > 0; } }
        public void Add(MessageId messageId, params Object[] arguments)
        {
            errors.Add(new Error(messageId, arguments));
        }
        public Error Select(MessageId messageId)
        {
            return errors.Find(error => error.messageId == messageId)!;
        }
        public override string ToString()
        {
            string message = "";
            foreach (Error error in errors)
            {
                message += error + "\n";
            }
            return message;
        }
    }
}
