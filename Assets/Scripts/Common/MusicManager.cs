using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    public AudioSource themeMusic;
    public AudioSource flipSound;
    public AudioSource hitSound;
    public AudioSource outOfBoundsSound;
    public AudioSource invisibleSound;
    public AudioSource doublePointsSound;
    
    public void ToggleThemeMusic(bool isOn) => themeMusic.volume = isOn ? 1 : 0;
    
    public void MakeFlipSound() => flipSound.Play();
    public void MakeHitSound() => hitSound.Play();
    public void MakeOutOfBoundsSound() => outOfBoundsSound.Play();
    
    public void MakeInvisibleSound() => invisibleSound.Play();
    
    public void MakeDoublePointsSound() => doublePointsSound.Play();

    public void ToggleBirdSounds(bool isOn) {
        var value = isOn ? 1 : 0;

        flipSound.volume = value;
        hitSound.volume = value;
        outOfBoundsSound.volume = value;
        invisibleSound.volume = value;
        doublePointsSound.volume = value;
    }
}
