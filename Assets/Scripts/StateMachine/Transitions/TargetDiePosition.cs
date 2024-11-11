using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetDiePosition : Transition
{
    private Player lol;
    public static event UnityAction Dying;
    void Start()
    {       
    }
   void Update()
    {       
        if (Target==null)
        {
            Dying?.Invoke();
            Time.timeScale = 0;
            NeedTransit = true;            
        }
    }

}
