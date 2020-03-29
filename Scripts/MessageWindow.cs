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
            MessageContent msg = new MessageContent(icon, title, text, messageType);
            pendingMessages.Add(msg);
            return msg;
        }
        void SpawnMessage(MessageContent msg) { 
            GameObject gameObject = Instantiate(type.prefab, transform);
            MessageDisplay message = gameObject.GetComponent<MessageDisplay>();
            message.ApplyMessage(msg);
            pendingMessages.Remove(msg);
            messages.Add(message);
            message.window = this;
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (pendingMessages.Count > 0 && messages.Count < max_messages)
                SpawnMessage(pendingMessages[0]);
        }
    }
}
