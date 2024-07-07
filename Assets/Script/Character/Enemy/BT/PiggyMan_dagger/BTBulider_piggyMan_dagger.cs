using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBuilder_piggyMan_dagger : BTBuilder
{
    public override BTNode Build(Creature creature)
    {
        base.Build(creature);
        AddNode(new Node_activeSelector());
            AddNode_creature(new Node_piggyMan_dagger_die(creature));
            AddNode(new Node_sequence());
                AddNode_creature(new Node_piggyMan_dagger_ifBeAttacked(creature));
                AddNode_creature(new Node_piggyMan_dagger_beAttacked(creature));
                Back();
            AddNode(new Node_sequence());
                AddNode(new Node_activeSelector());
                    AddNode(new Node_activeSequence());
                        AddNode_creature(new Node_piggyMan_dagger_findPlayer(creature));
                        AddNode_creature(new Node_piggyMan_dagger_ifNeedWalkToPlayer(creature));
                        AddNode(new Node_activeSelector());
                            AddNode_creature(new Node_piggyMan_dagger_ifNearPlayer(creature));
                            AddNode_creature(new Node_piggyMan_dagger_walkToPlayer(creature));
                            Back();
                        Back();
                    AddNode(new Node_activeSequence());
                        AddNode_creature(new Node_piggyMan_dagger_findPlayer(creature));
                        AddNode(new Node_activeSelector());
                            AddNode_creature(new Node_piggyMan_dagger_ifNearPlayer(creature));
                            AddNode_creature(new Node_piggyMan_dagger_runToPlayer(creature));
                            Back();
                        Back();
                    Back();
                AddNode(new Node_selector());
                    AddNode(new Node_sequence());
                        AddNode_creature(new Node_piggyMan_dagger_ifSkillOnCD(creature));
                        AddNode_creature(new Node_piggyMan_dagger_attack(creature));
                        Back();
                    AddNode(new Node_sequence());
                        AddNode_creature(new Node_piggyMan_dagger_skillBeg(creature));
                        AddNode(new Node_repeat(3));
                            AddNode_creature(new Node_piggyMan_dagger_skillOn(creature));
                            Back();
                        AddNode_creature(new Node_piggyMan_dagger_skillEnd(creature));
                        Back();
                    Back();
                Back();
            AddNode_creature(new Node_piggyMan_dagger_idle(creature));
        

        return root ;
    }
}
