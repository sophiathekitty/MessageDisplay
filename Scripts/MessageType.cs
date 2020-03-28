using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MessageWindowSystem
{
    [CreateAssetMenu(menuName ="UI/MessageType")]
    public class MessageType : ScriptableObject
    {
        public Color text_color = new Color(0, 0, 0, 1);
        public Color icon_color = new Color(0, 0, 0, 1);
        public TMPro.TMP_FontAsset fontAsset;
        public Sprite default_icon;
        public GameObject prefab;
        public float display_time;
    }
}