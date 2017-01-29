using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class InteractAction : BaseAction
    {

        public override void DoAction()
        {
            Character.doInteraction();
        }

        public override void StopAction()
        {
            Destroy(this.gameObject);
        }
    }
