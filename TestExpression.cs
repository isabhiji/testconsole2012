using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole2012
{
    class TestExpression
    {
        public static void SampleExpression(int num)
        {
            Expression<Func<int, bool>> lambda = i => i < 5;
            bool results = lambda.Compile()(num);
            Console.WriteLine(results);

            // 10*2 + 2*5
            BinaryExpression bc1 = Expression.MakeBinary(ExpressionType.Multiply, Expression.Constant(10), Expression.Constant(2));
            BinaryExpression bc2 = Expression.MakeBinary(ExpressionType.Multiply, Expression.Constant(2), Expression.Constant(5));
            BinaryExpression bc3 = Expression.MakeBinary(ExpressionType.Add, bc1, bc2);
            int result = Expression.Lambda<Func<int>>(bc3).Compile()();
            Console.WriteLine(result);
            
            Expression<Func<int>> lambda2 = () => 10*2+5*2;
            int lambdaResult = lambda2.Compile()();
            Console.WriteLine(lambdaResult);

            Func<int> lambda3 = () => 10*2+5*2;
            Console.WriteLine(lambda3.Invoke());


        }
    }
}
