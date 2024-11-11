using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Guns
{
    public Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponentInParent<Player>();
        if ( _player == null )
            enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        GameObject target = FindNearestEnemy();
        if (target != null)
        {
            // Расчет направления к цели
            direction = (target.transform.position - transform.position).normalized;

            // Проверяем, можем ли стрелять
            if (_shoot)
            {
                Shoot();
            }
        }

    }


}

