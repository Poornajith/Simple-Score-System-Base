using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_ParticleSystem;
    [SerializeField] private int m_PoolSize = 10;

    private List<ParticleSystem> m_ParticlePool;
    private void Awake()
    {
        m_ParticlePool = new List<ParticleSystem>();
        for (int i = 0; i < m_PoolSize; i++)
        {
            AddParticleToPool();
        }
    }

    private void AddParticleToPool()
    {
        ParticleSystem particle = Instantiate(m_ParticleSystem, transform);
        particle.Stop();
        m_ParticlePool.Add(particle);
    }

    private ParticleSystem GetParticleFromPool()
    {
        foreach (ParticleSystem particle in m_ParticlePool)
        {
            if (!particle.isPlaying)
            {
                return particle;
            }
        }
        AddParticleToPool();
        return m_ParticlePool[m_ParticlePool.Count - 1];
    }

    public void PlayParticle(Vector3 position)
    {
        ParticleSystem particle = GetParticleFromPool();
        particle.transform.position = position;
        particle.Play();
    }
}
