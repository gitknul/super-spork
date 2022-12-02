using System;

namespace UdemyCourse.Collections;

public class DecisionTree<TIn>
{
    Decision<TIn> Root { get; }

    
    public DecisionTree(Decision<TIn> root)
    {
        if (root == null)
        {
            throw new ArgumentNullException(nameof(root));
        }
        
        Root = root;
    }

    public bool Evaluate(TIn input)
    {
        Decision<TIn> decision = Root;

        bool outCome;

        do
        {
            outCome = decision.Evaluate(input);
            decision = decision.GetForOutcome(outCome);
        } while (decision != null);

        return outCome;
    }
}