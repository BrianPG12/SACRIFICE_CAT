using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ZoneMusic
{
    public string zoneTag;        // The tag of the zone (e.g. "Grass", "Road")
    public AudioClip musicClip;   // The clip for this zone
}

public class MusicManager : MonoBehaviour
{
    [Header("Audio Sources (2 for crossfade)")]
    public AudioSource sourceA;
    public AudioSource sourceB;

    [Header("Music Settings")]
    public float fadeDuration = 1f;
    public List<ZoneMusic> zoneMusicList;

    private AudioSource activeSource;
    private Dictionary<string, AudioClip> musicLookup;

    void Awake()
    {
        activeSource = sourceA;
        musicLookup = new Dictionary<string, AudioClip>();

        // Build lookup dictionary for fast access
        foreach (ZoneMusic zm in zoneMusicList)
        {
            if (!musicLookup.ContainsKey(zm.zoneTag))
            {
                musicLookup.Add(zm.zoneTag, zm.musicClip);
            }
        }
    }

    public void ChangeMusic(string zoneTag)
    {
        if (!musicLookup.ContainsKey(zoneTag)) return;

        AudioClip newClip = musicLookup[zoneTag];
        if (activeSource.clip == newClip) return;

        AudioSource newSource = (activeSource == sourceA) ? sourceB : sourceA;
        StartCoroutine(Crossfade(newClip, newSource));
    }

    private IEnumerator Crossfade(AudioClip newClip, AudioSource newSource)
    {
        newSource.clip = newClip;
        newSource.volume = 0;
        newSource.loop = true;
        newSource.Play();

        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float progress = t / fadeDuration;

            activeSource.volume = Mathf.Lerp(1, 0, progress);
            newSource.volume = Mathf.Lerp(0, 1, progress);

            yield return null;
        }

        activeSource.Stop();
        activeSource = newSource;
    }
}
