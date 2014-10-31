using UnityEngine;
using System.Collections;

public class ImageRetrieverTypes : MonoBehaviour {

	void Update () {
    LeapImageRetriever images = GetComponent<LeapImageRetriever>();
    if (Input.GetKeyDown("1"))
    {
      transform.renderer.enabled = true;
      images.imageColor = Color.white;
      images.blackIsTransparent = true;
      images.undistortImage = true;
    }
    if (Input.GetKeyDown("2")) {
      transform.renderer.enabled = true;
      images.imageColor = Color.white;
      images.blackIsTransparent = false;
      images.undistortImage = true;
    }
    if (Input.GetKeyDown("3")) {
      transform.renderer.enabled = true;
      images.imageColor = Color.black;
      images.blackIsTransparent = true;
      images.undistortImage = true;
    }
    if (Input.GetKeyDown("4"))
    {
      transform.renderer.enabled = false;
    }
	}
}
