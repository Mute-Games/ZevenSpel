using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Camera Cam;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit))
            {
                Debug.Log(hit.transform.name);
                Button button = hit.transform.GetComponent<Button>();
                if (button != null)
                {
                    if (button.Value == 7) GameData.Instance.CanMove = false;
                    else if (button.Value >= 0) GameData.Instance.PlayerInput += button.Value;
                    else
                    {
                        GameData.Instance.EnterTrue();
                    }
                }
            }
        }
    }


}
