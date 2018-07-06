using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace SimplyMoreBridges
{

    [StaticConstructorOnStartup]
    public class SectionLayer_BridgeProps_Heavy : SectionLayer_BridgeProps
    {
		
        public SectionLayer_BridgeProps_Heavy(Section section) : base(section) { }

        private static readonly Material propsLoopMat = MaterialPool.MatFrom("Terrain/Misc/HeavyBridgeProps_Loop", ShaderDatabase.Transparent);
        private static readonly Material propsRightMat = MaterialPool.MatFrom("Terrain/Misc/HeavyBridgeProps_Right", ShaderDatabase.Transparent);

        protected override Material PropsLoopMat
        {
            get
            {
                return propsLoopMat;
            }
        }

        protected override Material PropsRightMat
        {
            get
            {
                return propsRightMat;
            }
        }

        protected override bool IsTerrainThisBridge(TerrainDef terrain)
        {
            return terrain.designatorDropdown == DesignatorDropdownGroupDefOf.Bridge_Heavy;
        }

    }

}
