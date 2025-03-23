using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeapponController : MonoBehaviour
{
    [SerializeField] private float m_Damage;

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
}
