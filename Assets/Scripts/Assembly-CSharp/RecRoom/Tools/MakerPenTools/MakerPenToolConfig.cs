using System;
using UnityEngine;

namespace RecRoom.Tools.MakerPenTools
{
	[Serializable]
	public class MakerPenToolConfig : ScriptableObject
	{
		[SerializeField]
		public MakerPenToolSelect_Object objectSelectTool;

		[SerializeField]
		public MakerPenToolMove_Object objectMoveTool;

		[SerializeField]
		public MakerPenToolTransform_Object objectTransformTool;

		[SerializeField]
		public MakerPenToolConfigure_Object objectConfigureTool;

		[SerializeField]
		public MakerPenToolDelete_Object objectDeleteTool;

		[SerializeField]
		public MakerPenToolClone_Object objectCloneTool;

		[SerializeField]
		public MakerPenToolRotate_Object objectRotateTool;

		[SerializeField]
		public MakerPenToolScale_Object objectScaleTool;

		[SerializeField]
		public MakerPenToolRepaint_Object objectRepaintTool;

		[SerializeField]
		public MakerPenToolManipulate_Object manipulateObjectTool;

		[SerializeField]
		public MakerPenToolFreeze objectFreezeTool;

		[SerializeField]
		public MakerPenToolConnect connectTool;

		[SerializeField]
		public MakerPenToolCreate_Object objectCreateTool;

		[SerializeField]
		public MakerPenToolEdit objectEditTool;

		[SerializeField]
		public MakerPenToolCreateInventionFlow createInventionFlowTool;

		[SerializeField]
		public MakerPenToolSpawnInvention spawnInventionTool;

		[SerializeField]
		public MakerPenToolClipboardPaste clipboardPasteTool;

		[SerializeField]
		public MakerPenToolCreateShape_Object createShapeTool_objectMode;

		[SerializeField]
		public MakerPenToolDisabled disabledTool;

		[SerializeField]
		public MakerPenToolOffhandCompanion offhandCompanionTool;

		[SerializeField]
		public OADMLGOMNFN circuitV2CreateTool;

		[SerializeField]
		public MakerPenToolCreateShape_Shape createShapeTool_shapeMode;

		[SerializeField]
		public MakerPenToolSelect_Shape shapeSelectTool;

		[SerializeField]
		public MakerPenToolMove_Shape shapeMoveTool;

		[SerializeField]
		public MakerPenToolTransform_Shape shapeTransformTool;

		[SerializeField]
		public MakerPenToolRotate_Shape shapeRotateTool;

		[SerializeField]
		public MakerPenToolScale_Shape shapeScaleTool;

		[SerializeField]
		public MakerPenToolClone_Shape shapeCloneTool;

		[SerializeField]
		public MakerPenToolDelete_Shape shapeDeleteTool;

		[SerializeField]
		public MakerPenToolRepaint_Shape shapeRepaintTool;

		[SerializeField]
		public MakerPenToolConfigure_Shape shapeConfigureTool;

		[SerializeField]
		public MakerPenToolEdit_Shape shapeEditTool;

		[SerializeField]
		public MakerPenToolManipulate_Shape shapeManipulateTool;

		[SerializeField]
		public MakerPenToolCreate_CircuitGroup circuitGroupCreateTool;
	}
}
