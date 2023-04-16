using UnityEngine;
using System.Collections;
public class PlayerEffect : MonoBehaviour
{
    public void AddSpeed(int speed, float duration)
    {
        PlayerMovement.instance.MoveSpeed += speed;
        StartCoroutine(SpeedEffect(speed, duration));
    }

    private IEnumerator SpeedEffect(int speed, float duration)
    {
        yield return new WaitForSeconds(duration);
        PlayerMovement.instance.MoveSpeed -= speed;
    }
}
