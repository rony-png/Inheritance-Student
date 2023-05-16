using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    public PlayerController player;
    public float duration;
    public float Speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<PlayerController>();
            Activate();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Invoke(nameof(DelayedDestory), duration);
        }
    }


    public virtual void Activate()
    {

    }

    public void DelayedDestory()
    {
        Destroy(gameObject);
    }
}
