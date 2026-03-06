using System.Collections;
using UnityEngine;

public class MeterBarMovement : MonoBehaviour
{
    public Target target;

    public void OnEnable()
    {
        target.onProgressValueChanged += GrowRight;
    }

    public void OnDisable()
    {
        target.onProgressValueChanged -= GrowRight;
    }
    public IEnumerator GrowRightOverTime(float amount)
    {
        float duration  = 1f;
        RectTransform rt = this.GetComponent<RectTransform>();

        Vector2 startSize = rt.sizeDelta;
        Vector2 targetSize = startSize + new Vector2(amount, 0f);

        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            rt.sizeDelta = Vector2.Lerp(startSize, targetSize, time / duration);
            yield return null;
        }

        rt.sizeDelta = targetSize;
    }   

    public void GrowRight(float value)
    {
        print("Growing right by " + value);
        StartCoroutine(GrowRightOverTime(value)); // Example: grow by 10 units over 1 second
    }
}
