// Project:         GottaPetEmAll for Daggerfall Unity (http://www.dfworkshop.net)
// Copyright:       Copyright (C) 2022 Cliffworms
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)
// Author:          Magicono43/Cliffworms

using System;
using UnityEngine;
using DaggerfallConnect.Arena2;
using DaggerfallWorkshop;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Guilds;
using DaggerfallWorkshop.Game.Serialization;
using DaggerfallWorkshop.Game.Utility;
using DaggerfallWorkshop.Game.Utility.ModSupport;
using DaggerfallWorkshop.Utility.AssetInjection;


namespace GottaPetEmAll
{
    public class GottaPetEmAllMod : MonoBehaviour
    {
        static Mod mod;
		
		#region Mod Sound Variables
		
		// Misc Variables
		public static AudioSource UIAudioSource { get; set; }

        // Mod Sounds
        public static AudioClip CamelPetSound = null;
		public static AudioClip MonkeyPetSound = null;
		public static AudioClip BoarPetSound = null;
		public static AudioClip CalfPetSound = null;
		public static AudioClip CatPetSound = null;
		public static AudioClip ChickenPetSound = null;
		public static AudioClip CowPetSound = null;
		public static AudioClip CoyotePetSound = null;
		public static AudioClip DogPetSound = null;
		public static AudioClip DogAngryPetSound = null;
		public static AudioClip DovePetSound = null;
		public static AudioClip FrostEaglePetSound = null;
		public static AudioClip GriffinPetSound = null;
		public static AudioClip HissPetSound = null;
		public static AudioClip HorsePetSound = null;
		public static AudioClip PigPetSound = null;
		public static AudioClip PulletPetSound = null;
		public static AudioClip RatPetSound = null;
		public static AudioClip RoosterPetSound = null;
		public static AudioClip SeagullPetSound = null;
		public static AudioClip SheepPetSound = null;
		public static AudioClip VulturePetSound = null;
		public static AudioClip RavenPetSound = null;

        #endregion

        [Invoke(StateManager.StateTypes.Start, 0)]
        public static void Init(InitParams initParams)
        {
            mod = initParams.Mod;
            var go = new GameObject(mod.Title);
            go.AddComponent<GottaPetEmAllMod>();
        }

