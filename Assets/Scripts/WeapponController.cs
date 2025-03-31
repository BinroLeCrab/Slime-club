using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeapponController : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private float m_Damage;

    [Header("Knockback")]
    [SerializeField] private float m_KnockbackForce;
    [SerializeField] private float m_KnockbackTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getDamage()
    {
        return m_Damage;
    }

    public float getKnockbackForce() {
        return m_KnockbackForce;
    }

    public float getKnockbackTime() {
        return m_KnockbackTime;
    }
}
