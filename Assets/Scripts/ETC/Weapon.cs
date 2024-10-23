using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string weaponName;
    public float fireRate; // Time btw Shoot
    public float currentTimeBTWShoot; // ����������������
    public int maxAmmo; // ������������ ����� ��������
    public int currentAmmo; // ������� ����� ��������
    public float reloadTime; // ����� �����������
    public float currentReloadTime;
    public GameObject bullet;
    public int ammoType;// 0 - pistol

    public bool isReloading = false;

    public void Shoot(Transform shootPoint)
    {
        if(currentTimeBTWShoot<=0 && currentAmmo>0)
        {
            Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            currentTimeBTWShoot = fireRate;
            currentAmmo -= 1;
        }
        if(currentAmmo==0)
        {
            isReloading = true;
        }
    }
}
