using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : Weapon
{

    public GameObject projectilePrefab;
  
    public override void Attack()
    {
        if (canAttack)
        {
            EnableWeapon();
            boxCollider.enabled = true;
            Invoke("DisableWeapon", attackDuration);
            Invoke("AttackReset", 60f / attackRate);

            // Create a new instance of the projectile prefab and set its position and rotation to match the slingshot.

            GameObject projectileObject = Instantiate(projectilePrefab, transform.position, transform.rotation);

            // Get the Projectile component on the new object
            Projectile projectile = projectileObject.GetComponent<Projectile>();

            // Set the damage and speed of the projectile
            projectile.damage = damage;
            projectile.speed = 10f;

        }
    }

    

}
