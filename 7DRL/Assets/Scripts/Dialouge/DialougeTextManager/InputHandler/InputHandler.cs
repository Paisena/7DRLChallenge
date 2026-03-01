using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public bool InputFinished;

    public void OnInputOver()
    {
        InputFinished = true;
    }

    public void ResetInput()
    {
        InputFinished = false;
    }

}
