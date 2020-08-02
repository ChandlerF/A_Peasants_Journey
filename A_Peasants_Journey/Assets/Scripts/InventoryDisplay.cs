using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    public bool InventoryOpen = false;
    public GameObject Inventory;
    public float Delay = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        CloseInventory();
    }

    // Update is called once per frame
    void Update()
    {
        if (InventoryOpen == true && Delay > -0.25f)
        {
            Delay -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenInventory();

        }

        if (Delay <= 0f)
        {
            if (InventoryOpen == true && Input.GetKeyDown(KeyCode.E))
            {
                CloseInventory();
                Delay = 0.25f;

            }
        }


    }
    void CloseInventory()
        {
        Inventory.SetActive(false);
        InventoryOpen = false;
        //Debug.Log("Inventory Closed");
    }

    void OpenInventory()
    {
        Inventory.SetActive(true);
        InventoryOpen = true;
        //Debug.Log("Inventory Open");
    }
}
