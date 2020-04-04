using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour
{
    private static FloatingText popupText;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("Canvas");
        if(!popupText)
        {
            popupText = Resources.Load<FloatingText>("Prefabs/PopupTextParent");
        }
    }

    public static void CreateFloatingText(string text, Vector3 pos)
    {
        FloatingText instance = Instantiate(popupText);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(pos);
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPosition;
        instance.SetText(text);
    }
}
