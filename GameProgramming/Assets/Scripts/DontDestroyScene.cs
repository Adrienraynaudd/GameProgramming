
using UnityEngine;

public class DontDestroyScene : MonoBehaviour
{
    public GameObject[] objects;
    void Awake()
    {
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }

}
