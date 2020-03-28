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


        public MessageDisplay AddMessage(string text, Sprite icon = null)
        {
            return AddMessage(text,"", type, icon);
        }
        public MessageDisplay AddMessage(string text, MessageType messageType, Sprite icon = null)
        {
            return AddMessage(text, "", messageType, icon);
        }
        public MessageDisplay AddMessage(string text, string title, Sprite icon = null)
        {
            return AddMessage(text, title, type, icon);
        }
        public MessageDisplay AddMessage(string text, string title, MessageType messageType, Sprite icon = null)
        {
            MessageContent msg = new MessageContent(icon, title, text, messageType);

            GameObject gameObject = Instantiate(type.prefab, transform);
            MessageDisplay message = gameObject.GetComponent<MessageDisplay>();
            message.text = text;
            message.title = title;
            message.icon = icon;
            message.ApplyType(messageType);
            return message;
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
