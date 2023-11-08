using Godot;
using Godot.NativeInterop;
using System;
using System.Reflection.Metadata.Ecma335;

public partial class OptimalPath : Node3D
{
	private class DistanceMatrix {
		private float[,] _matrix;
		public DistanceMatrix(Vector2[] positions) {
			float[,] matrix = new float[positions.Length, positions.Length];
			for (int i=0; i<positions.Length; i++) {
				for (int j=0; j<positions.Length; j++) {
					matrix[i,j] = ArcDistance(positions[i], positions[j]);
				}
			}
			_matrix = matrix;
		}

		public void DisplayMatrix() {
			
		}
	}

	private static readonly float R = 6371.009f;

	Vector2[] TRACKS = {
		new Vector2(26.032141603946066f, 50.51119187684814f),
		new Vector2(21.63166427168091f, 39.10505209392155f),
		new Vector2(-37.849611130725826f, 144.9704060684025f),
		new Vector2(34.8457737668585f, 136.53925037205605f),
		new Vector2(31.339856668286828f, 121.22044692431497f),
		new Vector2(25.957292959790202f, -80.22993123280233f),
		new Vector2(44.344895142772565f, 11.716097360392862f),
		new Vector2(43.73421304186609f, 7.421332644747529f),
		new Vector2(45.50175394693892f, -73.52790535674856f),
		new Vector2(41.5686442093569f, 2.257741079312142f),
		new Vector2(47.219799535281254f, 14.765713912136219f),
		new Vector2(52.069836533963134f, -1.0229771875117888f),
		new Vector2(47.5800486160281f, 19.24798441400903f),
		new Vector2(52.38994714382338f, 4.543279954364155f),
		new Vector2(45.617602066990216f, 9.281208436557208f),
		new Vector2(40.37303250310494f, 49.85364293692919f),
		new Vector2(1.2919163148588604f, 103.86292184384607f),
		new Vector2(30.1317020612086f, -97.63860704443542f),
		new Vector2(19.405675471783507f, -99.09168643919102f),
		new Vector2(-23.70452668915634f, -46.698765421575196f),
		new Vector2(36.20002221501221f, -115.11629185563534f),
		new Vector2(25.48875080801789f, 51.45117641122985f),
		new Vector2(24.47523725370212f, 54.60312796179991f)
	};

	private static float ArcDistance(Vector2 pos1, Vector2 pos2) {
		float dLat = Mathf.DegToRad(pos2.Y) - Mathf.DegToRad(pos1.Y);
		float dLong = Mathf.DegToRad(pos2.X) - Mathf.DegToRad(pos1.X);
		float mLat = (Mathf.DegToRad(pos1.Y)+Mathf.DegToRad(pos2.Y))/2;
		return R*Mathf.Sqrt(dLat*dLat + Mathf.Pow(Mathf.Cos(mLat)*dLong, 2));
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print(ArcDistance(TRACKS[0], TRACKS[2]));
		DistanceMatrix mat = new DistanceMatrix(TRACKS);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
