using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class IntroLevelManager : MonoBehaviour
{
    public AudioSource audioSource;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.Play();
        if (collision.gameObject.CompareTag("Hero"))
        {
            
            SceneManager.LoadScene(2);
        }

    }
}
