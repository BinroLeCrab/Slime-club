using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

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

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;

    private string m_Device;
    public float m_PvOrigin;
    private Vector3 m_SpawnPosition;
    private int m_PlayerScore = 0;
    private bool canDash = true;

    private CharacterController m_CharacterController;

    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initPlayer(float pv, string name, string skin, string device, Vector3 spawnPosition)
    {
        m_SpawnPosition = spawnPosition;

        m_PvOrigin = pv;
        setPv(pv);
        setName(name);
        setSkin(skin);
        setDevice(device);
        
    }

    public void restart (bool asWon)
    {
        m_CharacterController.enabled = false;

        transform.position = m_SpawnPosition;
        setPv(m_PvOrigin);
        m_AttackZone.unsetCurrentPlayer();

        if (asWon)
        {
            m_PlayerScore++;
        }

        m_CharacterController.enabled = true;
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

    public void setSpawn()
    {
        m_CharacterController.enabled = false;
        transform.position = m_SpawnPosition;
        m_CharacterController.enabled = true;

        Debug.Log("Spawn position : " + m_SpawnPosition + "| Position actuelle : " + this.transform.position);
    }

    public void TakeDamage(float damage, Vector3 attackPosition, float knockbackForce, float knockbackTime)
    {
        m_Pv -= damage;
        if (DamageTag != null)
        {
            DamageTag.text = "-" + damage.ToString();
        }
        m_AnimatorDamage.Play("Damage", 0, 0f);
        StartCoroutine(ApplyKnockback(attackPosition, knockbackForce, knockbackTime));
    }

    public IEnumerator ApplyKnockback(Vector3 attackPosition, float knockbackForce, float knockbackTime)
    {
        Vector3 knockbackDirection = (transform.position - attackPosition).normalized;
        float startTime = Time.time;

        while (Time.time < startTime + knockbackTime)
        {
            m_CharacterController.Move(knockbackDirection * knockbackForce * Time.deltaTime);
            yield return null;
        }
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
            m_AttackZone.getCurrentPlayer().TakeDamage(m_Weappon.getDamage(), transform.position, m_Weappon.getKnockbackForce(), m_Weappon.getKnockbackTime());
        }
    }

    public bool isPlayerOne()
    {
        if (m_PlayerName == "J1")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnDash()
    {
        if (canDash && m_CharacterController.velocity != Vector3.zero)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        
        Vector3 dashDirection = m_CharacterController.velocity.normalized;

        if (dashDirection == Vector3.zero)
        {
            dashDirection = transform.forward; 
        }

        float startTime = Time.time;

        while (Time.time < startTime + dashDuration)
        {
            m_CharacterController.Move(dashDirection * dashSpeed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
