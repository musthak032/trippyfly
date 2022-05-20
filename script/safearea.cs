using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safearea : MonoBehaviour
{
    RectTransform rectransform;
    Rect safeArea;
    Vector2 minanchor;
    Vector2 maxanchor;

    private void Awake()
    {
        rectransform = GetComponent<RectTransform>();
        safeArea = Screen.safeArea;
        minanchor = safeArea.position;
        maxanchor = minanchor + safeArea.size;

        minanchor.x /= Screen.width;
        minanchor.y /= Screen.height;   
        maxanchor.x /= Screen.width;
        maxanchor.y /= Screen.height;

        rectransform.anchorMin = minanchor;
        rectransform.anchorMax = maxanchor;
        
    }
}
