using UnityEngine;

namespace Curves
{
	public class BezierCurveDrawer : MonoBehaviour
	{
		public Transform P1;
		public Transform P2;
		public Transform P3;
		public Transform P4;
		public int SampleAmount = 100;
		public Color DrawColor = Color.yellow;

		void Update()
		{
			if (SampleAmount <= 0)
			{
				Debug.LogError("SampleAmount should be positive.");
				return;
			}
			
			var curve = new BezierCurve(
				P1.transform.position,
				P2.transform.position,
				P3.transform.position,
				P4.transform.position);

			var previousPoint = curve.SamplePoint(0f);

			for (float t = 0f; t <= 1f; t += 1f / SampleAmount)
			{
				var point = curve.SamplePoint(t);

				Debug.DrawLine(previousPoint, point, DrawColor);

				previousPoint = point;
			}
			
			Debug.DrawLine(previousPoint, curve.SamplePoint(1f), DrawColor);
			
			Debug.Log("Drawing");
		}
	}
}