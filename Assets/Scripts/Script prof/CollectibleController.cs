using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    public static int COUNT = 0;

    private void Awake()
    {
        COUNT++;
    }

    private void OnDestroy()
    {
        COUNT--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == PLAYER_TAG)
        {
            ScoreManager.Instance.AddScore();

            gameObject.SetActive(false);
        }
    }
}