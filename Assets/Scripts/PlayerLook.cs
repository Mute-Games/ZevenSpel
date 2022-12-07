using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLook : MonoBehaviour
{

    private float RotationY;
    private float RotationX;
    private float InputX;
    private float InputY;

    bool started;

    // Start is called before the first frame update
    void Start()
    {
        GameData.Instance.CanMove = true;
        GameData.Instance.Win = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameData.Instance.ResetData();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.Instance.CanMove && !GameData.Instance.Win)
        {
            InputX = Input.GetAxis("Mouse X") * 1f;
            InputY = Input.GetAxis("Mouse Y") * 1f;

            RotationY -= InputY;
            RotationX += InputX;

            RotationY = Mathf.Clamp(RotationY, -65f, 75f);

            transform.localEulerAngles = new Vector3(RotationY, RotationX, 0);
        }
        else
        {
            if (!started)
            {
                started = true;
                if (!GameData.Instance.CanMove) StartCoroutine(Dead());
                else if (GameData.Instance.Win) StartCoroutine(Win());
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator Dead()
    {
        float timer = 0f;
        while (true)
        {
            timer += 1 * Time.deltaTime;
            if (timer < 0.5f)
            {
                Quaternion rotation = Quaternion.Euler(0, 180, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10f * Time.deltaTime);
            }
            else
            {
                Quaternion rotation = Quaternion.Euler(-70, 180, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10f * Time.deltaTime);
            }

            if (timer > 1f)
            {
                SceneManager.LoadScene(0);
            }

            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator Win()
    {
        while (true)
        {
            Quaternion rotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
