using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Player.Interfaces
{
	public interface IPlayerCamera
	{
		public void RotateCamera(float horizontalRotation, float verticalRotation);
	}
}
