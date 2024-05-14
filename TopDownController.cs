using System;
using UnityEngine;


public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    protected bool IsAttacking {  get;  set; }
    private float timeSinceLastAttack = float.MaxValue;

    public void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        // TODO :: MAGIC NUMBER ¼öÁ¤
        if (timeSinceLastAttack <= 0.2f)    // TODO
        {
            timeSinceLastAttack += Time.deltaTime;
        }

        else if (IsAttacking && timeSinceLastAttack > 0.2f)
        {
            timeSinceLastAttack = 0;
            CallAttackEvent();
        }
    }


    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    private void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }

}
