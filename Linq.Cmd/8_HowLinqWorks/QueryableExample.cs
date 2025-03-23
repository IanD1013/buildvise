using System.Linq.Expressions;

namespace Linq.Cmd._8_HowLinqWorks;

public class QueryableExample : QueryRunner
{
    public override void Run()
    {
        QueryExplorer();
    }

    void QueryExplorer()
    {
        var allMovies = Repository.GetAllMoviesAsQueryable();

        var query = allMovies
            .Where(movie => movie.Phase == 4)
            .OrderBy(movie => movie.ReleaseDate)
            .Take(3);

        var queryExpression = query.Expression;

        new ExpressionFormatter().Visit(queryExpression);
    }
}

public class ExpressionFormatter : ExpressionVisitor
{
    private string _indentation = string.Empty;
    
    protected override Expression VisitBinary(BinaryExpression node)
    {
        Console.WriteLine($"{_indentation}BINARY - {node.NodeType} ");
        Indent();
        var result = base.VisitBinary(node);
        UnIndent();
        return result;
    }

    protected override Expression VisitUnary(UnaryExpression node)
    {
        if (node.Method != null)
        {
            Console.WriteLine($"{_indentation}UNARY - {node.Method.Name} ");
        }
        Console.WriteLine($"{_indentation}UNARY - {node.Operand.NodeType} ");
        Indent();
        var result = base.VisitUnary(node);
        UnIndent();
        return result;
    }

    protected override Expression VisitConstant(ConstantExpression node)
    {
        Console.WriteLine($"{_indentation}CONSTANT - {node.Value} ");
        var result = base.VisitConstant(node);
        return result;
    }

    protected override Expression VisitMember(MemberExpression node)
    {
        Console.WriteLine($"{_indentation}MEMBER - {node.Member.Name} ");
        Indent();
        var result = base.VisitMember(node);
        UnIndent();
        return result;
    }

    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        Console.WriteLine($"{_indentation}CALL - {node.Method.Name} ");
        Indent();
        var result = base.VisitMethodCall(node);
        UnIndent();
        return result;
    }

    protected override Expression VisitParameter(ParameterExpression node)
    {
        Console.WriteLine($"{_indentation}PARAMETER - {node.Name} ");
        var result = base.VisitParameter(node);
        return result;
    }

    private void Indent()
    {
        _indentation += "|\t";
    }

    private void UnIndent()
    {
        if (_indentation.Length > 0)
            _indentation = _indentation.Substring(0, _indentation.Length - 2);
    }
}