using System.Collections.Generic;
using UnityEngine;

public class attack_area : MonoBehaviour
{
    private HashSet<IceManager> currentTargets = new HashSet<IceManager>();
    private bool active = false;
    private int damage;

    // 공격 발동 시 호출 (외부에서)
    public void Activate(int damageAmount)
    {
        //print(currentTargets.Count);
        damage = damageAmount;
        foreach (IceManager target in currentTargets)
        {
            if (target.inPool)
            {
                currentTargets.Remove(target);
            }
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IceManager target = other.GetComponent<IceManager>();
        if (target == null)
        {
            target = other.GetComponentInParent<IceManager>();
        }
        if (target == null)
        {
            target = other.GetComponentInChildren<IceManager>();
        }

        if (target != null)
        {
            currentTargets.Add(target);
        }
        else
        {
            Debug.LogWarning($"[Enter] IceManager 못 찾음 → 충돌한 오브젝트: {other.name}, 부모: {other.transform.parent?.name}");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        Exit_ice(other);
    }
    public void Exit_ice(Collider other)
    {
        IceManager target = other.GetComponent<IceManager>();
        if (target == null)
        {
            target = other.GetComponentInParent<IceManager>();
        }
        if (target == null)
        {
            target = other.GetComponentInChildren<IceManager>();
        }

        if (target != null)
        {
            currentTargets.Remove(target);
        }
        else
        {
            Debug.LogWarning($"[Enter] IceManager 못 찾음 → 충돌한 오브젝트: {other.name}, 부모: {other.transform.parent?.name}");
        }
    }
}
