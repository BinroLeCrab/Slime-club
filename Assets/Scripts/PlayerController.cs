using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_Pv;
    [SerializeField] private string m_PlayerName;
    [SerializeField] private TriggerAttackZone m_AttackZone;
    [SerializeField] Animator m_AnimatorWeapon;
    [SerializeField] Animator m_AnimatorDamage;

    [SerializeField] private TextMeshProUGUI NameTag;
    [SerializeField] private TextMeshProUGUI DamageTag;

    [SerializeField] private GameObject m_SkinBlue;
    [SerializeField] private GameObject m_SkinRed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initPlayer(float pv, string name, string skin)
    {
        setPv(pv);
        setName(name);
        setSkin(skin);
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

    private void setSkin(string skin)
    {
        if (skin == "Blue")
        {
            m_SkinBlue.SetActive(true);
            m_SkinRed.SetActive(false);
        }
        else if (skin == "Red")
        {
            m_SkinBlue.SetActive(false);
            m_SkinRed.SetActive(true);
        }
    }

    public void TakeDamage(float damage)
    {
        m_Pv -= damage;
        if (DamageTag != null)
        {
            DamageTag.text = "-" + damage.ToString();
        }
        //m_AnimatorDamage.SetTrigger("TakeDamage");
        m_AnimatorDamage.Play("Damage", 0, 0f);
    }

    public void OnAttack()
    {
        m_AnimatorWeapon.SetTrigger("Attack");

        if (m_AttackZone.getCurrentPlayer() != null)
        {
            Debug.Log("Attack !!");
            if (m_AttackZone.getCurrentPlayer().getPv() <= 0) { 
                return; 
            }
            m_AttackZone.getCurrentPlayer().TakeDamage(10);
        }
    }
}
