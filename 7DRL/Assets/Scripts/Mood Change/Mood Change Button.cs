using System.Collections;
using UnityEngine;

public class MoodChangeButton : MonoBehaviour
{
    public Vector3 OriginalPosition;
    public DialougeSO dialogue;
    public void Start()
    {
        OriginalPosition = transform.position;
    }
    public void EnableMoodChangeHud()
    {
        StartCoroutine(BeginMoodChangeDialogue());
    }

    public IEnumerator BeginMoodChangeDialogue()
    {
        print("starting mood change dialogue");
        LocationManager.Instance.DisableTrainingHUD();
        DialogueTextManager.Instance.StartDialouge(dialogue);
        print(DialogueTextManager.Instance.isInDialouge);
        yield return new WaitUntil(() => DialogueTextManager.Instance.isInDialouge == false);
        print("isInDialouge is false, re-enabling training HUD");
        LocationManager.Instance.EnableTrainingHUD();
    }
}
