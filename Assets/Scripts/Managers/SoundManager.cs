using UnityEngine;

[System.Serializable]
public class Sound
{
    public Name name;

    public AudioClip clip;

    public enum Name
    {
        // BGM
        BGM_MAIN,

        // SFX
        SFX_TOUCH
    }
}

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField]
    private Sound[] sounds;

    [SerializeField]
    private AudioSource[] soundPlayers;

    private void Awake()
    {
        InitializeSingleton(this);
    }

    public void Play(Sound.Name soundName, bool loop = false)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == soundName)
            {
                for (int j = 0; j < soundPlayers.Length; j++)
                {
                    if (!soundPlayers[j].isPlaying)
                    {
                        soundPlayers[j].clip = sounds[i].clip;
                        soundPlayers[j].loop = loop;

                        soundPlayers[j].Play();

                        return;
                    }
                }

                return;
            }
        }
    }

    public void Pause()
    {
        for (int i = 0; i < soundPlayers.Length; i++)
        {
            soundPlayers[i].Pause();
        }
    }

    public void Stop()
    {
        for (int i = 0; i < soundPlayers.Length; i++)
        {
            soundPlayers[i].Stop();
        }
    }
}
