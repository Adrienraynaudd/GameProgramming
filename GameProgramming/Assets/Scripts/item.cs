using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class item : ScriptableObject
{
    public int id;
    public string names;
    public string description;
    public Sprite icon;
    public int hp;
    public int speed;
    public float duration;
}
