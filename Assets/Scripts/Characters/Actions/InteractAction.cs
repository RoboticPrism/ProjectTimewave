using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Characters.Actions
{
    public class InteractAction : BaseAction
    {
        public override void DoAction()
        {
            character.doInteraction = true;
        }

        public override void StopAction()
        {
            Destroy(this.gameObject);
        }
    }
}
