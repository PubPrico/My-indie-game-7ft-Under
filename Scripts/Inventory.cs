using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;   


public class Inventory : MonoBehaviour
{
    public List<InventorySlot> slots = new List<InventorySlot>();

    // Add an item to the inventory
    public void AddItem(Item itemToAdd)
    {
        InventorySlot slot = FindSlot(itemToAdd);

        if (slot != null)
        {
            // If the item is already in the inventory, increase its count
            slot.quantity++;
        }
        else
        {
            // If the item is not in the inventory, add it to an available slot
            InventorySlot emptySlot = slots.Find(s => s.item == null);
            if (emptySlot != null)
            {
                emptySlot.item = itemToAdd;
                emptySlot.quantity = 1;
            }
        }
    }

    // Find a slot containing a specific item
    private InventorySlot FindSlot(Item item)
    {
        return slots.Find(slot => slot.item == item);
    }

    // Internal class representing an inventory slot
    [System.Serializable]
    public class InventorySlot
    {
        public Item item;      // Item in the slot
        public int quantity;   // Quantity of the item in the slot
    }
}