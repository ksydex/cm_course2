using System.Collections;
using System.Collections.Generic;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StartGameUiManager : MonoBehaviour
{
    public TMP_InputField nameInput;

    public void OnButtonClick()
    {
        ResultsManager.instance.Add(new UserResult
        {
           UserName = nameInput.text
        });
        SceneManager.LoadScene("SampleScene");
    }
}