        void Awake()
        {
            Debug.Log("Begin mod init: GottaPetEmAll");
			
			// Load Resources
            LoadAudio();

			// Vanilla Animals

			PlayerActivate.RegisterCustomActivation(mod, 201, 0, HorseActivation);
			PlayerActivate.RegisterCustomActivation(mod, 201, 1, HorseActivation);
			PlayerActivate.RegisterCustomActivation(mod, 201, 2, CamelActivation);
			PlayerActivate.RegisterCustomActivation(mod, 201, 3, CowActivation);
			PlayerActivate.RegisterCustomActivation(mod, 201, 4, CowActivation);
			PlayerActivate.RegisterCustomActivation(mod, 201, 5, PigActivation);
			PlayerActivate.RegisterCustomActivation(mod, 201, 6, PigActivation);
			PlayerActivate.RegisterCustomActivation(mod, 201, 7, CatActivation);
			PlayerActivate.RegisterCustomActivation(mod, 201, 8, CatActivation);
			PlayerActivate.RegisterCustomActivation(mod, 201, 9, DogActivation);
			PlayerActivate.RegisterCustomActivation(mod, 201, 10, AngryDogActivation);
			PlayerActivate.RegisterCustomActivation(mod, 201, 11, SeagullActivation);
			PlayerActivate.RegisterCustomActivation(mod, 212, 6, RavenActivation);
			// Vanilla Animals

			// DET Animals
			PlayerActivate.RegisterCustomActivation(mod, 1009, 0, GriffinActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1009, 1, FrostEagleActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1009, 2, FrostEagleActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1009, 3, VultureActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1009, 4, DaggerbackActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1009, 5, SepAdderActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1009, 6, SepAdderActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1009, 7, StagActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1009, 23, StagActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1009, 8, DoeActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1009, 19, DoeActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1009, 20, DoeActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1009, 21, DoeActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1009, 22, FawnActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1009, 11, MonkeyActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1009, 12, MonkeyActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1009, 13, MonkeyActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1009, 14, MonkeyActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1009, 15, MonkeyActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1009, 16, MonkeyActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1009, 17, MonkeyActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1009, 24, DuneRipperActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1009, 25, DuneRipperActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1009, 26, CoyoteActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1009, 27, CoyoteActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1009, 28, CoyoteActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 0, PonyActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 1, BasiliskActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 2, AlcaireCartHorseActivation);
            PlayerActivate.RegisterCustomActivation(mod, 1010, 32, AlcaireCartHorseActivation);


			PlayerActivate.RegisterCustomActivation(mod, 1010, 3, RoosterActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 8, RoosterActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 11, RoosterActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 25, RoosterActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 4, ChickenActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 5, ChickenActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 6, ChickenActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 9, ChickenActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 10, ChickenActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 12, ChickenActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 22, ChickenActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 7, PulletActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 13, PulletActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 14, PulletActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 21, PulletActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 15, SheepActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 16, SheepActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 17, SheepActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 18, CowActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 61, CowActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 19, CalfActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 20, BullActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 26, WayrestChargerActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 27, WayrestChargerActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 28, WayrestChargerActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 29, WayrestChargerActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 30, WayrestChargerActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 31, WayrestChargerActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 33, RatActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 36, RatActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 37, RatActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 38, RatActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 39, RatActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 40, RatActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 41, RatActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 34, TameBoarActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 35, TameBoarActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 42, DoveActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 43, DoveActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 44, DoveActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 45, DoveActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 46, DoveActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 47, DoveActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 48, DoveActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 49, DoveActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 50, DoveActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 51, HorseActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 52, HorseActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 53, CamelActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 54, CamelActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 55, CamelActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 56, CamelActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 58, CamelActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 59, CamelActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 57, AbibonGoraWarCamelActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 60, AlcaireBeltedBullActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 62, AlcaireBeltedCowActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 63, AlcaireBeltedCowActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 64, AlcaireBeltedCowActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 65, AlcaireBeltedCowActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 67, AlcaireBeltedCowActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 68, AlcaireBeltedCowActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 69, AlcaireBeltedCowActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 66, AlcaireBeltedCalfActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 70, AlcaireBeltedCalfActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 71, AlcaireBeltedCalfActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 73, GreatDaenianDogActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 75, GreatDaenianDogActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 76, GreatDaenianDogActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 77, GreatDaenianDogActivation);
			PlayerActivate.RegisterCustomActivation(mod, 1010, 78, GreatDaenianDogActivation);

			PlayerActivate.RegisterCustomActivation(mod, 1010, 74, AngryDogActivation);


			// DET Animals

            mod.IsReady = true;
            Debug.Log("Finished mod init: GottaPetEmAll");
        }
		
		#region Load Audio Clips

