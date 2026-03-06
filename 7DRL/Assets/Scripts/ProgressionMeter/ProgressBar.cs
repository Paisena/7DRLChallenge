using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Target target;
    [SerializeField] private Image ProgressImage;
    [SerializeField] private float DefaultSpeed = 1f;
    [SerializeField] private UnityEvent<float> OnProgress;
    [SerializeField] private UnityEvent OnComplete;
    private Coroutine AnimationCoroutine;

    private void OnEnable()
    {
        target.onProgressValueChanged += SetProgress;
    }

    private void OnDisable()
    {
        target.onProgressValueChanged -= SetProgress;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (ProgressImage.type != Image.Type.Filled)
        {
            Debug.LogError("ProgressImage must be of type Filled for the ProgressBar to work correctly.");
            this.enabled = false; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetProgress(float progress)
    {
        SetProgress(progress, DefaultSpeed);
    }

    public void SetProgress(float progress, float speed)
    {
        if (progress < 0f || progress > 1f)
        {
            Debug.LogError("Progress value must be between 0 and 1.");
            progress = (int)Mathf.Clamp01(progress);

        }

        if (progress != ProgressImage.fillAmount)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }
            AnimationCoroutine = StartCoroutine(AnimateProgress(progress, speed));
        }
    }

    private IEnumerator AnimateProgress(float targetProgress, float speed)
    {
        float time = 0f;
        float startProgress = ProgressImage.fillAmount;

        while (time < 1)
        {
            ProgressImage.fillAmount = Mathf.Lerp(startProgress, targetProgress, time);
            time += Time.deltaTime * speed;
            
            OnProgress.Invoke(ProgressImage.fillAmount);
            yield return null;
        }

        ProgressImage.fillAmount = targetProgress;
        OnProgress.Invoke(ProgressImage.fillAmount);
        if (Mathf.Approximately(targetProgress, 1f))
        {
            OnComplete.Invoke();
        }
        
    }
}

