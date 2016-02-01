namespace BuhtigIssueTracker.Core
{
    using System.Collections.Generic;

    using BuhtigIssueTracker.Contracts;
    using BuhtigIssueTracker.Models;

    using Wintellect.PowerCollections;

    public class BuhtigIssueTrackerData : IBuhtigIssueTrackerData
    {
        public BuhtigIssueTrackerData()
        {
            this.NextIssueId = 1;

            this.UsersByUsername = new Dictionary<string, User>();

            this.IssuesById = new OrderedDictionary<int, Issue>();
            this.IssuesByUsername = new MultiDictionary<string, Issue>(true);
            this.IssuesByTag = new MultiDictionary<string, Issue>(true);

            this.UserComments = new MultiDictionary<User, Comment>(true);
        }

        public int NextIssueId { get; private set; }

        public User CurrentUser { get; set; }

        public IDictionary<string, User> UsersByUsername { get; set; }

        public OrderedDictionary<int, Issue> IssuesById { get; set; }

        public MultiDictionary<string, Issue> IssuesByUsername { get; set; }

        public MultiDictionary<string, Issue> IssuesByTag { get; set; }

        public MultiDictionary<User, Comment> UserComments { get; set; }

        public void AddIssue(Issue issue)
        {
            issue.Id = this.NextIssueId;
            this.IssuesById.Add(issue.Id, issue);
            this.IssuesByUsername[this.CurrentUser.UserName].Add(issue);
            foreach (var tag in issue.Tags)
            {
                if (!this.IssuesByTag.ContainsKey(tag))
                {
                    this.IssuesByTag.Add(tag, issue);
                }
                else
                {
                    this.IssuesByTag[tag].Add(issue);
                }
            }

            this.NextIssueId++;
        }

        public void RemoveIssue(Issue issue)
        {
            this.IssuesByUsername[this.CurrentUser.UserName].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.IssuesByTag[tag].Remove(issue);
            }

            this.IssuesById.Remove(issue.Id);
        }
    }
}
