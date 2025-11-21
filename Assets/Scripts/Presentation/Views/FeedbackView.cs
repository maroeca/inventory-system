using UnityEngine;
using TMPro;
using System.Collections;

public class FeedbackView : MonoBehaviour
{
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private CanvasGroup canvasGroup;

    private Coroutine _fadeRoutine;

    public void Show(string message)
    {
        Debug.Log(message);
        messageText.text = message;

        if (_fadeRoutine != null)
            StopCoroutine(_fadeRoutine);

        _fadeRoutine = StartCoroutine(ShowRoutine());
    }

    private IEnumerator ShowRoutine()
    {
        canvasGroup.alpha = 0;
        canvasGroup.gameObject.SetActive(true);

        // Fade in
        for (float t = 0; t < 1f; t += Time.deltaTime * 4)
        {
            canvasGroup.alpha = t;
            yield return null;
        }

        canvasGroup.alpha = 1;
        yield return new WaitForSeconds(1.5f);

        // Fade out
        for (float t = 1f; t > 0; t -= Time.deltaTime * 4)
        {
            canvasGroup.alpha = t;
            yield return null;
        }

        canvasGroup.alpha = 0;
    }
}