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
            AddMessage("testing some stuff?");
            AddMessage("still testing some stuff?");
            AddMessage("yup.... testing some stuff?");
            AddMessage("i hope this is testing some stuff?");
            AddMessage("well now i'm testing some stuff?");
            AddMessage("oh yeah we're testing some stuff?");
            AddMessage("somebody is testing some stuff?");
            AddMessage("even more testing some stuff?");
            AddMessage("i guess i'm testing some stuff?");
            AddMessage("why would i still be testing some stuff?");
            AddMessage("this sitll isn't done i'm still testing some stuff?");
            AddMessage("these are getting a bit long while i'm testing some stuff?");
            AddMessage("yay i'm finally done testing some stuff?");

        }

        // Update is called once per frame
        void Update()
        {
            if (pendingMessages.Count > 0 && messages.Count < max_messages)
                SpawnMessage(pendingMessages[0]);
        }
    }
}
