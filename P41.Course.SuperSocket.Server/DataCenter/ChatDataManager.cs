using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41.Course.SuperSocket.Server.DataCenter
{
    public class ChatDataManager
    {
        private static Dictionary<string, List<ChatModel>> dictionary = new Dictionary<string, List<ChatModel>>();

        public static void Add(string userId, ChatModel model)
        {
            if (dictionary.ContainsKey(userId))
            {
                dictionary[userId].Add(model);
            }
            else
            {
                dictionary[userId] = new List<ChatModel>(){model};
            }
        }

        public static void Remove(string userId, string modelId)
        {
            if (dictionary.ContainsKey(userId))
            {
                dictionary[userId] = dictionary[userId].Where(m => m.Id != modelId).ToList();
            }
        }

        public static void SendLogin(string userId, Action<ChatModel> action)
        {
            if (dictionary.ContainsKey(userId))
            {
                foreach (ChatModel chatModel in dictionary[userId])
                {
                    action.Invoke(chatModel);
                    chatModel.State = ChatState.Sent;
                }
            }
        }

    }

}
