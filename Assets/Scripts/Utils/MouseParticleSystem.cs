using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseParticleSystem : MonoBehaviour
{
    public Object particle;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            GameObject go = (GameObject)Instantiate(particle);
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            float z = Random.Range(-1f, 1f);

            go.transform.position = new Vector2(mousePos.x + x, mousePos.y + y);
            if (go.TryGetComponent<ParticleSystem>(out ParticleSystem ps))
            {
                float duration = ps.main.duration;
                Destroy(particle, duration);
            }
        }
    }
}
