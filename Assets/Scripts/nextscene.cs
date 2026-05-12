using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class nextscne : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //change one scene higher.
        if (other.CompareTag("Player"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex: UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //change one scene higher.
        if (other.CompareTag("Player"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex: UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //change one scene higher.
        if (other.CompareTag("Player"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex: UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //change one scene higher.
        if (collision.gameObject.CompareTag("Player"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex: UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    //Make sure none of this happens unless the player is the only thing left in the scene, otherwise it will cause problems.
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex: UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
