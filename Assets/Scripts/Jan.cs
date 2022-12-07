using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jan : MonoBehaviour
{
    public GameObject Player;
    public Animator Animator;
    public AudioSource Audio;

    bool playing = false;

    // Update is called once per frame
    void Update()
    {
        if (!GameData.Instance.CanMove)
        {
            Animator.SetBool("punch", true);
            if (!playing)
            {
                Audio.Play();
                playing = true;
            }
            Vector3 bruh = new Vector3();
            Vector3 playerPos0 = new Vector3(Player.transform.position.x, 0, Player.transform.position.z - 1);
            transform.position = Vector3.SmoothDamp(transform.localPosition, playerPos0, ref bruh, 0.01f);
        }
        else if (GameData.Instance.Win)
        {
            Animator.SetBool("win", true);
            Vector3 bruh = new Vector3();
            Vector3 playerPos0 = new Vector3(Player.transform.position.x, 0, Player.transform.position.z - 3);
            transform.position = Vector3.SmoothDamp(transform.localPosition, playerPos0, ref bruh, 0.01f);
        }
        else
        {
            transform.position = new Vector3(Player.transform.position.x, 0 , Player.transform.position.z - 10);
        }
    }
}
