using UnityEngine;
using System.Collections;

public class Songlist : MonoBehaviour {
    public static Songlist instance;

    public AudioSource musicSource;

    public AudioClip[] bgMusic;

    void Awake() {
        if (instance == null)
            instance = this;
    }
    void OnDestroy() {
        if (instance = this) {
            instance = null;
        } else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        if(!musicSource.isPlaying) {
            PlayRandomizedBGMusic();
        }
    }

    public void PlayRandomizedBGMusic() {
        //Generate a random number between 0 and the length of our array of clips passed in.
        int randomIndex = Random.Range(0, bgMusic.Length);
        if (musicSource.isPlaying) {
            musicSource.Stop();
        }
        //Set the clip to the clip at our randomly chosen index.
        musicSource.clip = bgMusic[randomIndex];

        //Play the clip.
        musicSource.Play();
    }
}
