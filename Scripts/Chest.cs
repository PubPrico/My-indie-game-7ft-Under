using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int chestCapacity = 10;
    public List<Item> items = new List<Item>();

    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                OpenChest();
            }
        }
    }

    void OpenChest()
    {
        Debug.Log("ChestOpened");
    }

    // Add items to the chest until it reaches full capacity
    public void FillChest()
    {
        while (GetTotalCapacity() < chestCapacity)
        {
            // Assume you have some method to generate a random item
            Item newItem = GenerateRandomItem();

            // Add the item to the chest
            AddItemToChest(newItem);
        }
    }

    // Get the total capacity of items in the chest
    private int GetTotalCapacity()
    {
        int totalCapacity = 0;
        foreach (var item in items)
        {
            totalCapacity += item.capacity;
        }
        return totalCapacity;
    }

    // Add an item to the chest
    private void AddItemToChest(Item newItem)
    {
        // Check if adding the item will exceed the chest capacity
        if (GetTotalCapacity() + newItem.capacity <= chestCapacity)
        {
            // Add the item to the chest's items
            items.Add(newItem);
        }
    }

    // Method to generate a random item (replace with your logic)
    private Item GenerateRandomItem()
    {
        // Replace this with your logic to generate a random item
        // For simplicity, let's assume you have a list of available items
        List<Item> availableItems = new List<Item>();
        // Add your items to the list...

        // Randomly select an item from the list
        int randomIndex = Random.Range(0, availableItems.Count);
        return availableItems[randomIndex];
    }
}