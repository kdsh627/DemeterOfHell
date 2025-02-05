using System;
using UnityEngine;

namespace Donghyun.Enforce
{
    [Serializable]
    public struct EnforceInfo
    {
        public int constant;
        public int minRange;
        public int maxRange;
    }

    public class EnforceManager : MonoBehaviour
    {
        [Header("----- Data -----")]
        [SerializeField] private PlayerDataSO playerData;
        [SerializeField] private PlantDataSO riceData;
        [SerializeField] private PlantDataSO peaShootData;
        [SerializeField] private PlantDataSO hpBuffData;

        [Header("----- Player -----")]
        [SerializeField] private EnforceInfo playerDamage;
        [SerializeField] private EnforceInfo playerMaxHp;
        [SerializeField] private EnforceInfo playerRegenaration;

        [Header("----- Plant -----")]
        [SerializeField] private EnforceInfo riceProduction;
        [SerializeField] private EnforceInfo peaShootDamage;
        [SerializeField] private EnforceInfo hpBuff;

        public void EnforcePlayerDamage()
        {
            playerData.MeleeAttackPower += playerDamage.constant;
            UIManager.Instance.ClosedEnforce();
        }

        public void EnforcePlayerDamageRandom()
        {
            playerData.MeleeAttackPower += UnityEngine.Random.Range(playerDamage.minRange, playerDamage.maxRange);
            UIManager.Instance.ClosedEnforce();
        }

        public void EnforcePlayerMaxHp()
        {
            playerData.Hp += playerMaxHp.constant;
            GameManager.Instance.player.GetComponent<Player>().Hp = playerData.Hp;
            GameManager.Instance.player.GetComponent<Player>().MaxHp = playerData.Hp;
            UIManager.Instance.PlayerHpUIUpdate(playerData.Hp, playerData.Hp);
            UIManager.Instance.ClosedEnforce();
        }

        public void EnforcePlayerMaxHpRandom()
        {
            playerData.Hp += UnityEngine.Random.Range(playerMaxHp.minRange, playerMaxHp.maxRange);
            GameManager.Instance.player.GetComponent<Player>().Hp = playerData.Hp;
            GameManager.Instance.player.GetComponent<Player>().MaxHp = playerData.Hp;
            UIManager.Instance.PlayerHpUIUpdate(playerData.Hp, playerData.Hp);
            UIManager.Instance.ClosedEnforce();
        }

        public void EnforcePlayerRegenaration()
        {
            playerData.RegenerativePower += playerRegenaration.constant;
            UIManager.Instance.ClosedEnforce();
        }

        public void EnforcePlayerRegenarationRandom()
        {
            playerData.RegenerativePower += UnityEngine.Random.Range(playerRegenaration.minRange, playerRegenaration.maxRange);
            UIManager.Instance.ClosedEnforce();
        }

        public void EnforceRiceProduction()
        {
            riceData.Production += riceProduction.constant;
            UIManager.Instance.ClosedEnforce();
        }

        public void EnforceRiceProductionRandom()
        {
            riceData.Production += UnityEngine.Random.Range(riceProduction.minRange, riceProduction.maxRange);
            UIManager.Instance.ClosedEnforce();
        }

        public void EnforcePeaShootDamage()
        {
            peaShootData.Damage += peaShootDamage.constant;
            UIManager.Instance.ClosedEnforce();
        }

        public void EnforcePeaShootDamageRandom()
        {
            peaShootData.Damage += UnityEngine.Random.Range(peaShootDamage.minRange, peaShootDamage.maxRange);
            UIManager.Instance.ClosedEnforce();
        }

        public void EnforceHpBuff()
        {
            hpBuffData.HpBuff += hpBuff.constant;
            UIManager.Instance.ClosedEnforce();
        }

        public void EnforceHpBuffRandom()
        {
            hpBuffData.HpBuff += UnityEngine.Random.Range(hpBuff.minRange, hpBuff.maxRange);
            UIManager.Instance.ClosedEnforce();
        }
    }
}

