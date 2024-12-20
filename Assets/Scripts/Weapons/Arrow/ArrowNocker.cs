using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowNocker: MonoBehaviour
{
    public GameObject arrow;
    public GameObject notch;
    
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable _bow;
    private bool _arrowNocked = false;
    private GameObject _currentArrow = null;

    // SFX
    private AudioSource arrowNockSFX;
    
    // Start is called before the first frame update
    void Start()
    {
        _bow = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        // SFX
        arrowNockSFX = GetComponent<AudioSource>();
        
        DrawInteraction.PullActionReleased += NotchEmpty;
    }
    private void OnDestroy()
    {
        DrawInteraction.PullActionReleased -= NotchEmpty;
    }
        
    // Update is called once per frame
    void Update()
    {
        // Check if the bow is being pulled and an arrow is notched
        if (_bow.isSelected && _arrowNocked == false)
        {
            _arrowNocked = true;
            StartCoroutine("DelayedSpawn");
        }
        // Check if the bow is not being pulled and an arrow is notched
        else if (!_bow.isSelected && _currentArrow != null)
        {
            Destroy(_currentArrow);
            NotchEmpty(1f);
        }
    }

    private void NotchEmpty(float pullAmount)
    {
        _arrowNocked = false;
        _currentArrow = null;
    }
    IEnumerator DelayedSpawn()
    {
        yield return new WaitForSeconds(1f);
        _currentArrow = Instantiate(arrow, notch.transform);

        // SFX
        PlayNockSound();
    }

    // SFX
    private void PlayNockSound()
    {
        arrowNockSFX.Play();
    }
}
