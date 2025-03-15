using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManger : MonoBehaviour
{
    [SerializeField] private float m_PvOrigin;
    private float m_Pv;

    // Start is called before the first frame update
    void Start()
    {
        setPv(m_PvOrigin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPv (float pv)
    {
        m_Pv = pv;
    }

    public float getPv()
    {
        return m_Pv;
    }
}
