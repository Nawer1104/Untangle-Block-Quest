using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public GameObject vfxTouch;

    private int Id;

    private void Awake()
    {
        Id = GetInstanceID();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Wall"))
        {
            GameObject vfx = Instantiate(vfxTouch, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);

            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
            GameManager.Instance.CheckLevelUp();
            gameObject.SetActive(false);
        }
        else if (collision != null && collision.gameObject.CompareTag("Object"))
        {
            GetComponent<DragAndDrop>()._dragging = false;
        }
    }
}
