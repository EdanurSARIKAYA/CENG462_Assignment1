using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] AudioSource music;
    private bool muted = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Load();
        ApplyMusicSettings();
    }

    // Müzik durumuna göre uygula
    private void ApplyMusicSettings()
    {
        if (muted)
            music.Stop();
        else
            music.Play();
    }

    // Müziği aç
    public void OnMusic()
    {
        muted = false;
        music.Play();
        Save();
    }

    // Müziği kapat
    public void OffMusic()
    {
        muted = true;
        music.Stop();
        Save();
    }
    // Ayarları yükle
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted", 0) == 1;
    }

    // Ayarları kaydet
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }


}
