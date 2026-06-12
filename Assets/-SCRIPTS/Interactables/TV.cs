using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TV : MonoBehaviour, IInteractable
{
    private VideoPlayer _videoPlayer;   
    private Outline _outline;
      
    void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.enabled = false;
        _videoPlayer = GetComponent<VideoPlayer>();       
    }
    public void HideOutLine()
    {
        if (_outline != null)
        {
            _outline.enabled = false;
        }
    }
    public void ShowOutLine()
    { 
        if(_outline != null)
        {
            _outline.enabled = true;
        }
    }
    public void Interact()
    {
        if (_videoPlayer.isPlaying)
        {
            _videoPlayer.Stop();            
        }
        else
        {            
            _videoPlayer.Play();
        }
    }
}
