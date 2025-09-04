using UnityEngine;
using System.Collections;

public class CatMeow : MonoBehaviour
{
    [SerializeField] private AudioClip[] meowSounds; // assign multiple clips
    [SerializeField] private float minDelay = 5f;
    [SerializeField] private float maxDelay = 15f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(MeowRoutine());
    }

    IEnumerator MeowRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(waitTime);

            if (!audioSource.isPlaying && meowSounds.Length > 0)
            {
                AudioClip clip = meowSounds[Random.Range(0, meowSounds.Length)];
                audioSource.PlayOneShot(clip);
            }
        }
    }
}
