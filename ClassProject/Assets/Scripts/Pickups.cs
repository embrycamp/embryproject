using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    // reference to player
    public PlayerController player;

    public AudioSource source;
    public AudioClip yippee;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       player = GameObject.Find("Player").GetComponent<PlayerController>();

        source.clip = yippee;
        source.Play();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            player.coinCount++;
            Destroy(this.gameObject);

        }

    }

}
