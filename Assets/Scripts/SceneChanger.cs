using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenehanger : MonoBehaviour
{
    [Header("Scene Settings")]
    [Tooltip("The name of the scene to load when the player touches this object.")]
    public string sceneToLoad;

    [Header("Player Settings")]
    [Tooltip("Tag assigned to the player object.")]
    public string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object colliding has the correct tag
        if (other.CompareTag(playerTag))
        {
            Debug.Log($"Player touched object. Loading scene: {sceneToLoad}");
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
