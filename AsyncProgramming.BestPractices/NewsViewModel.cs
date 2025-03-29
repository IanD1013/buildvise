using AsyncProgramming.BestPractices.Constants;
using AsyncProgramming.BestPractices.Models;
using AsyncProgramming.BestPractices.Services;
using System.Collections.Frozen;
using System.Diagnostics;
using AsyncAwaitBestPractices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AsyncProgramming.BestPractices;

partial class NewsViewModel : BaseViewModel
{
	readonly HackerNewsAPIService _hackerNewsAPIService;
	readonly AsyncAwaitBestPractices.WeakEventManager _pullToRefreshEventManager = new();

	public NewsViewModel(IDispatcher dispatcher, HackerNewsAPIService hackerNewsAPIService) : base(dispatcher)
	{
		_hackerNewsAPIService = hackerNewsAPIService;

		//ToDo Refactor (finished)
		Refresh(CancellationToken.None).SafeFireAndForget(ex => Trace.WriteLine(ex));
		// Thread 1 will continue on to this line of code while Refresh is still running
	}

	public event EventHandler<string> PullToRefreshFailed
	{
		add => _pullToRefreshEventManager.AddEventHandler(value);
		remove => _pullToRefreshEventManager.RemoveEventHandler(value);
	}


	[ObservableProperty]
	public partial bool IsListRefreshing { get; set; }

	[RelayCommand]
	async Task Refresh(CancellationToken token)
	{
		// ToDo Refactor (finished)
		var minimumRefreshTimeTask = Task.Delay(TimeSpan.FromSeconds(2), token);

		try
		{
			TopStoryCollection.Clear();
			
			// ToDo Refactor (finished)
			await foreach (var story in GetTopStories(token, StoriesConstants.NumberOfStories).ConfigureAwait(false))
			{
				if (!TopStoryCollection.Any(x => x.Title.Equals(story.Title, StringComparison.Ordinal)))
					InsertIntoSortedCollection(TopStoryCollection, (a, b) => b.Score.CompareTo(a.Score), story);
			}
		}
		catch (Exception e)
		{
			OnPullToRefreshFailed(e.ToString());
		}
		finally
		{
			// ToDo Refactor (finished)
			await minimumRefreshTimeTask.ConfigureAwait(false);
			IsListRefreshing = false;
		}
	}

	// ToDo Refactor (finished)
	async IAsyncEnumerable<StoryModel> GetTopStories(CancellationToken token, int storyCount = int.MaxValue)
	{
		List<StoryModel> topStoryList = [];

		var topStoryIds = await GetTopStoryIDs(token).ConfigureAwait(false);
		
		List<Task<StoryModel>> getTopStoriesTasks = topStoryIds.Select(id => GetStory(id, token)).ToList();

		await foreach (var topStoryTask in Task.WhenEach(getTopStoriesTasks))
		{
			var topStory = await topStoryTask.ConfigureAwait(false);
			yield return topStory;
			// yield return topStoryTask.Result;
		}
	}

	//ToDo Refactor (finished)
	Task<StoryModel> GetStory(long storyId, CancellationToken token)
	{
		return _hackerNewsAPIService.GetStory(storyId, token); // just return a task
	}

	//ToDo Refactor (finished)
	async ValueTask<FrozenSet<long>> GetTopStoryIDs(CancellationToken token)
	{
		if (IsDataRecent(TimeSpan.FromHours(1)))
			return TopStoryCollection.Select(x => x.Id).ToFrozenSet();

		try
		{
			return await _hackerNewsAPIService.GetTopStoryIDs(token);
		}
		catch (Exception e)
		{
			Trace.WriteLine(e.Message);
			throw;
		}
	}

	bool IsDataRecent(TimeSpan timeSpan) => (DateTimeOffset.UtcNow - TopStoryCollection.Max(x => x.CreatedAt_DateTimeOffset)) > timeSpan;

	void OnPullToRefreshFailed(string message) => _pullToRefreshEventManager.RaiseEvent(this, message, nameof(PullToRefreshFailed));
}