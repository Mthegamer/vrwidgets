using UnityEngine;
using System.Collections;

namespace VRWidgets
{
  public class ScrollViewer : MonoBehaviour
  {
    public ScrollContent scrollContent;
    public GameObject scrollBoundaries;
    public GameObject scrollWindow;
    public GameObject scrollCursor;

    private Limits boundaries_ = new Limits();

    // Use this for initialization
    void Start()
    {
      boundaries_.GetLimitsToLocal(scrollBoundaries, gameObject);
      scrollWindow.transform.localPosition = new Vector3((boundaries_.r + boundaries_.l) / 2.0f, (boundaries_.t + boundaries_.b) / 2.0f, 0.0f);
      scrollWindow.transform.localScale = new Vector3((boundaries_.r - boundaries_.l), (boundaries_.t - boundaries_.b), 0.0f);
    }

    void LateUpdate()
    {
      float percent = scrollContent.content_percentage;
      float position = (boundaries_.t - boundaries_.b) * percent + boundaries_.b;
      Vector3 scroll_position = scrollCursor.transform.localPosition;
      scroll_position.y = position;
      scrollCursor.transform.localPosition = scroll_position;
    }
  }
}

