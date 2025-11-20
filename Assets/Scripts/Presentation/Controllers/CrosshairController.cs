using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent as RectTransform, Input.mousePosition, null, out mousePos);
        
        _rectTransform.anchoredPosition = mousePos;
    }
}
