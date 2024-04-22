using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

namespace FPPGame
{
    public class WeaponManager : MonoBehaviour
    {
        private bool _isWeaponCooldown;
        private Vector3 currentRotation;
        private Vector3 targetRotation;
        private Vector3 targetPosition;
        private Vector3 currentPosition;
        private Vector3 initialGunPosition;
        
        private List<WeaponConfig> _weapons;
        [SerializeField] private int _smoothnessOfSwing;
        [SerializeField] private int _movementFactor;
        private Quaternion _originalRotation;
        [SerializeField] private GameObject _poof;
        [SerializeField] private GameObject _weapon;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Camera _camera;
        [SerializeField] private ParticleSystem _muzzleFlash;
        [SerializeField] private ParticleSystem _ability1;

        //no switcher for now
        private WeaponConfig _currentWeapon => _weapons[0];
     
        void Start()
        {
            initialGunPosition = _weapon.transform.localPosition;
            _weapons = GameManager.MainConfig.WeaponsConfig._weapons;
            _originalRotation = _weapon.transform.localRotation;
        }
  
        void Update()
        {
            Swing();
            backSwing();
            
            if (Input.GetButton("Fire1"))
            {
                Shoot();
            }
            
            BackRecoil();
        }
        
        private void Shoot()
        {
            if (_isWeaponCooldown)
            {
                return;
            }
            
            RaycastHit hitInfo;
            
            _isWeaponCooldown = true;
            Invoke(nameof(ResetCooldown), _currentWeapon.FireRate);
            ApplyRecoil();
            FireSound();
            _muzzleFlash.Play();
  
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hitInfo, _weapons[0].Range))
            {
                Debug.DrawRay(_camera.transform.position, _camera.transform.forward * hitInfo.distance, Color.red, 1f);
                var enemy = hitInfo.collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.GetHit(_weapons[0].Damage);

                    var hitPoint = hitInfo.point;
                    GameManager.PoofSpawner.SpawnPoof(hitPoint, _poof);
                }
            }
        }

        private void ResetCooldown()
        {
            _isWeaponCooldown = false;
        }
        
        private void FireSound()
        {
            _audioSource.PlayOneShot(_currentWeapon.FireSound);
        }

        private void ApplyRecoil()
        {
           targetPosition -= new Vector3(0, 0, _currentWeapon.KickbackForce);
           targetRotation += new Vector3(_currentWeapon.RecoilX, Random.Range(-_currentWeapon.RecoilY, _currentWeapon.RecoilY), Random.Range(-_currentWeapon.RecoilZ, _currentWeapon.RecoilZ));
        }

        private void BackRecoil()
        {
            targetPosition = Vector3.Lerp(targetPosition, initialGunPosition, Time.deltaTime * _currentWeapon.KickbackDuration);
            currentPosition = Vector3.Lerp(currentPosition, targetPosition, Time.fixedDeltaTime * _currentWeapon.Snappinness);
            _weapon.transform.localPosition = currentPosition;
        }

        private void Swing()
        {
            var mouseX = Input.GetAxis("Mouse X") * _smoothnessOfSwing;
            var mouseY = Input.GetAxis("Mouse Y") * _smoothnessOfSwing;

            var rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
            var rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

            var weaponRotation = rotationX * rotationY;

            _weapon.transform.localRotation *= Quaternion.Slerp(Quaternion.identity, weaponRotation, Time.deltaTime * _movementFactor);
        }

        private void backSwing()
        {
            _weapon.transform.localRotation = Quaternion.Slerp(_weapon.transform.localRotation, _originalRotation, Time.deltaTime * _smoothnessOfSwing);
        }
    }
}