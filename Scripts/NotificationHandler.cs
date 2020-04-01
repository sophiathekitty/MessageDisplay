using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MessageWindowSystem
{
    public class NotificationHandler : MonoBehaviour
    {
        public List<Notification> notifications;
        public MessageWindow messageWindow;

        public Notification Add(string text, string title, Sprite icon = null)
        {
            Notification notification = new Notification(messageWindow.AddMessage(text, title, icon));
            notifications.Add(notification);
            return notification;
        }
        public Notification Add(string text, string title, MessageType type, Sprite icon = null)
        {
            Notification notification = new Notification(messageWindow.AddMessage(text, title, type, icon),type);
            notifications.Add(notification);
            return notification;
        }
        public Notification Add(MessageContent message)
        {
            Notification notification = new Notification(message);
            messageWindow.AddMessage(message);
            return notification;
        }

        public void Clear()
        {
            foreach (Notification notification in notifications)
                notification.Clear();
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