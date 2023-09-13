using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
 public static AudioManager singleton;
 public AudioClip[] clips;
 AudioSource audioSource;

 public void Awake()
 {
    singleton=this;
    audioSource=GetComponent<AudioSource>();
 }

 public void playSound(int clipIndex)
 {
    audioSource.PlayOneShot(clips[clipIndex]);
 }
}
