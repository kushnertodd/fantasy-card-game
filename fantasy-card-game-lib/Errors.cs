using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class Errors
    {
        private List<Error> errors;
        public enum MessageId
        {
            CARD_NOT_FOUND,
            NO_CARDS,
            PLAYER_NOT_FOUND
        }
        static Dictionary<MessageId, string> messageNames = new Dictionary<MessageId, string>()
        {
            { MessageId.CARD_NOT_FOUND, "card not found"},
            { MessageId.NO_CARDS, "no cards"},
            { MessageId.PLAYER_NOT_FOUND, "player not found"}
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
                    case MessageId.PLAYER_NOT_FOUND:
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
