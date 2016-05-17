namespace BuhtigIssueTracker.Contracts
{
    using System.Collections.Generic;

    using BuhtigIssueTracker.Models;

    using Wintellect.PowerCollections;

    public interface IBuhtigIssueTrackerData
    {
        User CurrentUser { get; set; }

        IDictionary<string, User> UsersByUsername { get; }

        OrderedDictionary<int, Issue> IssuesById { get; }

        MultiDictionary<string, Issue> IssuesByUsername { get; }

        MultiDictionary<string, Issue> IssuesByTag { get; }

        MultiDictionary<User, Comment> UserComments { get; }

        void AddIssue(Issue issue);

        void RemoveIssue(Issue issue);
    }
}
