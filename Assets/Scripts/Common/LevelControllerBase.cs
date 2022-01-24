using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public abstract class LevelControllerBase : MonoBehaviour
    {
        public string missionText;
        public TextMeshProUGUI text;
        protected Inventory inventory; 

        private void Awake()
        {
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            text.text = missionText;
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