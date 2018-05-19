using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Skilltree : MonoBehaviour {

	public bool unlockedBarbar = false;
	public bool unlockedRoemer = false;
	public bool unlockedPerser = false;
	public bool unlockedAegypter = false;
	public bool unlockedHRRDN = false;
	public bool unlockedAss = false;
	public bool unlockedDe = false;
	public bool unlockedBrit = false;
	public bool unlockedFr = false;
	public bool unlockedAmi = false;
	public bool unlockedIsis = false;





	public int Resistence;
	public int HealBuff;
	public int Hitchance;
	public int HealthBuff;
	public int DamageBuff;


	public int HSHealth;
	public int HSDamage;

	public int NHealth;
	public int NDamage;

	public int BarbarHealth;
	public int BarbarDamage;

	public int RoemerHealth;
	public int RoemerDamage;

	public int PerserHealth;
	public int PerserDamage;

	public int AegypterHealth;
	public int AegypterDamage;

	public int HRRDNHealth;
	public int HRRDNDamage;

	public int AssHealth;
	public int AssDamage;

	public int IsisHealth;
	public int IsisDamage;

	public int DHealth;
	public int DDamage;

	public int FrHealth;
	public int FrDamage;

	public int BritHealth;
	public int BritDamage;

	public int AmiHealth;
	public int AmiDamage;


	// Use this for initialization
	void Start () {
		 		
	}


	public void unlockBarbar() {
		
		unlockedBarbar = true;
	}

	public void unlockRoemer() {
		unlockedRoemer = true;
	}

	public void unlockPerser() {
		unlockedPerser = true;
	}

	public void unlockAegypter() {
		unlockedAegypter = true;
	}

	public void unlockHRRDN() {
		unlockedHRRDN = true;
	}

	public void unlockAss() {
		unlockedAss = true;
	}

	public void unlockDe() {
		unlockedDe = true;
	}

	public void unlockBrit() {
		unlockedBrit = true;
	}

	public void unlockFr() {
		unlockedFr = true;
	}

	public void unlockAmi() {
		unlockedAmi = true;
	}

	public void unlockIsis() {
		unlockedIsis = true;
	}





	public void BuffResistance(int resvalue) {
		Resistence = Resistence + resvalue;
	}

	public void BuffHitchance(int hitvalue) {
		Hitchance = Hitchance + hitvalue;
	}

	public void BuffHealvalue(int healvalue) {
		HealBuff = HealBuff + healvalue;
	}

	public void BuffHSHealth(int HSHealthBuff) {
		HSHealth = HSHealth + HSHealthBuff;
	}

	public void BuffHSDamage(int HSDamageBuff) {
		HSDamage += HSDamageBuff;
	}

	public void BuffNHealth(int NHealthBuff) {
		NHealth += NHealthBuff;
	}

	public void BuffNDamage(int NDamageBuff) {
		NDamage += NDamageBuff;
	}

	public void BuffBarbarHealth(int BarbarHealthBuff) {
		BarbarHealth += BarbarHealthBuff;
	}

	public void BuffBarbarDamage(int BarbarDamageBuff) {
		BarbarDamage += BarbarDamageBuff;
	}

	public void BuffRoemerHealth(int RoemerHealthBuff) {
		RoemerHealth += RoemerHealthBuff;
	}

	public void BuffRoemerDamage(int RoemerDamageBuff) {
		RoemerDamage += RoemerDamageBuff;
	}

	public void BuffPerserHealth(int PerserHealthBuff) {
		PerserHealth += PerserHealthBuff;
	}

	public void BuffPerserDamage(int PerserDamageBuff) {
		PerserDamage += PerserDamageBuff;
	}

	public void BuffAegypterHealth(int AegypterHealthBuff) {
		AegypterHealth += AegypterHealthBuff;
	}

	public void BuffAegypterDamage(int AegypterDamageBuff) {
		AegypterDamage += AegypterDamageBuff;
	}

	public void BuffHRRDNHealth(int HRRDNHealthBuff) {
		HRRDNHealth += HRRDNHealthBuff;
	}

	public void BuffHRRDNDamage(int HRRDNDamageBuff) {
		HRRDNDamage += HRRDNDamageBuff;
	}

	public void BuffAssHealth(int AssHealthBuff) {
		AssHealth += AssHealthBuff;
	}

	public void BuffAssDamage(int AssDamageBuff) {
		AssDamage += AssDamageBuff;
	}

	public void BuffIsisHealth(int IsisHealthBuff) {
		IsisHealth += IsisHealthBuff;
	}

	public void BuffIsisDamage(int IsisDamageBuff) {
		IsisDamage += IsisDamageBuff;
	}

	public void BuffDHealth(int DHealthBuff) {
		DHealth += DHealthBuff;
	}

	public void BuffDDamage(int DDamageBuff) {
		DDamage += DDamageBuff;
	}

	public void BuffFrHealth(int FrHealthBuff) {
		FrHealth += FrHealthBuff;
	}

	public void BuffFrDamage(int FrDamageBuff) {
		FrDamage += FrDamageBuff;
	}

	public void BuffBritHealth(int BritHealthBuff) {
		BritHealth += BritHealthBuff;
	}

	public void BuffBritDamage(int BritDamageBuff) {
		BritDamage += BritDamageBuff;
	}

	public void BuffAmiHealth(int AmiHealthBuff) {
		AmiHealth += AmiHealthBuff;
	}

	public void BuffAmiDamage(int AmiDamageBuff) {
		AmiDamage += AmiDamageBuff;
	}

	public void BuffEverybody(int EverybodyBuff) {
		DamageBuff += EverybodyBuff;
		HealthBuff += EverybodyBuff;
	}


	public void buttonActivated() {
		
	}

}


