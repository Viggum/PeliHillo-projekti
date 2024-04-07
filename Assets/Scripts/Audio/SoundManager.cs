using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource collectableAudio;

    private void OnEnable()
    {
        Flower.OnFlowerCollected += FlowerCollected;
    }

    private void OnDisable()
    {
        Flower.OnFlowerCollected -= FlowerCollected;
    }

    public void FlowerCollected()
    {
        collectableAudio.PlayOneShot(collectableAudio.clip);
    }
}
