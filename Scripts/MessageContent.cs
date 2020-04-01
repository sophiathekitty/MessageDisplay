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
        public Dictionary<string, object> data;

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
            SetContent(_text, _title, null, _type);
        }
        public MessageContent(string _text, MessageType _type)
        {
            SetContent(_text, "", null, _type);
        }
        public MessageContent(string _text)
        {
            SetContent(_text);
        }
        public MessageContent(string _text, string _title)
        {
            SetContent(_text, _title);
        }
        public MessageContent(string _text, string _title, Sprite _icon)
        {
            SetContent(_text, _title, _icon);
        }
        public MessageContent(Sprite _icon, string _title, string _text, MessageType _type)
        {
            SetContent(_text, _title, _icon, _type);
        }
        public MessageContent(Sprite _icon, string _text, MessageType _type)
        {
            SetContent(_text, "", _icon, _type);
        }
        public MessageContent(Sprite _icon, string _text)
        {
            SetContent(_text, "", _icon);
        }
        public MessageContent(string _title, string _text, MessageType _type, Dictionary<string,object> _data)
        {
            SetContent(_text, _title, null, _type);
            data = _data;
        }
        public MessageContent(string _text, MessageType _type, Dictionary<string, object> _data)
        {
            SetContent(_text, "", null, _type);
            data = _data;
        }
        public MessageContent(string _text, Dictionary<string, object> _data)
        {
            SetContent(_text);
            data = _data;
        }
        public MessageContent(Sprite _icon, string _title, string _text, MessageType _type, Dictionary<string, object> _data)
        {
            SetContent(_text, _title, _icon, _type);
            data = _data;
        }
        public MessageContent(Sprite _icon, string _text, MessageType _type, Dictionary<string, object> _data)
        {
            SetContent(_text, "", _icon, _type);
            data = _data;
        }
        public MessageContent(Sprite _icon, string _text, Dictionary<string, object> _data)
        {
            SetContent(_text, "", _icon);
            data = _data;
        }

        void SetContent(string _text, string _title = "", Sprite _icon = null, MessageType _type = null)
        {
            icon = _icon;
            title = _title;
            text = _text;
            type = _type;
        }

    }
}