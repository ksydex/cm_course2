using System;
using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndController : MonoBehaviour
{
    public LevelControllerBase levelController;

    protected float timeToWin = 20.0f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            OnPlayerCollision();
    }

    private void Update()
    {
        if (timeToWin > 0 && ResultsManager.current?.Result == null)
        {
            timeToWin -= Time.deltaTime;
            if (timeToWin <= 0) OnPlayerCollision(true);
        }
    }

    public void OnPlayerCollision(bool ignoreSuccess = false)
    {
        var isSuccess = levelController.IsMissionSucceeded();
        if (isSuccess && ignoreSuccess) return;

        if (isSuccess)
        {
            if (levelController.nextLevelSceneName != "")
                SceneManager.LoadScene(levelController.nextLevelSceneName);
        }
        else
        {
            Debug.Log("LOST!");
            // show UI
        }
    }
}