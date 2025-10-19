using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CopyScriptUsername : MonoBehaviour
{
    [SerializeField] private Text TextCopiedText;
    [SerializeField] private Image windowBackground; // Фон окна
    [SerializeField] private float fadeSpeed = 1.5f;
    [SerializeField] private float displayTime = 2f; // Время показа окна
    [SerializeField] private GameObject TextCopiedWindow;
    
    private Coroutine fadeCoroutine;

    public void OpenWindow()
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);
            
        TextCopiedWindow.SetActive(true);
        fadeCoroutine = StartCoroutine(FadeWindow());
    }
    
    private IEnumerator FadeWindow()
    {
        // Сбрасываем прозрачность
        SetAlpha(1f);
        
        // Ждём немного перед затуханием
        yield return new WaitForSeconds(displayTime);
        
        // Плавное затухание
        float timer = 0f;
        while (timer < 1f)
        {
            timer += Time.deltaTime * fadeSpeed;
            float alpha = 1f - timer;
            SetAlpha(alpha);
            yield return null;
        }
        
        // Скрываем окно после затухания
        TextCopiedWindow.SetActive(false);
        fadeCoroutine = null;
    }
    
    private void SetAlpha(float alpha)
    {
        // Текст
        Color textColor = TextCopiedText.color;
        textColor.a = alpha;
        TextCopiedText.color = textColor;
        
        // Фон окна (если есть Image компонент)
        if (windowBackground != null)
        {
            Color bgColor = windowBackground.color;
            bgColor.a = alpha;
            windowBackground.color = bgColor;
        }
    }
}