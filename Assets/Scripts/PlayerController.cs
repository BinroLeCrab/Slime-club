using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_Pv;
    [SerializeField] private string m_PlayerName;

    [SerializeField] private TextMeshProUGUI NameTag;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initPlayer(float pv, string name)
    {
        setPv(pv);
        setName(name);
    }

    private void setPv (float pv)
    {
        m_Pv = pv;
    }

    public float getPv()
    {
        return m_Pv;
    }

    private void setName(string name)
    {
        m_PlayerName = name;

        if (NameTag != null)
        {
            NameTag.text = m_PlayerName;
        }
    }

    public string getName()
    {
        return m_PlayerName;
    }

    public void TakeDamage(float damage)
    {
        m_Pv -= damage;
    }
}
