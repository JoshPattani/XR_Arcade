using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    private Button resetButton;

    void Awake()
    {
        resetButton = GetComponent<Button>();

        if (resetButton != null)
        {
            resetButton.onClick.AddListener(OnResetButtonClicked);
        }
        else
        {
            Debug.LogError("Button component not found on ResetButton.");
        }
    }

    void OnDestroy()
    {
        if (resetButton != null)
        {
            resetButton.onClick.RemoveListener(OnResetButtonClicked);
        }
    }

    public void OnResetButtonClicked()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame();
        }
        else
        {
            Debug.LogError("GameManager instance not found.");
        }
    }
}
