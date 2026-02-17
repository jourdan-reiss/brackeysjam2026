using System;
using System.Collections;
using UnityEngine;

public class AreaOfEngagementTrigger : MonoBehaviour
{
    [SerializeField] private GameEvent startCombatEvent;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharacterController2D>() is { } characterController2D)
        {
            StartCoroutine(StartCombatRoutine());
        }
    }

    private IEnumerator StartCombatRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        
        startCombatEvent.InvokeAction();
    }
}
