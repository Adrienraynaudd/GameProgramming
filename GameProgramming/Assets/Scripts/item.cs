using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")] // this is called to create a new item
public class item : ScriptableObject // this is type of item that the player can buy
{
    public int id;
    public string names;
    public string description;
    public Sprite icon;
    public int hp;
    public int speed;
    public int price;
    public float duration;
}
