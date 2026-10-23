using System;

namespace RecRoom.Core.Vehicles
{
	public class VehicleCollider : RecRoomCollider
	{
		[NonSerialized]
		public FixedPathVehicle ThisVehicle;
	}
}
