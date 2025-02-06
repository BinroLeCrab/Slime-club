using UnityEngine;

public class ObstacleScaleController : MonoBehaviour
{
    private static float ORIGINAL_SIZE = 0.1f;

    [SerializeField] int m_MinSize = 2;
    [SerializeField] int m_MaxSize = 5;

    Vector3 m_Scale;

    float m_Delay = 0f;
    float m_ElapsedTime = 0f;

    private void Awake()
    {
        m_Delay = Random.Range(1f, 3f);
        m_Scale = transform.localScale;
        SetTargetScale();
    }

    private void Update()
    {
        m_ElapsedTime += Time.deltaTime;

        if (m_ElapsedTime < m_Delay)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, m_Scale, m_ElapsedTime / m_Delay);
            return;
        }

        m_ElapsedTime = 0f;
        SetTargetScale();
    }

    private void SetTargetScale()
    {
        m_Scale.y = Mathf.Approximately(m_Scale.y, ORIGINAL_SIZE) ? Random.Range(m_MinSize, m_MaxSize) : 0.1f;
    }
}