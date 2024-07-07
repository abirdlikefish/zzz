using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBuilder_piggyMan_bow : BTBuilder
{
    public override BTNode Build(Creature creature)
    {
        base.Build(creature);
        AddNode(new Node_activeSelector());
            AddNode_creature(new Node_piggyMan_bow_die(creature));
            AddNode(new Node_sequence());
                AddNode_creature(new Node_piggyMan_bow_ifBeAttacked(creature));
                AddNode_creature(new Node_piggyMan_bow_beAttacked(creature));
                Back();
            AddNode(new Node_sequence());
                AddNode(new Node_activeSelector());
                    AddNode(new Node_activeSequence());
                        AddNode_creature(new Node_piggyMan_bow_findPlayer(creature));
                        AddNode_creature(new Node_piggyMan_bow_ifNeedWalkToPlayer(creature));
                        AddNode(new Node_activeSelector());
                            AddNode_creature(new Node_piggyMan_bow_ifNearPlayer(creature));
                            AddNode_creature(new Node_piggyMan_bow_walkToPlayer(creature));
                            Back();
                        Back();
                    AddNode(new Node_activeSequence());
                        AddNode_creature(new Node_piggyMan_bow_findPlayer(creature));
                        AddNode(new Node_activeSelector());
                            AddNode_creature(new Node_piggyMan_bow_ifNearPlayer(creature));
                            AddNode_creature(new Node_piggyMan_bow_runToPlayer(creature));
                            Back();
                        Back();
                    Back();
                AddNode(new Node_selector());
                    AddNode(new Node_sequence());
                        AddNode_creature(new Node_piggyMan_bow_ifSkillOnCD(creature));
                        AddNode_creature(new Node_piggyMan_bow_keepAway(creature));
                        Back();
                    AddNode_creature(new Node_piggyMan_bow_attack(creature));

                    // AddNode(new Node_sequence());
                    //     AddNode_creature(new Node_piggyMan_bow_skillBeg(creature));
                    //     AddNode(new Node_repeat(3));
                    //         AddNode_creature(new Node_piggyMan_bow_skillOn(creature));
                    //         Back();
                    //     AddNode_creature(new Node_piggyMan_bow_skillEnd(creature));
                    //     Back();
                    Back();
                Back();
            AddNode_creature(new Node_piggyMan_bow_idle(creature));
        

        return root ;
    }
}
