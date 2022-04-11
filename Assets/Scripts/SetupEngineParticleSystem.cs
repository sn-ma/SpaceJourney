using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupEngineParticleSystem : MonoBehaviour
{
    private new ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();

        var main = particleSystem.main;
        main.customSimulationSpace = Camera.main.transform;
    }
}
