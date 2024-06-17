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
            GameObject go = (GameObject)Instantiate(particle);
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            float z = Random.Range(-1f, 1f);

            go.transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z);
            if (go.TryGetComponent<ParticleSystem>(out ParticleSystem ps))
            {
                float duration = ps.main.duration;
                Destroy(particle, duration);
            }
        }
    }
}
