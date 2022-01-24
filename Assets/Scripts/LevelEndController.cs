using System;
using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndController : MonoBehaviour
{
    public LevelControllerBase levelController;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            OnPlayerCollision();
    }

    public void OnPlayerCollision()
    {
        Debug.Log("xcxxzczczxczxczxc");
        var isSuccess = levelController.IsMissionSucceeded(); 
        Debug.Log(isSuccess);
        if (isSuccess)
        {
            Debug.Log("success");
            if (levelController.nextLevelSceneName != "")
            {
                Debug.Log("new elvel");
                SceneManager.LoadScene(levelController.nextLevelSceneName);
            }
            else
            {
                // show UI
            }
        }
    }
}