using AsyncProgramming.BestPractices.Models;

namespace AsyncProgramming.BestPractices.Services;

using Refit;

interface IHackerNewsAPI
{
    [Get("/topstories.json?print=pretty")]
    Task<IReadOnlyList<long>> GetTopStoryIDs(CancellationToken token);

    [Get("/item/{storyId}.json?print=pretty")]
    Task<StoryModel> GetStory(long storyId, CancellationToken token);
}