using System;

namespace UdemyCourse.Collections;

public class Decision<TIn>
{
    Decision<TIn> _left;
    Decision<TIn> _right;

    Func<TIn, bool> _evaluate;
    

    public Decision(Func<TIn, bool> evaluate, Decision<TIn> left = null, Decision<TIn> right = null)
    {
        if (evaluate == null)
        {
            throw new ArgumentNullException(nameof(evaluate));
        }
        
        _evaluate = evaluate;
        _left = left;
        _right = right;
    }

    public bool Evaluate(TIn input) => _evaluate.Invoke(input);

    public Decision<TIn> GetForOutcome(bool outCome)
    {
        return outCome ? _left : _right;
    }
}