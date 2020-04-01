using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MessageWindowSystem
{
    public class MessageWindow : MonoBehaviour
    {
        public List<MessageDisplay> messages = new List<MessageDisplay>();
        public MessageType type;

        public List<MessageContent> pendingMessages = new List<MessageContent>();
        public int max_messages = 5;
        public bool queue_messages = true;

        public MessageContent AddMessage(MessageContent message)
        {
            pendingMessages.Add(message);
            return message;
        }
        public MessageContent AddMessage(string text, Sprite icon = null)
        {
            return AddMessage(text,"", type, icon);
        }
        public MessageContent AddMessage(string text, MessageType messageType, Sprite icon = null)
        {
            return AddMessage(text, "", messageType, icon);
        }
        public MessageContent AddMessage(string text, string title, Sprite icon = null)
        {
            return AddMessage(text, title, type, icon);
        }
        public MessageContent AddMessage(string text, string title, MessageType messageType, Sprite icon = null)
        {
            return AddMessage(new MessageContent(icon, title, text, messageType));
            //pendingMessages.Add(msg);
            //return msg;
        }
        void SpawnMessage(MessageContent msg) { 
            GameObject gameObject = Instantiate(msg.type.prefab, transform);
            MessageDisplay message = gameObject.GetComponent<MessageDisplay>();
            message.ApplyMessage(msg);
            pendingMessages.Remove(msg);
            messages.Add(message);
            message.window = this;
        }
        void RemoveMessage(MessageDisplay msg)
        {
            msg.life_time = 0;
        }
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (queue_messages)
            {
                if (pendingMessages.Count > 0 && messages.Count < max_messages)
                    SpawnMessage(pendingMessages[0]);
            }
            else
            {
                if(pendingMessages.Count > 0)
                {
                    if (messages.Count >= max_messages)
                        RemoveMessage(messages[0]);
                    SpawnMessage(pendingMessages[0]);
                }
            }
        }
    }
}
