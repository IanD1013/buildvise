// ReSharper disable UnusedMember.Local
namespace Linq.Cmd._7_CombiningResults;

public class AppendSequences : QueryRunner
{
    public override void Run()
    {
        ConcatenateTwoSequences();
    }

    /// <summary>
    /// Concatenate 2 sequences with similar the same element type.
    /// </summary>
    void ConcatenateTwoSequences()
    {
        var phaseOneMovies = Repository.GetPhase1Movies();
        var phaseTwoMovies = Repository.GetPhase2Movies();
        var phaseThreeMovies = Repository.GetPhase3Movies();

        var infinitySaga = phaseOneMovies
            .Concat(phaseTwoMovies)
            .Concat(phaseThreeMovies);
        
        PrintAll(infinitySaga);
    }
}