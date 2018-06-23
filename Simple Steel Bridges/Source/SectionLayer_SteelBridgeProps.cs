using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace SimpleSteelBridges
{
	
	[StaticConstructorOnStartup]
	public class SectionLayer_SteelBridgeProps : SectionLayer
	{
		
		private static readonly Material PropsLoopMat = MaterialPool.MatFrom("Terrain/Misc/SteelBridgeProps_Loop", ShaderDatabase.Transparent);
		private static readonly Material PropsRightMat = MaterialPool.MatFrom("Terrain/Misc/SteelBridgeProps_Right", ShaderDatabase.Transparent);

		public SectionLayer_SteelBridgeProps(Section section) : base(section)
		{
			this.relevantChangeTypes = MapMeshFlag.Terrain;
		}

		public override bool Visible
		{
			get
			{
				return DebugViewSettings.drawTerrain;
			}
		}

		public override void Regenerate()
		{
			base.ClearSubMeshes(MeshParts.All);
			TerrainGrid terrainGrid = Map.terrainGrid;
			CellRect cellRect = section.CellRect;
			float y = AltitudeLayer.TerrainScatter.AltitudeFor();
			CellRect.CellRectIterator iterator = cellRect.GetIterator();
			while (!iterator.Done())
			{
				IntVec3 intVec = iterator.Current;
				if (ShouldDrawPropsBelow(intVec, terrainGrid))
				{
					IntVec3 c = intVec;
					c.x++;
					Material material;
					if (c.InBounds(Map) && ShouldDrawPropsBelow(c, terrainGrid))
					{
						material = PropsLoopMat;
					}
					else
					{
						material = PropsRightMat;
					}
					LayerSubMesh subMesh = GetSubMesh(material);
					int count = subMesh.verts.Count;
					subMesh.verts.Add(new Vector3((float)intVec.x, y, (float)(intVec.z - 1)));
					subMesh.verts.Add(new Vector3((float)intVec.x, y, (float)intVec.z));
					subMesh.verts.Add(new Vector3((float)(intVec.x + 1), y, (float)intVec.z));
					subMesh.verts.Add(new Vector3((float)(intVec.x + 1), y, (float)(intVec.z - 1)));
					subMesh.uvs.Add(new Vector2(0f, 0f));
					subMesh.uvs.Add(new Vector2(0f, 1f));
					subMesh.uvs.Add(new Vector2(1f, 1f));
					subMesh.uvs.Add(new Vector2(1f, 0f));
					subMesh.tris.Add(count);
					subMesh.tris.Add(count + 1);
					subMesh.tris.Add(count + 2);
					subMesh.tris.Add(count);
					subMesh.tris.Add(count + 2);
					subMesh.tris.Add(count + 3);
				}
				iterator.MoveNext();
			}
			FinalizeMesh(MeshParts.All);
		}

		private bool ShouldDrawPropsBelow(IntVec3 c, TerrainGrid terrGrid)
		{
			TerrainDef terrainDef = terrGrid.TerrainAt(c);
			bool result;
			if (terrainDef == null || terrainDef != TerrainDefOf.SteelBridge)
			{
				result = false;
			}
			else
			{
				IntVec3 c2 = c;
				c2.z--;
				if (!c2.InBounds(Map))
				{
					result = false;
				}
				else
				{
					TerrainDef terrainDef2 = terrGrid.TerrainAt(c2);
					result = (terrainDef2 != TerrainDefOf.SteelBridge && (terrainDef2.passability == Traversability.Impassable || c2.SupportsStructureType(Map, TerrainDefOf.SteelBridge.terrainAffordanceNeeded)));
				}
			}
			return result;
		}

	}

}
