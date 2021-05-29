using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class up : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("triggered");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
