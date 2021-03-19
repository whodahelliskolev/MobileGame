using UnityEngine;
using UnityEngine.EventSystems;


public class ScrollRectSystem : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private int referenceDPI = 100;
    [SerializeField] private float referencePixelDrag = 8f;
    [SerializeField] private bool runOnAwake = true;

    void Awake()
    {
        if (runOnAwake)
        {
            UpdatePixelDrag(Screen.dpi);
        }
    }

    public void UpdatePixelDrag(float screenDpi)
    {
        if (eventSystem == null)
        {
            Debug.LogWarning("Trying to set pixel drag for adapting to screen dpi, " +
                           "but there is no event system assigned to the script", this);
        }
        eventSystem.pixelDragThreshold = Mathf.RoundToInt(screenDpi / referenceDPI * referencePixelDrag);
    }

    void Reset()
    {
        if (eventSystem == null)
        {
            eventSystem = GetComponent<EventSystem>();
        }
    }
}