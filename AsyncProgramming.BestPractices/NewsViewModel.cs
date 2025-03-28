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
		// var minimumRefreshTimeTask = Task.Delay(TimeSpan.FromSeconds(2)).WaitAsync(token);

		try
		{
			// ToDo Refactor (finished)
			var topStoriesList = await GetTopStories(token, StoriesConstants.NumberOfStories)
										.ConfigureAwait(ConfigureAwaitOptions.None | ConfigureAwaitOptions.ForceYielding);
			// now a thread that is not thread 1 continues on 
			
			TopStoryCollection.Clear();

			foreach (var story in topStoriesList)
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

	// ToDo Refactor
	async Task<FrozenSet<StoryModel>> GetTopStories(CancellationToken token, int storyCount = int.MaxValue)
	{
		List<StoryModel> topStoryList = [];

		var topStoryIds = await GetTopStoryIDs(token).ConfigureAwait(false);

		foreach (var topStoryId in topStoryIds)
		{
			var story = await GetStory(topStoryId, token).ConfigureAwait(false);
			topStoryList.Add(story);

			if (topStoryList.Count >= storyCount)
				break;
		}

		return topStoryList.OrderByDescending(x => x.Score).ToFrozenSet();
	}

	//ToDo Refactor
	async Task<StoryModel> GetStory(long storyId, CancellationToken token)
	{
		return await _hackerNewsAPIService.GetStory(storyId, token);
	}

	//ToDo Refactor
	async Task<FrozenSet<long>> GetTopStoryIDs(CancellationToken token)
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