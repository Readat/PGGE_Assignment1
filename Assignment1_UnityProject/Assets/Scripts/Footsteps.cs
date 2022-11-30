using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public GameObject playerObject;
    public CharacterController mCharacterController;
    public AudioSource source;

    //a list of their respective audio clips for the different floor textures
    public AudioClip[] concreteList;
    public AudioClip concrete_one;
    public AudioClip concrete_two;
    public AudioClip concrete_three;
    public AudioClip concrete_four;

    public AudioClip[] sandList;
    public AudioClip sand_one;
    public AudioClip sand_two;
    public AudioClip sand_three;
    public AudioClip sand_four;

    public AudioClip[] dirtList;
    public AudioClip dirt_one;
    public AudioClip dirt_two;
    public AudioClip dirt_three;
    public AudioClip dirt_four;

    public AudioClip[] metalList;
    public AudioClip metal_one;
    public AudioClip metal_two;
    public AudioClip metal_three;
    public AudioClip metal_four;

    public AudioClip[] woodList;
    public AudioClip wood_one;
    public AudioClip wood_two;
    public AudioClip wood_three;
    public AudioClip wood_four;
    public AudioClip wood_five;
    public AudioClip wood_six;

    // Start is called before the first frame update
    void Start()
    {
        mCharacterController = playerObject.GetComponent<CharacterController>();
        //creating the list of audioclips for randomisation later
        concreteList = new AudioClip[]{concrete_one, concrete_two, concrete_three, concrete_four};
        sandList = new AudioClip[]{sand_one, sand_two, sand_three, sand_four};
        dirtList = new AudioClip[]{dirt_one, dirt_two, dirt_three, dirt_four};
        metalList = new AudioClip[]{metal_one, metal_two, metal_three, metal_four};
        woodList = new AudioClip[]{wood_one, wood_two, wood_three, wood_four, wood_five};
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFootstep()
    {
        RaycastHit groundData;
        Vector3 player = playerObject.transform.position;
        //fires raycast from the player directly down to the ground to get info about the ground the player is on
        if(Physics.Raycast(player, Vector3.down, out groundData))
        {
            Debug.Log(groundData.collider.gameObject.tag);
            //checks what type of ground the player is on and play the respective footstep sounds
            if(groundData.collider.gameObject.tag == "Sand")
            {
                //randomize a sound, volume and pitch and play.
                source.Stop();
                source.clip = sandList[Random.Range(0,4)];
                source.volume = Random.Range(0.5f , 1.0f);
                source.pitch = Random.Range(1,5);
                source.Play();
            }
            else if(groundData.collider.gameObject.tag == "Wood")
            {
                //randomize a sound, volume and pitch and play.
                source.Stop();
                source.clip = woodList[Random.Range(0,5)];
                source.volume = Random.Range(0.5f , 1.0f);
                source.pitch = Random.Range(1,5);
                source.Play();
            }
            else if(groundData.collider.gameObject.tag == "Metal")
            {
                //randomize a sound, volume and pitch and play.
                source.Stop();
                source.clip = metalList[Random.Range(0,4)];
                source.volume = Random.Range(0.5f , 1.0f);
                source.pitch = Random.Range(1,5);
                source.Play();
            }
            else if(groundData.collider.gameObject.tag == "Dirt")
            {
                //randomize a sound, volume and pitch and play.
                source.Stop();
                source.clip = dirtList[Random.Range(0,4)];
                source.volume = Random.Range(0.5f , 1.0f);
                source.pitch = Random.Range(1,5);
                source.Play();
            }
            else if(groundData.collider.gameObject.tag == "Concrete")
            {
                //randomize a sound, volume and pitch and play.
                source.Stop();
                source.clip = concreteList[Random.Range(0,4)];
                source.volume = Random.Range(0.5f , 1.0f);
                source.pitch = Random.Range(1,5);
                source.Play();
            }
        }
    }
}
