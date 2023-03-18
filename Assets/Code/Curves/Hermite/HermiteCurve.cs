using Unity.Mathematics;
using UnityEngine;

namespace Curves
{
	public readonly struct HermiteCurve
	{
		public readonly float3 P1;
		public readonly float3 P4;
		public readonly float3 R1;
		public readonly float3 R4;

		public HermiteCurve(float3 p1, float3 p4, float3 r1, float3 r4)
		{
			P1 = p1;
			P4 = p4;
			R1 = r1;
			R4 = r4;
		}

		public float3 SamplePoint(float t)
		{
			Debug.Assert(t >= 0f && t <= 1f);

			var t3 = t * t * t;
			var t2 = t * t;

			var a1 = (2 * t3 - 3 * t2 + 1) * P1;
			var a2 = (-2 * t3 + 3 * t2) * P4;
			var a3 = (t3 - 2 * t2 + t) * R1;
			var a4 = (t3 - t2) * R4;

			return a1 + a2 + a3 + a4;
		}
	}
}