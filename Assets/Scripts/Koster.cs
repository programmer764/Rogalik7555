using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koster : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Player lol = player.GetComponent<Player>();
            player.ApplyDamage(10);
            Destroy(gameObject);
        }
    }
}
