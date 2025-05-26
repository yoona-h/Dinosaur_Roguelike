using System.Collections.Generic;
using UnityEngine;

public class attack_area : MonoBehaviour
{
    [HideInInspector] public IceManager manager;

    private int damage;
    private bool active = false;
    private HashSet<GameObject> hitTargets = new HashSet<GameObject>();

    public void Activate(int damageAmount)
    {
        active = true;
        damage = damageAmount;
        hitTargets.Clear();
    }

    public void Deactivate()
    {
        active = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!active) return;
        if (hitTargets.Contains(other.gameObject)) return;

        var target = other.GetComponent<IceManager>();
        if (target != null)
        {
            target.TakeDamage(damage);
            hitTargets.Add(other.gameObject);
        }
    }
}