using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
     [SerializeField] private InputActionAsset actionsAsset; 
    [SerializeField] private string actionMapName = "UI";
    [SerializeField] private GameObject menuUI;
    public bool isMenuOpen = false;
    private InputAction menuAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake() 
    {
            var map = actionsAsset.FindActionMap(actionMapName, true);
            menuAction = map.FindAction("Menu", true);
    }
    

    void OnEnable()
    {
        menuAction.Enable();
        menuAction.performed += ToggleMenu;
    }

    void OnDisable()
    {
        menuAction.Disable();
        menuAction.performed -= ToggleMenu;
    }

    public void ToggleMenu(InputAction.CallbackContext context)
    {
        // Implement your menu toggle logic here
        Debug.Log("Menu toggled!");
        isMenuOpen = !isMenuOpen;
        GameObject[] locationButtons = GameObject.FindGameObjectsWithTag("UIButton");

        foreach (GameObject button in locationButtons)
        {
            Button buttonComp = button.GetComponentInChildren<Button>();
            buttonComp.interactable = !buttonComp.interactable;
        }

        menuUI.SetActive(isMenuOpen);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
