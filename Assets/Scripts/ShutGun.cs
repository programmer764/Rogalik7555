using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutGun : Guns
{   
    void Update()
    {
        GameObject target = FindNearestEnemy();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (target != null)
        {
            // Расчет направления к цели
            direction = (target.transform.position - transform.position).normalized;

            // Проверяем, можем ли стрелять
            if (_shoot)
            {
                ShootDrobovik();
            }
        }

    }
}
