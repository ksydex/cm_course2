using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUiManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI resultsTableText;

    private void Awake()
    {
        var result = ResultsManager.current!.Result ?? false;
        resultText.text = result ? "Победа" : "Поражение";
        ResultsManager.current = null;
        resultsTableText.text = ResultsManager.instance.resultsInText;
    }

    public void OnButtonClick()
    {
        SceneManager.LoadScene("StartGameScene 1");
    }
}