        private void LoadAudio()
        {
            ModManager modManager = ModManager.Instance;
            bool success = true;
			
			DaggerfallAudioSource dfAudio = DaggerfallUI.Instance.GetComponent<DaggerfallAudioSource>();
			if (dfAudio != null) { UIAudioSource = dfAudio.AudioSource; }
			else { Debug.Log("ERROR: GottaPetEmAll Could Not Find DaggerfallUI Object Reference!"); }

            success &= modManager.TryGetAsset("Camel", false, out CamelPetSound);
			success &= modManager.TryGetAsset("Monkey", false, out MonkeyPetSound);
			success &= modManager.TryGetAsset("Boar", false, out BoarPetSound);
			success &= modManager.TryGetAsset("Calf", false, out CalfPetSound);
			success &= modManager.TryGetAsset("Cat", false, out CatPetSound);
			success &= modManager.TryGetAsset("Chicken", false, out ChickenPetSound);
			success &= modManager.TryGetAsset("Cow", false, out CowPetSound);
			success &= modManager.TryGetAsset("Coyote", false, out CoyotePetSound);
			success &= modManager.TryGetAsset("Dog", false, out DogPetSound);
			success &= modManager.TryGetAsset("DogAngry", false, out DogAngryPetSound);
			success &= modManager.TryGetAsset("Dove", false, out DovePetSound);
			success &= modManager.TryGetAsset("FrostEagle", false, out FrostEaglePetSound);
			success &= modManager.TryGetAsset("Griffin", false, out GriffinPetSound);
			success &= modManager.TryGetAsset("Hiss", false, out HissPetSound);
			success &= modManager.TryGetAsset("Horse", false, out HorsePetSound);
			success &= modManager.TryGetAsset("Pig", false, out PigPetSound);
			success &= modManager.TryGetAsset("Pullet", false, out PulletPetSound);
			success &= modManager.TryGetAsset("Rat", false, out RatPetSound);
			success &= modManager.TryGetAsset("Raven", false, out RavenPetSound);
			success &= modManager.TryGetAsset("Rooster", false, out RoosterPetSound);
			success &= modManager.TryGetAsset("Seagull", false, out SeagullPetSound);
			success &= modManager.TryGetAsset("Sheep", false, out SheepPetSound);
			success &= modManager.TryGetAsset("Vulture", false, out VulturePetSound);

            if (!success)
                throw new Exception("GottaPetEmAll: Missing sound asset");
        }

        #endregion
		
		#region Magicono43's Messy Hacky Code For Animal Clicking Text

        // Vanilla Animals

