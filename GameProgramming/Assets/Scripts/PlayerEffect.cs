using UnityEngine;
using System.Collections;
public class PlayerEffect : MonoBehaviour // this is called to add effect to the player
{
    public void AddSpeed(int speed, float duration) // this is called to add speed to the player
    {
        PlayerMovement.instance.MoveSpeed += speed;
        StartCoroutine(SpeedEffect(speed, duration));
    }

    private IEnumerator SpeedEffect(int speed, float duration) //for the duration of the item the player will have the effect
    {
        yield return new WaitForSeconds(duration);
        PlayerMovement.instance.MoveSpeed -= speed;
    }
}
