using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public CharacterController CharacterController;

    Vector3 GravityEffect;
    float Gravity = -9.81f;

    // Update is called once per frame
    void Update()
    {
        if (GameData.Instance.CanMove && !GameData.Instance.Win)
        {
            Vector3 Movement = transform.right * Time.deltaTime * Speed * Input.GetAxis("Horizontal") + transform.forward * Time.deltaTime * Speed * Input.GetAxis("Vertical");
            CharacterController.Move(Movement);

            GravityEffect.y += Gravity * Time.deltaTime;
            CharacterController.Move(GravityEffect);
        }
    }
}
