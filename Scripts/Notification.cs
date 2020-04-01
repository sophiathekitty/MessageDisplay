using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MessageWindowSystem
{
    [System.Serializable]
    public class Notification
    {
        public MessageContent content;
        public MessageType type;
        public GameObject sender;
        public NotificationHandler handler;
        private bool _active = true;
        public bool acting
        {
            get
            {
                return _active;
            }
        }
        private float _time;
        public float time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
            }
        }

        public Notification() { }
        public Notification(string text)
        {
            SetNotification(new MessageContent(text));
        }
        public Notification(string text, string title)
        {
            SetNotification(new MessageContent(text, title));
        }
        public Notification(string text, string title, Sprite icon)
        {
            SetNotification(new MessageContent(text, title, icon));
        }
        public Notification(MessageContent message)
        {
            SetNotification(message);
        }
        public Notification(MessageContent message, MessageType messageType)
        {
            SetNotification(message);
            type = messageType;
        }

        void SetNotification(MessageContent message)
        {
            content = message;
            _time = Time.time;
        }

        public void Clear()
        {
            content.active = false;
            if (handler != null)
                handler.notifications.Remove(this);
        }
    }
}