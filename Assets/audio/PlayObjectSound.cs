using UnityEngine;

public class PlayObjectSound : MonoBehaviour
{
    public AudioClip objectSound; // Assign the audio clip in Inspector
    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component dynamically if not added
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnMouseDown()  // Detects click or tap
    {
        if (objectSound != null)
        {
            audioSource.PlayOneShot(objectSound); // Play the assigned sound
            Debug.Log("Playing sound for: " + gameObject.name);
        }
        else
        {
            Debug.LogWarning("No audio clip assigned for: " + gameObject.name);
        }
    }
}
