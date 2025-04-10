using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Informations")]
    [SerializeField] private float m_Pv;
    [SerializeField] private string m_PlayerName;
    [SerializeField] private int m_PlayerScore = 0;

    [Header("Attack Settings")]
    [SerializeField] private TriggerAttackZone m_AttackZone;
    [SerializeField] private WeapponController m_Weappon;
    [SerializeField] Animator m_AnimatorWeapon;
    [SerializeField] Animator m_AnimatorDamage;

    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed = 10;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1;

    [Header("UI Objects")]
    [SerializeField] private TextMeshProUGUI NameTagRed;
    [SerializeField] private TextMeshProUGUI NameTagBlue;
    [SerializeField] private TextMeshProUGUI DamageTag;

    [Header("Skin")]
    [SerializeField] private GameObject m_SkinBlue;
    [SerializeField] private GameObject m_SkinRed;

    [Header("Sound")]
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_DashSound;
    [SerializeField] private AudioClip m_AttackSound;
    [SerializeField] private AudioClip m_AttackSound2;
    [SerializeField] private AudioClip m_AttackSound3;
    [SerializeField] private AudioClip m_HitSound;
    [SerializeField] private AudioClip m_HitSound2;
    [SerializeField] private AudioClip m_HitSound3;
    [SerializeField] private AudioClip m_TauntSound;

    private string m_Device;
    public float m_PvOrigin;
    private Vector3 m_SpawnPosition;
    private bool canDash = true;
    private bool canMakeSound = false;

    private CharacterController m_CharacterController;

    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    public void InitPlayer(float pv, string name, string skin, string device, Vector3 spawnPosition)
    {
        m_SpawnPosition = spawnPosition;
        m_PvOrigin = pv;

        SetPV(pv);
        SetName(name);
        SetSkin(skin);
        SetDevice(device);
    }

    private void SetPV (float pv)
    {
        m_Pv = pv;
    }

    private void SetDevice(string device)
    {
        m_Device = device;
    }

    private void SetName(string name)
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

    private void SetSkin(string skin)
    {
        // Set kin and name tag depending on name

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

    public void SetSpawn()
    {
        m_CharacterController.enabled = false;
        transform.position = m_SpawnPosition;
        m_CharacterController.enabled = true;

        canMakeSound = true; // Active sound

        if (m_AudioSource != null && canMakeSound == true)
        {
            m_AudioSource.PlayOneShot(m_TauntSound);
        }
    }

    public string GetName()
    {
        return m_PlayerName;
    }

    public float GetPv()
    {
        return m_Pv;
    }

    public string GetDevice()
    {
        return m_Device;
    }

    public int GetScore()
    {
        return m_PlayerScore;
    }

    public bool IsPlayerOne()
    {
        // For know if this player is the player one or the player two

        if (m_PlayerName == "J1")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Restart(bool asWon)
    {
        // Disabled Character controller
        m_CharacterController.enabled = false;

        // Set player at spawn position
        transform.position = m_SpawnPosition;

        // Reset PV
        SetPV(m_PvOrigin);

        // Unset Current Player
        m_AttackZone.UnsetCurrentPlayer();

        if (asWon)
        {
            // Increment score & play Tount sound
            m_PlayerScore++;

            if (m_AudioSource != null && canMakeSound == true)
            {
                m_AudioSource.PlayOneShot(m_TauntSound);
            }
        }

        // Enabled Chracter Controller
        m_CharacterController.enabled = true;
    }

    public void TakeDamage(float damage, Vector3 attackPosition, float knockbackForce, float knockbackTime)
    {
        m_Pv -= damage;
        if (DamageTag != null)
        {
            DamageTag.text = "-" + damage.ToString();
        }

        if (m_AudioSource != null && canMakeSound == true)
        {
            // Play a random sound
            int random = Random.Range(0, 3);

            AudioClip randomClip;

            if (random == 0)
            {
                randomClip = m_HitSound;
            }
            else if (random == 1)
            {
                randomClip = m_HitSound2;
            }
            else
            {
                randomClip = m_HitSound3;
            }

            m_AudioSource.PlayOneShot(randomClip);
        }

        // Play animation
        m_AnimatorDamage.Play("Damage", 0, 0f);

        // Apply weapon Konckback
        StartCoroutine(ApplyKnockback(attackPosition, knockbackForce, knockbackTime));
    }

    public IEnumerator ApplyKnockback(Vector3 attackPosition, float knockbackForce, float knockbackTime)
    {
        // Set Knockback direction
        Vector3 knockbackDirection = (transform.position - attackPosition).normalized;
        float startTime = Time.time;

        // Move player
        while (Time.time < startTime + knockbackTime)
        {
            m_CharacterController.Move(knockbackDirection * knockbackForce * Time.deltaTime);
            yield return null;
        }
    }

    public void OnAttack()
    {
        // Play animation
        m_AnimatorWeapon.SetTrigger("Attack");

        
        if (m_AudioSource != null && canMakeSound == true)
        {
            // Play a random attack sound
            int random = Random.Range(0, 3);

            AudioClip randomClip;

            if (random == 0)
            {
                randomClip = m_AttackSound;
            }
            else if(random == 1)
            {
                randomClip = m_AttackSound2;
            }
            else
            {
                randomClip = m_AttackSound3;
            }

            m_AudioSource.PlayOneShot(m_Weappon.GetSound());
            m_AudioSource.PlayOneShot(randomClip);
        }

        if (m_AttackZone.GetCurrentPlayer() != null)
        {
            if (m_AttackZone.GetCurrentPlayer().GetPv() <= 0) { 
                return; 
            }

            // Apply damage on other player
            m_AttackZone.GetCurrentPlayer().TakeDamage(m_Weappon.GetDamage(), transform.position, m_Weappon.GetKnockbackForce(), m_Weappon.GetKnockbackTime());
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
        // block dooble or more dash
        canDash = false;
        
        // Set dash direction
        Vector3 dashDirection = m_CharacterController.velocity.normalized;

        if (dashDirection == Vector3.zero)
        {
            dashDirection = transform.forward; 
        }

        float startTime = Time.time;

        // Play dash sound
        if (m_AudioSource != null && canMakeSound == true)
        {
            m_AudioSource.PlayOneShot(m_DashSound);
        }

        // Move player
        while (Time.time < startTime + dashDuration)
        {
            m_CharacterController.Move(dashDirection * dashSpeed * Time.deltaTime);

            yield return null;
        }

        // Play cooldown
        yield return new WaitForSeconds(dashCooldown);

        // deblock dash
        canDash = true;
    }
}
