using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TextAutoHeight : MonoBehaviour
{
    TextMeshProUGUI textPro;
    Text text;
    RectTransform rectTransform;
    RectTransform parentTransform;
    public bool targetParent;
    public float padding = 5;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        textPro = GetComponent<TextMeshProUGUI>();
        if (targetParent)
            parentTransform = transform.parent.GetComponent<RectTransform>();
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("before: " + rectTransform.position.y + " + " + textPro.preferredHeight + " = " + parentTransform.sizeDelta.y);
        if (targetParent)
            parentTransform.sizeDelta = new Vector2(parentTransform.sizeDelta.x, textPro.preferredHeight + padding);
        else 
            rectTransform.sizeDelta.Set(rectTransform.sizeDelta.x, textPro.preferredHeight + 5);
        Debug.Log("after: " + rectTransform.sizeDelta.y);
    }
}
