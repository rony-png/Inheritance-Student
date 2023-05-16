using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : PickUp
{

    public override void Activate()
    {
        // Store the player's original speed
        float originalSpeed = player.Speed;

        // Increase the player's speed
        player.Speed *= 2.0f;

        // Start a coroutine to reset the speed after a certain duration
        StartCoroutine(ResetSpeed(originalSpeed, 5.0f));
    }

    private IEnumerator ResetSpeed(float originalSpeed, float duration)
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Reset the player's speed to the original value
        player.Speed = originalSpeed;
    }


}
