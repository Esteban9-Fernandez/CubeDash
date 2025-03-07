using UnityEngine;
using UnityEngine.UI;

public class SliderSonido : MonoBehaviour
{
    [SerializeField] private Slider slider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("Volumen"))
        {
            PlayerPrefs.SetFloat("Volumen", 1);
            PlayerPrefs.Save();
        }

        Load();
    }

    public void CambiarVolumen()
    {
        AudioListener.volume = slider.value;
        Save();
    }

    private void Load()
    {
        slider.value = PlayerPrefs.GetFloat("Volumen");
        AudioListener.volume = slider.value;
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Volumen", slider.value);
        PlayerPrefs.Save();
    }
}
