using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class down : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        SoundManager.instance.Pause("Walk");
        Debug.Log("triggered");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