		private static void HorseActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the horse.", 5f);
			if (UIAudioSource != null && HorsePetSound != null) { UIAudioSource.PlayOneShot(HorsePetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void CamelActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the camel.", 5f);
			if (UIAudioSource != null && CamelPetSound != null) { UIAudioSource.PlayOneShot(CamelPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void CowActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the cow.", 5f);
			if (UIAudioSource != null && CowPetSound != null) { UIAudioSource.PlayOneShot(CowPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void PigActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the pig.", 5f);
			if (UIAudioSource != null && PigPetSound != null) { UIAudioSource.PlayOneShot(PigPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void CatActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the cat.", 5f);
			if (UIAudioSource != null && CatPetSound != null) { UIAudioSource.PlayOneShot(CatPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void DogActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the dog.", 5f);
			if (UIAudioSource != null && DogPetSound != null) { UIAudioSource.PlayOneShot(DogPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void SeagullActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the seagull.", 5f);
			if (UIAudioSource != null && SeagullPetSound != null) { UIAudioSource.PlayOneShot(SeagullPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void RavenActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the raven.", 5f);
			if (UIAudioSource != null && RavenPetSound != null) { UIAudioSource.PlayOneShot(RavenPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void AngryDogActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You try to pet the dog but it backs away, growling.", 5f);
			if (UIAudioSource != null && DogAngryPetSound != null) { UIAudioSource.PlayOneShot(DogAngryPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }
        // Vanilla Animals

        // DET Animals
		private static void GriffinActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the griffin.", 5f);
			if (UIAudioSource != null && GriffinPetSound != null) { UIAudioSource.PlayOneShot(GriffinPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void FrostEagleActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the Frost Eagle.", 5f);
			if (UIAudioSource != null && FrostEaglePetSound != null) { UIAudioSource.PlayOneShot(FrostEaglePetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void VultureActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the vulture.", 5f);
			if (UIAudioSource != null && VulturePetSound != null) { UIAudioSource.PlayOneShot(VulturePetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void DaggerbackActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You try to pet the Daggerback Boar but it squeals at you menacingly.", 5f);
			if (UIAudioSource != null && BoarPetSound != null) { UIAudioSource.PlayOneShot(BoarPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void SepAdderActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You try to pet the sep adder but it hisses at you menacingly.", 5f);
			if (UIAudioSource != null && HissPetSound != null) { UIAudioSource.PlayOneShot(HissPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }        

		private static void StagActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the stag.", 5f);
        }        

		private static void DoeActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the doe.", 5f);
        }        

		private static void FawnActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the fawn.", 5f);
        }       

		private static void MonkeyActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the monkey.", 5f);
			if (UIAudioSource != null && MonkeyPetSound != null) { UIAudioSource.PlayOneShot(MonkeyPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }      

		private static void DuneRipperActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You try to pet the dune ripper but it hisses at you menacingly.", 5f);
			if (UIAudioSource != null && HissPetSound != null) { UIAudioSource.PlayOneShot(HissPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }  

		private static void CoyoteActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You try to pet the coyote but it barks at you menacingly.", 5f);
			if (UIAudioSource != null && CoyotePetSound != null) { UIAudioSource.PlayOneShot(CoyotePetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }  

		private static void PonyActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the Glen Pony.", 5f);
			if (UIAudioSource != null && HorsePetSound != null) { UIAudioSource.PlayOneShot(HorsePetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }  

		private static void BasiliskActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the tame basilisk.", 5f);
			if (UIAudioSource != null && HissPetSound != null) { UIAudioSource.PlayOneShot(HissPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }  

		private static void AlcaireCartHorseActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the Alcaire Cart Horse.", 5f);
			if (UIAudioSource != null && HorsePetSound != null) { UIAudioSource.PlayOneShot(HorsePetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }  

		private static void RoosterActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the rooster.", 5f);
			if (UIAudioSource != null && RoosterPetSound != null) { UIAudioSource.PlayOneShot(RoosterPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }  

		private static void ChickenActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the chicken.", 5f);
			if (UIAudioSource != null && ChickenPetSound != null) { UIAudioSource.PlayOneShot(ChickenPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }  

		private static void PulletActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the pullet.", 5f);
			if (UIAudioSource != null && PulletPetSound != null) { UIAudioSource.PlayOneShot(PulletPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }  

		private static void SheepActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the sheep.", 5f);
			if (UIAudioSource != null && SheepPetSound != null) { UIAudioSource.PlayOneShot(SheepPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }  

		private static void CalfActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the curious calf.", 5f);
			if (UIAudioSource != null && CalfPetSound != null) { UIAudioSource.PlayOneShot(CalfPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void BullActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the bull.", 5f);
			if (UIAudioSource != null && CowPetSound != null) { UIAudioSource.PlayOneShot(CowPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void WayrestChargerActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the Wayrest Charger.", 5f);
			if (UIAudioSource != null && HorsePetSound != null) { UIAudioSource.PlayOneShot(HorsePetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void RatActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the rat.", 5f);
			if (UIAudioSource != null && RatPetSound != null) { UIAudioSource.PlayOneShot(RatPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void TameBoarActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the tame boar.", 5f);
			if (UIAudioSource != null && BoarPetSound != null) { UIAudioSource.PlayOneShot(BoarPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void DoveActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the dove.", 5f);
			if (UIAudioSource != null && DovePetSound != null) { UIAudioSource.PlayOneShot(DovePetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void AbibonGoraWarCamelActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the Abibon-Gora War Camel.", 5f);
			if (UIAudioSource != null && CamelPetSound != null) { UIAudioSource.PlayOneShot(CamelPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void AlcaireBeltedBullActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the Alcaire belted bull.", 5f);
			if (UIAudioSource != null && CowPetSound != null) { UIAudioSource.PlayOneShot(CowPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void AlcaireBeltedCowActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the Alcaire belted cow.", 5f);
			if (UIAudioSource != null && CowPetSound != null) { UIAudioSource.PlayOneShot(CowPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void AlcaireBeltedCalfActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the Alcaire belted calf.", 5f);
			if (UIAudioSource != null && CalfPetSound != null) { UIAudioSource.PlayOneShot(CalfPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

		private static void GreatDaenianDogActivation(RaycastHit hit)
        {
            DaggerfallUI.AddHUDText("You pet the Great Daenian dog.", 5f);
			if (UIAudioSource != null && DogPetSound != null) { UIAudioSource.PlayOneShot(DogPetSound, 1 * DaggerfallUnity.Settings.SoundVolume); }
        }

//DET Animals
		#endregion



    }
}