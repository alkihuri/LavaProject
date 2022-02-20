using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class AudioManager : MonoSinglethon<AudioManager>
{ 
    [SerializeField]
    private AudioSource _source;

    [SerializeField]
    private AudioClip _shootClip;

    [SerializeField]
    private AudioClip _explosionClip; 

    public void PlayShoot() => _source.PlayOneShot(_shootClip);

    public void PlayExplosion() => _source.PlayOneShot(_explosionClip);


}
