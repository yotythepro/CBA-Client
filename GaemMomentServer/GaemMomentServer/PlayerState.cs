using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaemMomentServer
{
    internal enum PlayerState
    {
        FaceRight,
        FaceLeft,
        AttackRight,
        AttackLeft,
        RecoveryRight,
        RecoveryLeft,
        MidairFaceRight,
        MidairFaceLeft,
        MidairAttackRight,
        MidairAttackLeft,
        MidairRecoveryRight,
        MidairRecoveryLeft,
        Dead,
    }
}
