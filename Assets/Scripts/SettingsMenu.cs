using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public enum Difficulties { Easy, Medium, Hard};
    public static Difficulties difficulty = Difficulties.Easy;

    public void SetVolume(float volume) {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetDifficulty(int diffIndex) {
        switch (diffIndex)
        {
            case 0:
                difficulty = Difficulties.Easy;
                break;

            case 1:
                difficulty = Difficulties.Medium;
                break;

            case 2:
                difficulty = Difficulties.Hard;
                break;
            default:
                difficulty = Difficulties.Easy;
                break;
        }

        Debug.Log(difficulty.ToString());
        
    }
}
