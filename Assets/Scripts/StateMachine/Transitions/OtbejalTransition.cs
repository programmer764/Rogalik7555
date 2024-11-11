using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class OtbejalTransition : Transition
{
    [SerializeField] private float _transitRange;

    private void Start()
    {

    }
    private void Update()
    {
        if (Target == null)
        {
            NeedTransit = true;
            return;
        }
        if (Vector2.Distance(transform.position, Target.transform.position) > _transitRange)
        {
            NeedTransit = true;
        }

    }
}
