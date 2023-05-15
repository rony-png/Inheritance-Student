using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwungWeapon : Weapon
{
    public float swingSpeed;
    public float swingDegrees;


    public override void Attack()
    {
        //Rotate to start position
        transform.localEulerAngles = new Vector3(0, 0, -swingDegrees);
        //Activate Weapon
        EnableWeapon();
        Invoke(nameof(DisableWeapon), attackDuration);
        Invoke(nameof(AttackReset), 60f / attackRate);
        //Swing and deactivate
        StartCoroutine(Swing());
    }



    //Swing Coroutine

    IEnumerator Swing()
    {
        float degrees = 0;
        while (degrees < swingDegrees * 2)
        {
            transform.Rotate(Vector3.forward, swingSpeed * Time.deltaTime);
            degrees += swingSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        DisableWeapon();

    }
}
