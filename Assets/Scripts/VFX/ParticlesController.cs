using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace sample.VFX
{
    public class ParticlesController : MonoBehaviour
    {
        [SerializeField] ParticleSystem _stars;

        public void PlayStars(Transform newTransform)
        {
            _stars.transform.position = newTransform.position;
            _stars.Play();
        }
    }

}
