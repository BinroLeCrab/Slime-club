using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_Pv;
    [SerializeField] private string m_PlayerName;
    [SerializeField] private TriggerAttackZone m_AttackZone;
    [SerializeField] private WeapponController m_Weappon;
    [SerializeField] Animator m_AnimatorWeapon;
    [SerializeField] Animator m_AnimatorDamage;

    [SerializeField] private TextMeshProUGUI NameTagRed;
    [SerializeField] private TextMeshProUGUI NameTagBlue;
    [SerializeField] private TextMeshProUGUI DamageTag;

    [SerializeField] private GameObject m_SkinBlue;
    [SerializeField] private GameObject m_SkinRed;

    private string m_Device;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initPlayer(float pv, string name, string skin, string device)
    {
        setPv(pv);
        setName(name);
        setSkin(skin);
        setDevice(device);
    }

    private void setPv (float pv)
    {
        m_Pv = pv;
    }

    public float getPv()
    {
        return m_Pv;
    }

    private void setDevice(string device)
    {
        m_Device = device;
    }

    public string getDevice()
    {
        return m_Device;
    }

    private void setName(string name)
    {
        m_PlayerName = name;

        if (NameTagRed != null)
        {
            NameTagRed.text = m_PlayerName;
        }

        if (NameTagBlue != null)
        {
            NameTagBlue.text = m_PlayerName;
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
            NameTagBlue.gameObject.SetActive(true);
            m_SkinRed.SetActive(false);
            NameTagRed.gameObject.SetActive(false);
        }
        else if (skin == "Red")
        {
            m_SkinBlue.SetActive(false);
            NameTagBlue.gameObject.SetActive(false);
            m_SkinRed.SetActive(true);
            NameTagRed.gameObject.SetActive(true);
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
            m_AttackZone.getCurrentPlayer().TakeDamage(m_Weappon.getDamage());
        }
    }
}
