using ModelReplacement;
using UnityEngine;

namespace MadokaMagicaModels
{
    public class MRMADOKA : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        { 
            string model_name = "Madoka";
            return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
        }
    }public class MRHOMURA : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        { 
            string model_name = "Homura";
            return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
        }
    }
}