using UnityEngine;

public class ObstacleMoveController : MonoBehaviour
{
    [SerializeField] Vector3 m_Destination = Vector3.zero;

    Vector3 m_Origin;
    Vector3 m_Target;

    float m_Delay = 0f;
    float m_ElapsedTime = 0f;

    private void Awake()
    {
        m_Delay = Random.Range(1f, 3f);
        m_Origin = transform.position;
        m_Target = m_Destination;
    }

    private void Update()
    {
        m_ElapsedTime += Time.deltaTime;

        if (m_ElapsedTime < m_Delay)
        {
            transform.position = Vector3.Lerp(transform.position, m_Target, m_ElapsedTime / m_Delay);
            return;
        }

        m_ElapsedTime = 0f;
        SetTargetPosition();
    }

    private void SetTargetPosition()
    {
        m_Target = Vector3.Distance(transform.position, m_Origin) == 0f ? m_Destination : m_Origin;
    }
}