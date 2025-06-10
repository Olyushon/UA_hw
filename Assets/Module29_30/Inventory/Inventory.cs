using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory
{
    private List<Item> _items;
    private int _maxSize;

    public Inventory(int maxSize)
    {
        _maxSize = maxSize;
        _items = new List<Item>();
    }

    public List<Item> Items => _items;

    public void AddItem(Item item)
    {
        if (_items.Count < _maxSize)
            _items.Add(item);
        else
            Debug.Log("Inventory is full");
    }

    public List<Item> TakeItemsBy(int id)
    {
        List<Item> selectedItems = _items.Where(item => item.Id == id).ToList();

        _items.RemoveAll(item => item.Id == id);
        
        return selectedItems;
    }
}

public class Item
{
    private int _id;
    
    public int Id => _id;
}
