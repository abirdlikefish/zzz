using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBuilder_piggyMan : BTBuilder
{
    public override BTNode Build(Creature creature)
    {
        base.Build(creature);
        AddNode(new Node_activeSelector());
            AddNode(new Node_sequence());
                AddNode_creature(new Node_piggyMan_ifBeAttacked(creature));
                AddNode_creature(new Node_piggyMan_beAttacked(creature));
                Back();
            AddNode(new Node_sequence());
                // AddNode(new Node_selector());
                //     AddNode_creature(new Node_piggyMan_ifFindPlayer(creature));
                AddNode_creature(new Node_piggyMan_findPlayer(creature));
                    // Back();
                AddNode(new Node_selector());
                    AddNode(new Node_activeSequence());
                        AddNode_creature(new Node_piggyMan_ifNeedWalkToPlayer(creature));
                        AddNode(new Node_activeSelector());
                            AddNode_creature(new Node_piggyMan_ifNearPlayer(creature));
                            AddNode_creature(new Node_piggyMan_walkToPlayer(creature));
                            Back();
                        Back();
                    AddNode(new Node_activeSelector());
                        AddNode_creature(new Node_piggyMan_ifNearPlayer(creature));
                        AddNode_creature(new Node_piggyMan_runToPlayer(creature));
                        Back();
                    Back();
                AddNode(new Node_selector());
                    AddNode(new Node_sequence());
                        AddNode_creature(new Node_piggyMan_ifSkillOnCD(creature));
                        AddNode_creature(new Node_piggyMan_attack(creature));
                        Back();
                    AddNode(new Node_sequence());
                        AddNode_creature(new Node_piggyMan_skillBeg(creature));
                        AddNode(new Node_repeat(3));
                            AddNode_creature(new Node_piggyMan_skillOn(creature));
                            Back();
                        AddNode_creature(new Node_piggyMan_skillEnd(creature));
        

        return root ;
    }
}
