using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<MusicManager>().ChangeMusic(gameObject.tag);
        }
    }
}
