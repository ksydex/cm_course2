using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public abstract class LevelControllerBase : MonoBehaviour
    {
        public string missionText;
        public TextMeshProUGUI text;
        public TextMeshProUGUI levelNameText;
        protected Inventory inventory;
        [CanBeNull] public string nextLevelSceneName;
        public string levelName;

        private void Awake()
        {
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            text.text = missionText;
            levelNameText.text = levelName;
            Destroy(levelNameText, 2.0f);
        }

        public void OnInventoryChange()
        {
            if (IsMissionSucceeded())
                OnMissionSuccess();
        }

        public abstract bool IsMissionSucceeded();
        public abstract void OnMissionSuccess();
    }
}