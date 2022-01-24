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
        var isSuccess = levelController.IsMissionSucceeded(); 
        if (isSuccess)
        {
            if (levelController.nextLevelSceneName != null)
                SceneManager.LoadScene(levelController.nextLevelSceneName);
            else
            {
                // show UI
            }
        }
    }
}