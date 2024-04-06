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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlowerCollected()
    {
        collectableAudio.Play();
    }
}
