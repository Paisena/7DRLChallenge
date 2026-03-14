using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float sizeDifference = 1.05f;
    public float animationDuration = 0.2f;
    private Vector2 originalSize;
    private RectTransform rectTransform;
    [SerializeField] private RectTransform iconRectTransform;

    private Coroutine scaleCoroutine;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalSize = rectTransform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 target = originalSize * sizeDifference;
        StartScaleAnimation(target);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartScaleAnimation(Vector3.one);
    }

    private void StartScaleAnimation(Vector3 target)
    {
        if (scaleCoroutine != null)
            StopCoroutine(scaleCoroutine);

        scaleCoroutine = StartCoroutine(ScaleOverTime(target));
    }

    private IEnumerator ScaleOverTime(Vector3 target )
    {
        Vector3 startRect = rectTransform.localScale;
        Vector3 startIcon = iconRectTransform != null ? iconRectTransform.localScale : Vector3.zero;

        float time = 0f;

        while (time < animationDuration)
        {
            time += Time.deltaTime;
            float t = time / animationDuration;

            rectTransform.localScale = Vector3.Lerp(startRect, target, t);

            if (iconRectTransform != null)
                iconRectTransform.localScale = Vector3.Lerp(startIcon, target, t);

            yield return null;
        }

        rectTransform.localScale = target;

        if (iconRectTransform != null)
            iconRectTransform.localScale = target;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
