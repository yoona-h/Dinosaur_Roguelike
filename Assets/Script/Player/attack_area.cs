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
        damage = damageAmount;
        foreach (var target in currentTargets)
        {
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var target = other.GetComponent<IceManager>();
        if (target != null)
        {
            currentTargets.Add(target);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var target = other.GetComponent<IceManager>();
        if (target != null)
        {
            currentTargets.Remove(target);
        }
    }
}
