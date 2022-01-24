using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public static class Keys
    {
        public const string Apple = "apple";
        public const string Smile = "smile";
    }

    public AudioClip audioClip;
    private Inventory inventory;
    public GameObject slotButton;
    public string key;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (string.IsNullOrEmpty(inventory.isFull[i]))
                {
                    inventory.isFull[i] = key;
                    Instantiate(slotButton, inventory.slots[i].transform);
                    Destroy(gameObject);

                    var audioSource = other.gameObject.AddComponent<AudioSource>();
                    audioSource.PlayOneShot(audioClip, 0.5f);

                    break;
                }
            }

            inventory.OnChange();
        }
    }
}