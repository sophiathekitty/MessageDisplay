using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MessageWindowSystem
{

    public class MessageContent
    {
        public Sprite icon;
        public string title;
        public string text;
        public MessageType type;
        public float priority = 0.5f;
        public bool active = true;

        public float display_time
        {
            get
            {
                if (type != null)
                    return type.display_time;
                return 5f;
            }
        }


        public MessageContent(string _title, string _text, MessageType _type)
        {
            title = _title;
            text = _text;
            type = _type;
            icon = _type.default_icon;
        }
        public MessageContent(string _text, MessageType _type)
        {
            text = _text;
            type = _type;
            icon = _type.default_icon;
        }
        public MessageContent(string _text)
        {
            text = _text;
        }

        public MessageContent(Sprite _icon, string _title, string _text, MessageType _type)
        {
            icon = _icon;
            title = _title;
            text = _text;
            type = _type;
        }
        public MessageContent(Sprite _icon, string _text, MessageType _type)
        {
            icon = _icon;
            text = _text;
            type = _type;
        }
        public MessageContent(Sprite _icon, string _text)
        {
            icon = _icon;
            text = _text;
        }

    }
}