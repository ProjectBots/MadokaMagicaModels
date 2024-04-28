using BepInEx;
using HarmonyLib;
using UnityEngine;
using System.Reflection;
using ModelReplacement;
using BepInEx.Configuration;
using System;
using System.Xml.Linq;

namespace MadokaMagicaModels
{
	[BepInPlugin("ProjectBots.MadokaMagicaModels", "MadokaMagicaModels", "1.0.0")]
	[BepInDependency("meow.ModelReplacementAPI", BepInDependency.DependencyFlags.HardDependency)]
	public class Plugin : BaseUnityPlugin
	{
		private void Awake()
		{
			Assets.PopulateAssets();

			ModelReplacementAPI.RegisterSuitModelReplacement("Homura", typeof(MRHOMURA));
			ModelReplacementAPI.RegisterSuitModelReplacement("Madoka", typeof(MRMADOKA));


			Harmony harmony = new Harmony("ProjectBots.MadokaMagicaModels");
			harmony.PatchAll();
			Logger.LogInfo($"Plugin {"ProjectBots.MadokaMagicaModels"} is loaded!");
		}
	}
	public static class Assets
	{
		// Replace mbundle with the Asset Bundle Name from your unity project 
		public static string mainAssetBundleName = "models";
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		public static AssetBundle MainAssetBundle = null;
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

		private static string GetAssemblyName() => Assembly.GetExecutingAssembly().GetName().Name.Replace(" ", "_");
		public static void PopulateAssets()
		{
			if (MainAssetBundle == null)
			{
				Console.WriteLine(GetAssemblyName() + "." + mainAssetBundleName);
				using (var assetStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetAssemblyName() + "." + mainAssetBundleName))
				{
					MainAssetBundle = AssetBundle.LoadFromStream(assetStream);
				}

			}
		}
	}

}