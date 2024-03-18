using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class ActiveInventory : MonoBehaviour
{
    private int activeSlotIndexNum = 0;

    [SerializeField] List<PlayerShoot> playerShoots;

    private void Update()
    {
        if(UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
        {
            ToggleActiveHighlight(0);
        }else if(UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
        {
            ToggleActiveHighlight(1);
        }
    }

    private void ToggleActiveHighlight(int indexNum)
    {
        activeSlotIndexNum = indexNum;

        foreach (Transform inventorySlot in this.transform)
        {
            inventorySlot.GetChild(0).gameObject.SetActive(false);
        }
        foreach (PlayerShoot playerShoot in playerShoots)
        {
            playerShoot.enabled = false;
        }
        playerShoots[activeSlotIndexNum].enabled = true;
        this.transform.GetChild(indexNum).GetChild(0).gameObject.SetActive(true);
    }
}
