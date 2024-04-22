using UnityEngine;

namespace FPPGame
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Configs/WeaponConfig")]

    public class WeaponConfig : ScriptableObject
    {
        public GameObject Prefab;
        public AudioClip FireSound;
        public AudioClip HitSound;
        public ParticleSystem HitEffect;
        public int Id;
        public string Name;
        public int Damage;
        public float Range;
        public float FireRate;
        public WeaponType Type;
        public float Snappinness;
        public float KickbackForce;
        public float KickbackDuration;
        public float RecoilX;
        public float RecoilY;
        public float RecoilZ;
    }
    
    public enum WeaponType
    {
        Unknown = 0,
        Machingun = 1,
        Melee = 2,
    }
}