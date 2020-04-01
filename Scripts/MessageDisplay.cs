using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace MessageWindowSystem
{
    public class MessageDisplay : MonoBehaviour
    {
        public TextMeshProUGUI textPro;
        public Text textBasic;
        public TextMeshProUGUI titlePro;
        public Text titleBasic;
        public Image image;
        public float life_time;
        public bool persistant = false;
        public float death_time = 5f;
        public MessageContent message;
        public MessageWindow window;
        private MessageType _type;

        private Animator animator;

        public string text
        {
            set
            {
                if (textBasic != null)
                    textBasic.text = value;
                if (textPro != null)
                    textPro.text = value;
            }
            get
            {
                if (textBasic != null)
                    return textBasic.text;
                if (textPro != null)
                    return textPro.text;
                return "";
            }
        }
        public string title
        {
            set
            {
                if (titleBasic != null)
                    titleBasic.text = value;
                if (titlePro != null)
                    titlePro.text = value;
            }
            get
            {
                if (titleBasic != null)
                    return titleBasic.text;
                if (titlePro != null)
                    return titlePro.text;
                return "";
            }
        }
        public Sprite icon
        {
            set
            {
                if (image != null)
                    image.sprite = value;
            }
            get
            {
                if (image != null)
                    return image.sprite;
                return null;
            }
        }
        public void ApplyMessage(MessageContent content)
        {
            message = content;
            title = content.title;
            text = content.text;
            icon = content.icon;
            life_time = content.display_time;
            ApplyType(content.type);
        }
        public void ApplyType(MessageType type)
        {
            if (_type == type)
                return;
            _type = type;
            if (textBasic != null)
                textBasic.color = type.text_color;
            if (textPro != null)
                textPro.color = type.text_color;
            if (image != null)
            {
                image.color = type.icon_color;
                if (image.sprite == null)
                {
                    icon = type.default_icon;
                    Debug.Log(image.sprite);
                }
            }
            if (type.display_time == 0)
                persistant = true;
            else
            {
                persistant = false;
                life_time = type.display_time;
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if(message != null)
            {
                title = message.title;
                text = message.text;
                if(message.icon != null)
                    icon = message.icon;
                //if (image != null)
                    //image.gameObject.SetActive(image.sprite == null);
                if (message.type != null)
                {
                    ApplyType(message.type);
                }
            }
            if (!message.active)
            {
                life_time = 0;
                persistant = false;
            }

            if (!persistant)
            {
                life_time -= Time.deltaTime;
                if (life_time < 0)
                {
                    if (animator != null)
                        animator.SetTrigger("Hide");
                    StartCoroutine("SelfDestruct");
                        
                }
            }
        }

        IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(death_time);
            window = transform.parent.GetComponent<MessageWindow>();
            window.messages.Remove(this);
            Destroy(gameObject);
        }
    }
}
