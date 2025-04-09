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

    [Header("Sound")]
    [SerializeField] private AudioClip m_AttackSound;
    [SerializeField] private AudioClip m_AttackSoundBis;

    public float getDamage()
    {
        return m_Damage;
    }

    public AudioClip getSound()
    {
        int random = Random.Range(0, 2);

        if (random == 0 )
        {
            return m_AttackSound;
        } else
        {
            return m_AttackSoundBis;
        }
    }

    public float getKnockbackForce() {
        return m_KnockbackForce;
    }

    public float getKnockbackTime() {
        return m_KnockbackTime;
    }
}
